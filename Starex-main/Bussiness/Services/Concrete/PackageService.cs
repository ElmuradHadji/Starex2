using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.PackageDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Bussiness.Services.Concrete
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IPricingService _pricingService;

        public PackageService(IPackageRepository packageRepository, IMapper mapper, IWebHostEnvironment env, IPricingService pricingService)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
            _env = env;
            _pricingService = pricingService;
        }

        public void Create(PackagePostDto packagePostDto)
        {
            Package package = _packageRepository.Get(p => p.Name == packagePostDto.Name);
            if (package is not null)
            {
                throw new AlreadyExsistException("Bağlama mövcuddur");
            }
            package = _mapper.Map<Package>(packagePostDto);
            package.wareHouseId = 2;
            if (packagePostDto.Weight>=1)
            {
               // package.Price=_pricingService.GetAll(p=>p.MaxKG==1)
            }
            foreach (var price in _pricingService.GetAll())
            {
                if (true)
                {

                }
            }




            _packageRepository.Create(package);
            _packageRepository.Save();
        }

        public void Delete(int id)
        {
            Package package = _packageRepository.Get(p => p.Id == id);
            if (package is null)
                throw new NotFoundException("Data tapılmadı");
            _packageRepository.Delete(package);
            _packageRepository.Save();

        }

        public List<PackageGetDto> GetAllByWareHouse(int? id)
        {
            List<PackageGetDto> list = new List<PackageGetDto>();
            return _packageRepository.GetAll(expression:p=>p.wareHouseId==id).Count is not 0 ? _mapper.Map<List<PackageGetDto>>(_packageRepository.GetAll()) : list;
        }

        public PackageGetDto GetById(int id)
        {
            PackageGetDto packageGetDto = new PackageGetDto();
            if (_packageRepository.Get(p => p.Id == id) is not null)
            {
                packageGetDto = _mapper.Map<PackageGetDto>(_packageRepository.Get(p => p.Id == id));

            }
            return packageGetDto;
        }




        public void Update(PackageUpdateDto packageUpdateDto)
        {
            Package package = _packageRepository.Get(p => p.Id == packageUpdateDto.packageGetDto.Id);
            if (package is null)
                throw new NotFoundException("Data tapılmadı");
            package.packageStatusId = packageUpdateDto.packagePostDto.packageStatusId;
            package.Weight = packageUpdateDto.packagePostDto.Weight;
            package.PriceCurrencyId = packageUpdateDto.packagePostDto.PriceCurrencyId;
            package.Price = packageUpdateDto.packagePostDto.Price;
            package.OriginalTrackingId = packageUpdateDto.packagePostDto.OriginalTrackingId;
            package.Name = packageUpdateDto.packagePostDto.Name;
            package.CostCurrencyId = packageUpdateDto.packagePostDto.CostCurrencyId;
            package.Cost = packageUpdateDto.packagePostDto.Cost;
            package.branchId = packageUpdateDto.packagePostDto.branchId;
            _packageRepository.Update(package);
            _packageRepository.Save();
        }
    }
}
