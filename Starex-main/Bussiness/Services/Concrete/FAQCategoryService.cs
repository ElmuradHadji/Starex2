using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.FAQCategoryDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class FAQCategoryService : IFAQCategoryService
    {
        private readonly IFAQCategoryRepository _FAQCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public FAQCategoryService(IFAQCategoryRepository fAQCategoryRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _FAQCategoryRepository = fAQCategoryRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(FAQCategoryPostDto FAQCategoryPostDto)
        {
            FAQCategory FAQCategory = _FAQCategoryRepository.Get(p => p.Name == FAQCategoryPostDto.Name);
            if (FAQCategory is not null)
            {
                throw new AlreadyExsistException("Kategoriya mövcuddur");
            }
            FAQCategory = _mapper.Map<FAQCategory>(FAQCategoryPostDto);




            _FAQCategoryRepository.Create(FAQCategory);
            _FAQCategoryRepository.Save();
        }

        public void Delete(int id)
        {
            FAQCategory FAQCategory = _FAQCategoryRepository.Get(p => p.Id == id);
            if (FAQCategory is null)
                throw new NotFoundException("Data tapılmadı");
            _FAQCategoryRepository.Delete(FAQCategory);
            _FAQCategoryRepository.Save();

        }

        public List<FAQCategoryGetDto> GetAll()
        {
            List<FAQCategoryGetDto> list = new List<FAQCategoryGetDto>();
            return _FAQCategoryRepository.GetAll().Count is not 0 ? _mapper.Map<List<FAQCategoryGetDto>>(_FAQCategoryRepository.GetAll()) : list;
        }

        public FAQCategoryGetDto GetById(int id)
        {
            FAQCategoryGetDto FAQCategoryGetDto = new FAQCategoryGetDto();
            if (_FAQCategoryRepository.Get(p => p.Id == id) is not null)
            {
                FAQCategoryGetDto = _mapper.Map<FAQCategoryGetDto>(_FAQCategoryRepository.Get(p => p.Id == id));

            }
            return FAQCategoryGetDto;
        }



        public void ModifyActivation(int id)
        {
            FAQCategory FAQCategory = _FAQCategoryRepository.Get(p => p.Id == id);
            if (FAQCategory is null)
                throw new NotFoundException("Data tapılmadı");
            if (FAQCategory.IsActive == true)
            {
                FAQCategory.IsActive = false;
            }
            else { FAQCategory.IsActive = true; }
            _FAQCategoryRepository.Update(FAQCategory);
            _FAQCategoryRepository.Save();
        }

        public void Update(FAQCategoryUpdateDto FAQCategoryUpdateDto)
        {
            FAQCategory FAQCategory = _FAQCategoryRepository.Get(p => p.Id == FAQCategoryUpdateDto.FAQCategoryGetDto.Id);
            if (FAQCategory is null)
                throw new NotFoundException("Data tapılmadı");
            FAQCategory.Name = FAQCategoryUpdateDto.FAQCategoryPostDto.Name;
            _FAQCategoryRepository.Update(FAQCategory);
            _FAQCategoryRepository.Save();
        }
    }
}
