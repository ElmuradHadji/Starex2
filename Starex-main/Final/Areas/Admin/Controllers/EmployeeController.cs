using AutoMapper;
using Bussiness.Services.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Area("Admin")]
public class EmployeeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IEmployeeService employeeService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _mapper = mapper;
        _employeeService = employeeService;
    }

    public  IActionResult Index()
    {
        ViewBag.roles = _roleManager.Roles.ToList();
        List<AdminGetDto> list = new List<AdminGetDto>();
        list =_mapper.Map<List<AdminGetDto>>( _userManager.Users.ToList());
        return View(list);
    }
    public async Task<IActionResult> CreateRole()
    {
        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        await _roleManager.CreateAsync(new IdentityRole { Name = "WareHouseAdmin" });
        await _roleManager.CreateAsync(new IdentityRole { Name = "BranchAdmin" });
        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        return Json("ok");
    }
    //public async Task<IActionResult> Index()
    //{
    //    AppUser user = new AppUser
    //    {
    //        UserName = "Admin",
    //        Email = "esgerova94@gmail.com"
    //    };
    //    var result = await _userManager.CreateAsync(user, "Admin123@");
    //    if (!result.Succeeded)
    //    {
    //        foreach (var item in result.Errors)
    //        {
    //            return Json(item.Description);
    //        }

    //    }
    //    var result2 = await _userManager.AddToRoleAsync(user, "admin");
    //    if (!result2.Succeeded)
    //    {
    //        return Json("errror");

    //    }
    //    return Json("ok");
    //}
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(AdminLoginDto login)
    {
        AppUser user = await _userManager.FindByNameAsync(login.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "UserName or Password incorrect");
            return View(login);
        }
        var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "UserName or Password incorrect");
            return View(login);
        }
        return RedirectToAction("Index", "Dashboard");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Employee");
    }


    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(AdminRegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            return View(registerDto);
        }
        if (await _userManager.FindByNameAsync(registerDto.UserName.ToLower()) is not null)
        {
            ModelState.AddModelError("", "User already exsists");
            return View(registerDto);
        }
        AppUser user = _mapper.Map<AppUser>(registerDto);
        user.UserName = user.UserName.ToLower();
        user.Adress = " ";
        user.BranchOrPointId = 0;
        user.Brithday =DateTime.Today;
        user.Email = user.UserName+ "@"+"gmail.com";
        user.FIN = "0000000";
        user.GenderId = 2;
        user.Name = user.UserName;
        user.Surname = user.UserName;
        user.PhoneNumber = " ";
        user.PassportSerialId =2;
        user.PassportSerialNumber = " ";
        var Result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!Result.Succeeded)
        {
            foreach (var error in Result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(registerDto);
        }
        var Result1 = await _userManager.AddToRoleAsync(user, "BranchAdmin");
        if (!Result1.Succeeded)
        {
            foreach (var error in Result1.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(registerDto);
        }
        return RedirectToAction(nameof(Login));
    }
}