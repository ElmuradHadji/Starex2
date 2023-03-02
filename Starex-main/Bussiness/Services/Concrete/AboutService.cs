using AutoMapper;
using Bussiness.Services.Abstract;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using System.Reflection.Metadata;
using Core.Utilities.Extentions;

namespace Bussiness.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AboutService(IAboutRepository aboutRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(AboutPostDto aboutPostDto)
        {
            _aboutRepository.Create(_mapper.Map<About>(aboutPostDto));
            _aboutRepository.Save();
        }

        public void Delete(int id)
        {
            About about = _aboutRepository.Get(p => p.Id == id);
            if (about is null)
                throw new NotFoundException("Data tapılmadı");
            _aboutRepository.Delete(about);
            _aboutRepository.Save();

        }

        public List<AboutGetDto> GetAll()
        {
            List<AboutGetDto> list = new List<AboutGetDto>();
            return _aboutRepository.GetAll().Count is not 0 ? _mapper.Map<List<AboutGetDto>>(_aboutRepository.GetAll()) : list;
        }

        public AboutGetDto GetById(int id)
        {
            AboutGetDto aboutGetDto = new AboutGetDto();
            if (_aboutRepository.Get(p => p.Id == id) is not null)
            {
                 aboutGetDto= _mapper.Map<AboutGetDto>(_aboutRepository.Get(p => p.Id == id));

            }
            return aboutGetDto;
        }

        public void Update(AboutUpdateDto aboutUpdateDto)
        {
            About about = _aboutRepository.Get(p => p.Id == aboutUpdateDto.aboutGetDto.Id);
            if (about is null)
                throw new NotFoundException("Data tapılmadı");
            about.Text=aboutUpdateDto.aboutPostDto.Text;
            if (aboutUpdateDto.aboutPostDto.formFile is not null)
            {
                
                Core.Utilities.Helpers.Helper.DeleteImg(_env.WebRootPath,"assets/images",about.Image);
                about.Image = aboutUpdateDto.aboutPostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");

            }
            _aboutRepository.Update(about);
            _aboutRepository.Save();
        }
    }
}
