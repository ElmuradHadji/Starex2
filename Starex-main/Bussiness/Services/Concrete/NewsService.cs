using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Extentions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.NewsDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _NewsRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public NewsService(INewsRepository newsRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _NewsRepository = newsRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(NewsPostDto newsPostDto)
        {
            News news = _NewsRepository.Get(p => p.Title == newsPostDto.Title);
            if (news is not null)
            {
                throw new AlreadyExsistException("Xəbər mövcuddur");
            }
            news = _mapper.Map<News>(newsPostDto);
            news.CreatedTime= DateTime.UtcNow;
            news.Image = newsPostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");





            _NewsRepository.Create(news);
            _NewsRepository.Save();
        }

        public void Delete(int id)
        {
            News news = _NewsRepository.Get(p => p.Id == id);
            if (news is null)
                throw new NotFoundException("Data tapılmadı");
            news.IsDeleted= true;
            _NewsRepository.Update(news);
            _NewsRepository.Save();

        }

        public List<NewsGetDto> GetAll()
        {
            List<NewsGetDto> list = new List<NewsGetDto>();
            return _NewsRepository.GetAll(p=>p.IsDeleted==false).Count is not 0 ? _mapper.Map<List<NewsGetDto>>(_NewsRepository.GetAll()) : list;
        }

        public NewsGetDto GetById(int id)
        {
            NewsGetDto NewsGetDto = new NewsGetDto();
            if (_NewsRepository.Get(p => p.Id == id) is not null)
            {
                NewsGetDto = _mapper.Map<NewsGetDto>(_NewsRepository.Get(p => p.Id == id));

            }
            return NewsGetDto;
        }




        public void Update(NewsUpdateDto newsUpdateDto)
        {
            News news = _NewsRepository.Get(p => p.Id == newsUpdateDto.newsGetDto.Id);
            if (news is null)
                throw new NotFoundException("Data tapılmadı");
            news.Title = newsUpdateDto.newsPostDto.Title;
            news.Description = newsUpdateDto.newsPostDto.Description;
            news.UpdatedTime = DateTime.UtcNow;
            _NewsRepository.Update(news);
            _NewsRepository.Save();
        }

    }
}
