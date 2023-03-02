using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.DAL.Repositories.Abstract;
using Core.Entities.Concrete;
using Core.DAL.Repositories.Concrete;
using DataAccess;
using DataAccess.Repositories.Abstarct;
using DataAccess.Repositories.Conctrete.EF;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using System.Reflection;
using Bussiness.Services.Concrete.Bussiness.Services.Concrete;

namespace Bussiness.Utilities.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddIdentity<AppUser,IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllers().AddFluentValidation(option => {
                option.ImplicitlyValidateChildProperties=true;
                option.ImplicitlyValidateRootCollectionElements=true;
                option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            }) ;


            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAdvantageRepository, AdvantageRepository>();
            services.AddScoped<IAdvantageService, AdvantageService>();
            services.AddScoped<IFAQCategoryService, FAQCategoryService>();
            services.AddScoped<IFAQCategoryRepository, FAQCategoryRepository>();
            services.AddScoped<IFAQRepository, FAQRepository>();
            services.AddScoped<IFAQService, FAQService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IPassportSerialRepository, PassportSerialRepository>();
            services.AddScoped<IPassportSerialService, PassportSerialService>();
            services.AddScoped<IPhoneNumberPrefixRepository, PhoneNumberPrefixRepository>();
            services.AddScoped<IPhoneNumberPrefixService, PhoneNumberPrefixService>();
            services.AddScoped<ISocialRepository,SocialRepository>();
            services.AddScoped<ISocialService, SocialService>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IPackageStatusRepository, PackageStatusRepository>();
            services.AddScoped<IPackageStatusService, PackageStatusService>();
            services.AddScoped<IWareHouseRepository, WareHouseRepository>();
            services.AddScoped<IWareHouseService, WareHouseService>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IDeliveryPointRepository, DeliveryPointRepository>();
            services.AddScoped<IDeliveryPointService, DeliveryPointService>();
            services.AddScoped<IPricingRepository, PricingRepository>();
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageService, PackageService>();



            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.RequireUniqueEmail = false;
            });

            return services;
        }
    }
}
