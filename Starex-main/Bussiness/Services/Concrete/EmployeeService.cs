using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.UserDTOs;
using DataAccess.Repositories.Abstarct;
using DataAccess.Repositories.Conctrete.EF;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.FAQCategoryDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bussiness.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        public async Task CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name="Admin"});
            await _roleManager.CreateAsync(new IdentityRole { Name="User"});
            await _roleManager.CreateAsync(new IdentityRole { Name="WareHouseAdmin"});
            await _roleManager.CreateAsync(new IdentityRole { Name="Branch"});
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AdminGetDto> GetAll()
        {
            List<AdminGetDto> list = new List<AdminGetDto>();
            return _employeeRepository.GetAll().Count is not 0 ? _mapper.Map<List<AdminGetDto>>(_employeeRepository.GetAll()) : list;
        }

        public AdminGetDto GetById(string id)
        {
            AdminGetDto adminGetDto = new AdminGetDto();
            if (_employeeRepository.Get(p => p.Id == id) is not null)
            {
                adminGetDto = _mapper.Map<AdminGetDto>(_employeeRepository.Get(p => p.Id == id));

            }
            return adminGetDto;
        }
        public AdminGetDto GetByName(string name)
        {
            AdminGetDto adminGetDto = new AdminGetDto();
            if (_employeeRepository.Get(p => p.UserName.ToLower() == name.ToLower()) is not null)
            {
                adminGetDto = _mapper.Map<AdminGetDto>(_employeeRepository.Get(p => p.UserName.ToLower() == name.ToLower()));

            }
            return adminGetDto;
        }



        public void Login()
        {
            throw new NotImplementedException();
        }

        public async Task Register(AdminRegisterDto adminRegisterDto)
        {
            
            AppUser user = _mapper.Map<AppUser>(adminRegisterDto);
            user.UserName = user.UserName.ToLower();

            var Result = await _userManager.CreateAsync(user, adminRegisterDto.Password);
            
            var Result1 = await _userManager.AddToRoleAsync(user, adminRegisterDto.Role);
            //if (!Result1.Succeeded)
            //{
            //    foreach (var error in Result1.Errors)
            //    {
            //        ModelState.AddModelError("", error.Description);
            //    }
            //    return View(registerVM);
            //}
            //return RedirectToAction(nameof(Login));
        }

        public void Update(AboutUpdateDto aboutUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
