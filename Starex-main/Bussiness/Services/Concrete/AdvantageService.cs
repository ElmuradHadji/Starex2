using AutoMapper;
using Bussiness.Services.Abstract;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.AdvantageDTOs;
using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Core.Utilities.Extentions;
using Core.DAL.Repositories.Abstract;

namespace Bussiness.Services.Concrete
{
    public class AdvantageService : IAdvantageService
    {
        private readonly IAdvantageRepository _advantageRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public AdvantageService(IAdvantageRepository advantageRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _advantageRepository = advantageRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(AdvantagePostDto advantagePostDto)
        {
            Advantage advantage = _advantageRepository.Get(p => p.Title == advantagePostDto.Title);
            if (advantage is not null)
            {
                throw new AlreadyExsistException("Məlumat mövcuddur");
            }
            advantage = _mapper.Map<Advantage>(advantagePostDto);
            

                advantage.Image = advantagePostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");

            
            _advantageRepository.Create(advantage);
            _advantageRepository.Save();
        }

        public void Delete(int id)
        {
            Advantage advantage = _advantageRepository.Get(p => p.Id == id);
            if (advantage is null)
                throw new NotFoundException("Data tapılmadı");
            _advantageRepository.Delete(advantage);
            _advantageRepository.Save();

        }

        public List<AdvantageGetDto> GetAll()
        {
            List<AdvantageGetDto> list = new List<AdvantageGetDto>();
            return _advantageRepository.GetAll().Count is not 0 ? _mapper.Map<List<AdvantageGetDto>>(_advantageRepository.GetAll()) : list;
        }

        public AdvantageGetDto GetById(int id)
        {
            AdvantageGetDto advantageGetDto = new AdvantageGetDto();
            if (_advantageRepository.Get(p => p.Id == id) is not null)
            {
                advantageGetDto = _mapper.Map<AdvantageGetDto>(_advantageRepository.Get(p => p.Id == id));

            }
            return advantageGetDto;
        }

     

        public void ModifyActivation(int id)
        {
            Advantage advantage = _advantageRepository.Get(p => p.Id == id);
            if (advantage is null)
                throw new NotFoundException("Data tapılmadı");
            if (advantage.IsActive==true)
            {
                advantage.IsActive = false;
            }
            else { advantage.IsActive=true; }
            _advantageRepository.Update(advantage);
            _advantageRepository.Save();
        }

        public void Update(AdvantageUpdateDto advantageUpdateDto)
        {
            Advantage advantage = _advantageRepository.Get(p => p.Id == advantageUpdateDto.advantageGetDto.Id);
            if (advantage is null)
                throw new NotFoundException("Data tapılmadı");
            advantage.Title = advantageUpdateDto.advantagePostDto.Title;
            advantage.Description = advantageUpdateDto.advantagePostDto.Description;
            if (advantageUpdateDto.advantagePostDto.formFile is not null)
            {
                Core.Utilities.Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", advantage.Image);
                advantage.Image = advantageUpdateDto.advantagePostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");

            }
            _advantageRepository.Update(advantage);
            _advantageRepository.Save();
        }
    }
}
