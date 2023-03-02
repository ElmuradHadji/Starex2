using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstarct;
using Entities.Concrete;
using Entities.DTOs.DeliveryPointDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Bussiness.Services.Concrete
{
    public class DeliveryPointService : IDeliveryPointService
    {
        private readonly IDeliveryPointRepository _deliveryPointRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public DeliveryPointService(IDeliveryPointRepository deliveryPointRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _deliveryPointRepository = deliveryPointRepository;
            _mapper = mapper;
            _env = env;
        }

        public void Create(DeliveryPointPostDto deliveryPointPostDto)
        {
            DeliveryPoint deliveryPoint = _deliveryPointRepository.Get(p => p.Adress == deliveryPointPostDto.Adress);
            if (deliveryPoint is not null)
            {
                throw new AlreadyExsistException("Anbar mövcuddur");
            }
            deliveryPoint = _mapper.Map<DeliveryPoint>(deliveryPointPostDto);




            _deliveryPointRepository.Create(deliveryPoint);
            _deliveryPointRepository.Save();
        }

        public void Delete(int id)
        {
            DeliveryPoint deliveryPoint = _deliveryPointRepository.Get(p => p.Id == id);
            if (deliveryPoint is null)
                throw new NotFoundException("Data tapılmadı");
            _deliveryPointRepository.Delete(deliveryPoint);
            _deliveryPointRepository.Save();

        }

        public List<DeliveryPointGetDto> GetAll()
        {
            List<DeliveryPointGetDto> list = new List<DeliveryPointGetDto>();
            return _deliveryPointRepository.GetAll().Count is not 0 ? _mapper.Map<List<DeliveryPointGetDto>>(_deliveryPointRepository.GetAll()) : list;
        }

        public DeliveryPointGetDto GetById(int id)
        {
            DeliveryPointGetDto deliveryPointGetDto = new DeliveryPointGetDto();
            if (_deliveryPointRepository.Get(p => p.Id == id) is not null)
            {
                deliveryPointGetDto = _mapper.Map<DeliveryPointGetDto>(_deliveryPointRepository.Get(p => p.Id == id));

            }
            return deliveryPointGetDto;
        }



        public void ModifyActivation(int id)
        {
            DeliveryPoint deliveryPoint = _deliveryPointRepository.Get(p => p.Id == id);
            if (deliveryPoint is null)
                throw new NotFoundException("Data tapılmadı");
            if (deliveryPoint.IsActive == true)
            {
                deliveryPoint.IsActive = false;
            }
            else { deliveryPoint.IsActive = true; }
            _deliveryPointRepository.Update(deliveryPoint);
            _deliveryPointRepository.Save();
        }

        public void Update(DeliveryPointUpdateDto deliveryPointUpdateDto)
        {
            DeliveryPoint deliveryPoint = _deliveryPointRepository.Get(p => p.Id == deliveryPointUpdateDto.deliveryPointGetDto.Id);
            if (deliveryPoint is null)
                throw new NotFoundException("Data tapılmadı");
            deliveryPoint.PackageCapasity = deliveryPointUpdateDto.deliveryPointPostDto.PackageCapasity;
            deliveryPoint.Adress = deliveryPointUpdateDto.deliveryPointPostDto.Adress;
            deliveryPoint.Name = deliveryPointUpdateDto.deliveryPointPostDto.Name;
            deliveryPoint.City = deliveryPointUpdateDto.deliveryPointPostDto.City;
            deliveryPoint.CountryId = deliveryPointUpdateDto.deliveryPointPostDto.CountryId;
            deliveryPoint.BranchId = deliveryPointUpdateDto.deliveryPointPostDto.BranchId;
            _deliveryPointRepository.Update(deliveryPoint);
            _deliveryPointRepository.Save();
        }
    }
}
