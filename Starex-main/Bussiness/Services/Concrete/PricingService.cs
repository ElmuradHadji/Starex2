namespace Bussiness.Services.Concrete
{
    using AutoMapper;
    using DataAccess.Repositories.Abstarct;
    using Entities.Concrete;
    using Entities.DTOs.PricingDTOs;
    using Core.Utilities.Exceptions;
    using Microsoft.AspNetCore.Hosting;
    using global::Bussiness.Services.Abstract;

    namespace Bussiness.Services.Concrete
    {
        public class PricingService : IPricingService
        {
            private readonly IPricingRepository _pricingRepository;
            private readonly IMapper _mapper;

            public PricingService(IPricingRepository pricingRepository, IMapper mapper )
            {
                _pricingRepository = pricingRepository;
                _mapper = mapper;
            }

            public void Create(PricingPostDto pricingPostDto)
            {
                _pricingRepository.Create(_mapper.Map<Pricing>(pricingPostDto));
                _pricingRepository.Save();
            }

            public void Delete(int id)
            {
                Pricing pricing = _pricingRepository.Get(p => p.Id == id);
                if (pricing is null)
                    throw new NotFoundException("Data tapılmadı");
                _pricingRepository.Delete(pricing);
                _pricingRepository.Save();

            }

            public List<PricingGetDto> GetAll()
            {
                List<PricingGetDto> list = new List<PricingGetDto>();
                return _pricingRepository.GetAll().Count is not 0 ? _mapper.Map<List<PricingGetDto>>(_pricingRepository.GetAll()) : list;
            }

            public  PricingGetDto GetById(int id)
            {
                PricingGetDto pricingGetDto = new PricingGetDto();
                if (_pricingRepository.Get(p => p.Id == id) is not null)
                {
                    pricingGetDto = _mapper.Map<PricingGetDto>(_pricingRepository.Get(p => p.Id == id));

                }
                return pricingGetDto;
            }

            public void Update(PricingUpdateDto pricingUpdateDto)
            {
                Pricing pricing = _pricingRepository.Get(p => p.Id == pricingUpdateDto.pricingGetDto.Id);
                if (pricing is null)
                    throw new NotFoundException("Data tapılmadı");
                pricing.MinKG = pricingUpdateDto.pricingPostDto.MinKG;
                pricing.MaxKG = pricingUpdateDto.pricingPostDto.MaxKG;
                pricing.Price = pricingUpdateDto.pricingPostDto.Price;
                pricing.CountryId = pricingUpdateDto.pricingPostDto.CountryId;
                pricing.CurrencyId = pricingUpdateDto.pricingPostDto.CurrencyId;
       
                _pricingRepository.Update(pricing);
                _pricingRepository.Save();
            }
        }
    }

}
