using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.PackageStatusDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class PackageStatusService : IPackageStatusService
    {
        private readonly IPackageStatusRepository _packageStatusRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public PackageStatusService(IPackageStatusRepository packageStatusRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _packageStatusRepository = packageStatusRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(PackageStatusPostDto packageStatusPostDto)
        {
            PackageStatus packageStatus = _packageStatusRepository.Get(p => p.Name == packageStatusPostDto.Name);
            if (packageStatus is not null)
            {
                throw new AlreadyExsistException("Status mövcuddur");
            }
            packageStatus = _mapper.Map<PackageStatus>(packageStatusPostDto);




            _packageStatusRepository.Create(packageStatus);
            _packageStatusRepository.Save();
        }

        public void Delete(int id)
        {
            PackageStatus packageStatus = _packageStatusRepository.Get(p => p.Id == id);
            if (packageStatus is null)
                throw new NotFoundException("Data tapılmadı");
            _packageStatusRepository.Delete(packageStatus);
            _packageStatusRepository.Save();

        }

        public List<PackageStatusGetDto> GetAll()
        {
            List<PackageStatusGetDto> list = new List<PackageStatusGetDto>();
            return _packageStatusRepository.GetAll().Count is not 0 ? _mapper.Map<List<PackageStatusGetDto>>(_packageStatusRepository.GetAll()) : list;
        }

        public PackageStatusGetDto GetById(int id)
        {
            PackageStatusGetDto packageStatusGetDto = new PackageStatusGetDto();
            if (_packageStatusRepository.Get(p => p.Id == id) is not null)
            {
                packageStatusGetDto = _mapper.Map<PackageStatusGetDto>(_packageStatusRepository.Get(p => p.Id == id));

            }
            return packageStatusGetDto;
        }




        public void Update(PackageStatusUpdateDto packageStatusUpdateDto)
        {
            PackageStatus packageStatus = _packageStatusRepository.Get(p => p.Id == packageStatusUpdateDto.packageStatusGetDto.Id);
            if (packageStatus is null)
                throw new NotFoundException("Data tapılmadı");
            packageStatus.Name = packageStatusUpdateDto.packageStatusPostDto.Name;
            _packageStatusRepository.Update(packageStatus);
            _packageStatusRepository.Save();
        }
    }
}
