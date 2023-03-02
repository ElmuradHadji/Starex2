using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.BranchDTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public BranchService(IBranchRepository branchRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(BranchPostDto branchPostDto)
        {
            Branch branch = _branchRepository.Get(p => p.Adress == branchPostDto.Adress);
            if (branch is not null)
            {
                throw new AlreadyExsistException("Anbar mövcuddur");
            }
            branch = _mapper.Map<Branch>(branchPostDto);




            _branchRepository.Create(branch);
            _branchRepository.Save();
        }

        public void Delete(int id)
        {
            Branch branch = _branchRepository.Get(p => p.Id == id);
            if (branch is null)
                throw new NotFoundException("Data tapılmadı");
            _branchRepository.Delete(branch);
            _branchRepository.Save();

        }

        public List<BranchGetDto> GetAll()
        {
            List<BranchGetDto> list = new List<BranchGetDto>();
            return _branchRepository.GetAll().Count is not 0 ? _mapper.Map<List<BranchGetDto>>(_branchRepository.GetAll()) : list;
        }

        public BranchGetDto GetById(int id)
        {
            BranchGetDto branchGetDto = new BranchGetDto();
            if (_branchRepository.Get(p => p.Id == id) is not null)
            {
                branchGetDto = _mapper.Map<BranchGetDto>(_branchRepository.Get(p => p.Id == id));

            }
            return branchGetDto;
        }



        public void ModifyActivation(int id)
        {
            Branch branch = _branchRepository.Get(p => p.Id == id);
            if (branch is null)
                throw new NotFoundException("Data tapılmadı");
            if (branch.IsActive == true)
            {
                branch.IsActive = false;
            }
            else { branch.IsActive = true; }
            _branchRepository.Update(branch);
            _branchRepository.Save();
        }

        public void Update(BranchUpdateDto branchUpdateDto)
        {
            Branch branch = _branchRepository.Get(p => p.Id == branchUpdateDto.branchGetDto.Id);
            if (branch is null)
                throw new NotFoundException("Data tapılmadı");
            branch.PackageCapasity = branchUpdateDto.branchPostDto.PackageCapasity;
            branch.Adress = branchUpdateDto.branchPostDto.Adress;
            branch.Name = branchUpdateDto.branchPostDto.Name;
            branch.City = branchUpdateDto.branchPostDto.City;
            branch.CountryId = branchUpdateDto.branchPostDto.CountryId;
            _branchRepository.Update(branch);
            _branchRepository.Save();
        }
    }
}
