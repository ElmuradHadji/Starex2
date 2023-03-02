using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.DTOs.GenderDTOs;
using Core.Entities.DTOs.PassportSerialDTOs;
using Core.Entities.DTOs.PhoneNumberPrefixDTOs;
using Core.Entities.DTOs.SettingDTOs;
using Core.Entities.DTOs.SocialDTOs;
using Core.Entities.DTOs.UserDTOs;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.BranchDTOs;
using Entities.DTOs.CountryDTOs;
using Entities.DTOs.CurrencyDTOs;
using Entities.DTOs.DeliveryPointDTOs;
using Entities.DTOs.FAQCategoryDTOs;
using Entities.DTOs.FAQDTOs;
using Entities.DTOs.NewsDTOs;
using Entities.DTOs.OrderStatusDTOs;
using Entities.DTOs.PackageDTOs;
using Entities.DTOs.PackageStatusDTOs;
using Entities.DTOs.PhoneNumberDTOs;
using Entities.DTOs.PricingDTOs;
using Entities.DTOs.ServiceDTOs;
using Entities.DTOs.WareHouseDTOs;

namespace Bussiness.Utilities.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AboutPostDto, About>();
            CreateMap<About, AboutGetDto>();
            CreateMap<AdvantagePostDto, Advantage>();
            CreateMap<Advantage, AdvantageGetDto>();
            CreateMap<FAQCategory, FAQCategoryGetDto>();
            CreateMap<FAQCategoryPostDto, FAQCategory>();
            CreateMap<FAQPostDto, FAQ>();
            CreateMap<FAQ, FAQGetDto>();
            CreateMap<NewsPostDto, News>();
            CreateMap<News, NewsGetDto>();
            CreateMap<ServicePostDto, Service>();
            CreateMap<Service, ServiceGetDto>();
            CreateMap<GenderPostDto, Gender>();
            CreateMap<Gender, GenderGetDto>();
            CreateMap<PassportSerialPostDto, PassportSerial>();
            CreateMap<PassportSerial, PassportSerialGetDto>();
            CreateMap<PhoneNumberPrefixPostDto, PhoneNumberPrefix>();
            CreateMap<PhoneNumberPrefix, PhoneNumberPrefixGetDto>();
            CreateMap<SocialPostDto, Social>();
            CreateMap<Social, SocialGetDto>();
            CreateMap<SettingUpdateDto, Setting>();
            CreateMap<Setting, SettingGetDto>();
            CreateMap<CurrencyPostDto, Currency>();
            CreateMap<Currency, CurrencyGetDto>();
            CreateMap<CountryPostDto, Country>();
            CreateMap<Country, CountryGetDto>();
            CreateMap<PhoneNumberPostDto, PhoneNumber>();
            CreateMap<PhoneNumber, PhoneNumberGetDto>();
            CreateMap<OrderStatusPostDto, OrderStatus>();
            CreateMap<OrderStatus, OrderStatusGetDto>();
            CreateMap<PackageStatusPostDto, PackageStatus>();
            CreateMap<PackageStatus, PackageStatusGetDto>();
            CreateMap<WareHousePostDTO, WareHouse>();
            CreateMap<WareHouse, WareHouseGetDto>();
            CreateMap<BranchPostDto, Branch>();
            CreateMap<Branch, BranchGetDto>();
            CreateMap<DeliveryPointPostDto, DeliveryPoint>();
            CreateMap<DeliveryPoint, DeliveryPointGetDto>();
            CreateMap<PricingPostDto, Pricing>();
            CreateMap<Pricing, PricingGetDto>();
            CreateMap<AdminRegisterDto, AppUser>();
            CreateMap<AppUser, AdminGetDto>();
            CreateMap<PackagePostDto, Package>();
            CreateMap<Package, PackageGetDto>();




        }
    }
}
