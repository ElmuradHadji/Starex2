using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.FAQDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _FAQRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public FAQService(IFAQRepository fAQRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _FAQRepository = fAQRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(FAQPostDto FAQPostDto)
        {
             FAQ FAQ = _FAQRepository.Get(p => p.Question == FAQPostDto.Question);
            if (FAQ is not null)
            {
                throw new AlreadyExsistException("Sual mövcuddur");
            }
            FAQ = _mapper.Map<FAQ>(FAQPostDto);




            _FAQRepository.Create(FAQ);
            _FAQRepository.Save();
        }

        public void Delete(int id)
        {
            FAQ FAQ = _FAQRepository.Get(p => p.Id == id);
            if (FAQ is null)
                throw new NotFoundException("Data tapılmadı");
            _FAQRepository.Delete(FAQ);
            _FAQRepository.Save();

        }

        public List<FAQGetDto> GetAll()
        {
            List<FAQGetDto> list = new List<FAQGetDto>();
            return _FAQRepository.GetAll(includes:"p=>p.CategoryId=Category").Count is not 0 ? _mapper.Map<List<FAQGetDto>>(_FAQRepository.GetAll()) : list;
        }

        public FAQGetDto GetById(int id)
        {
            FAQGetDto FAQGetDto = new FAQGetDto();
            if (_FAQRepository.Get(p => p.Id == id) is not null)
            {
                FAQGetDto = _mapper.Map<FAQGetDto>(_FAQRepository.Get(p => p.Id == id));

            }
            return FAQGetDto;
        }



        public void ModifyActivation(int id)
        {
            FAQ FAQ = _FAQRepository.Get(p => p.Id == id);
            if (FAQ is null)
                throw new NotFoundException("Data tapılmadı");
            if (FAQ.IsActive == true)
            {
                FAQ.IsActive = false;
            }
            else { FAQ.IsActive = true; }
            _FAQRepository.Update(FAQ);
            _FAQRepository.Save();
        }

        public void Update(FAQUpdateDto FAQUpdateDto)
        {
            FAQ FAQ = _FAQRepository.Get(p => p.Id == FAQUpdateDto.FAQGetDto.Id);
            if (FAQ is null)
                throw new NotFoundException("Data tapılmadı");
            FAQ.Question = FAQUpdateDto.FAQPostDto.Question;
            FAQ.Answer = FAQUpdateDto.FAQPostDto.Answer;
            FAQ.CategoryId = FAQUpdateDto.FAQPostDto.CategoryId;
            _FAQRepository.Update(FAQ);
            _FAQRepository.Save();
        }
   
    }
}
