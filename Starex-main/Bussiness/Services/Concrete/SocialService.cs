using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Core.Entities.DTOs.SocialDTOs;
using Microsoft.AspNetCore.Hosting;
using Core.Entities.Concrete;
using DataAccess.Repositories.Conctrete.EF;

namespace Bussiness.Services.Concrete
{
    public class SocialService : ISocialService
    {
        private readonly ISocialRepository _socialRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SocialService(ISocialRepository socialRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _socialRepository = socialRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(SocialPostDto socialPostDto)
        {
            Social social = _socialRepository.Get(p => p.Name == socialPostDto.Name);
            if (social is not null)
            {
                throw new AlreadyExsistException("Məlumat mövcuddur");
            }
            social = _mapper.Map<Social>(socialPostDto);




            _socialRepository.Create(social);
            _socialRepository.Save();
        }

        public void Delete(int id)
        {
            Social social = _socialRepository.Get(p => p.Id == id);
            if (social is null)
                throw new NotFoundException("Data tapılmadı");
            _socialRepository.Delete(social);
            _socialRepository.Save();

        }

        public List<SocialGetDto> GetAll()
        {
            List<SocialGetDto> list = new List<SocialGetDto>();
            return _socialRepository.GetAll().Count is not 0 ? _mapper.Map<List<SocialGetDto>>(_socialRepository.GetAll()) : list;
        }

        public SocialGetDto GetById(int id)
        {
            SocialGetDto socialGetDto = new SocialGetDto();
            if (_socialRepository.Get(p => p.Id == id) is not null)
            {
                socialGetDto = _mapper.Map<SocialGetDto>(_socialRepository.Get(p => p.Id == id));

            }
            return socialGetDto;
        }



        public void ModifyActivation(int id)
        {
            Social social = _socialRepository.Get(p => p.Id == id);
            if (social is null)
                throw new NotFoundException("Data tapılmadı");
            if (social.IsActive == true)
            {
                social.IsActive = false;
            }
            else { social.IsActive = true; }
            _socialRepository.Update(social);
            _socialRepository.Save();
        }

        public void Update(SocialUpdateDto socialUpdateDto)
        {
            Social social = _socialRepository.Get(p => p.Id == socialUpdateDto.socialGetDto.Id);
            if (social is null)
                throw new NotFoundException("Data tapılmadı");
            social.Icon = socialUpdateDto.socialPostDto.Icon;
            social.Name = socialUpdateDto.socialPostDto.Name;
            social.Url= socialUpdateDto.socialPostDto.Url;
            _socialRepository.Update(social);
            _socialRepository.Save();
        }
    }

}
