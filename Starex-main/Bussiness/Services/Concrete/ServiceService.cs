using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Extentions;
using Core.Utilities.Helpers;
using DataAccess.Repositories.Abstarct;
using DataAccess.Repositories.Conctrete.EF;
using Entities.Concrete;
using Entities.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(ServicePostDto servicePostDto)
        {
            Service service = _serviceRepository.Get(p => p.Title == servicePostDto.Title);
            if (service is not null)
            {
                throw new AlreadyExsistException("Servis mövcuddur");
            }
            service = _mapper.Map<Service>(servicePostDto);
            
            service.Image = servicePostDto.formFile.SaveImage(_env.WebRootPath, "assets/images");





            _serviceRepository.Create(service);
            _serviceRepository.Save();
        }

        public void Delete(int id)
        {
            Service service = _serviceRepository.Get(p => p.Id == id);
            if (service is null)
                throw new NotFoundException("Data tapılmadı");
            _serviceRepository.Delete(service);
            _serviceRepository.Save();

        }

        public List<ServiceGetDto> GetAll()
        {
            List<ServiceGetDto> list = new List<ServiceGetDto>();
            return _serviceRepository.GetAll().Count is not 0 ? _mapper.Map<List<ServiceGetDto>>(_serviceRepository.GetAll()) : list;
        }

        public ServiceGetDto GetById(int id)
        {
            ServiceGetDto ServiceGetDto = new ServiceGetDto();
            if (_serviceRepository.Get(p => p.Id == id) is not null)
            {
                ServiceGetDto = _mapper.Map<ServiceGetDto>(_serviceRepository.Get(p => p.Id == id));

            }
            return ServiceGetDto;
        }




        public void Update(ServiceUpdateDto serviceUpdateDto)
        {
            Service service = _serviceRepository.Get(p => p.Id == serviceUpdateDto.serviceGetDto.Id);
            if (service is null)
                throw new NotFoundException("Data tapılmadı");
            service.Title = serviceUpdateDto.servicePostDto.Title;
            service.Description = serviceUpdateDto.servicePostDto.Description;
            if (serviceUpdateDto.servicePostDto.formFile is not null)
            {
                Helper.DeleteImg(_env.WebRootPath, "\"assets/images\"", service.Image);
                service.Image = serviceUpdateDto.servicePostDto.formFile.SaveImage(_env.WebRootPath,"assets/images");
            }
            _serviceRepository.Update(service);
            _serviceRepository.Save();
        }
        public void ModifyActivation(int id)
        {
            Service service = _serviceRepository.Get(p => p.Id == id);
            if (service is null)
                throw new NotFoundException("Data tapılmadı");
            if (service.IsActive == true)
            {
                service.IsActive = false;
            }
            else { service.IsActive = true; }
            _serviceRepository.Update(service);
            _serviceRepository.Save();
        }

    }
}
