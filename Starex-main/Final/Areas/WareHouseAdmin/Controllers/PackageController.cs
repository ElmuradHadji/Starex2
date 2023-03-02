using Bussiness.Services.Abstract;
using DataAccess;
using Entities.DTOs.PackageDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.packageAdmin.Controllers
{
    [Area("WareHouseAdmin")]
    [Authorize(Roles = "WareHouseAdmin")]

    public class PackageController : Controller
    {
        private readonly IPackageService _packageService;
        private readonly ICurrencyService _currencyService;
        private readonly IPackageStatusService _PackageStatusService;
        private readonly IWareHouseService _wareHouseService;
        private readonly AppDbContext _context;

        public PackageController(IPackageService packageService, AppDbContext context, ICurrencyService currencyService, IPackageStatusService packageStatusService, IWareHouseService wareHouseService)
        {
            _packageService = packageService;
            _context = context;
            _currencyService = currencyService;
            _PackageStatusService = packageStatusService;
            _wareHouseService = wareHouseService;
        }

        public IActionResult Index()
        {
            int? id  = _context.Users.Where(p => p.Name == User.Identity.Name).FirstOrDefault().WareHouseId;
            ViewBag.statuses = _PackageStatusService.GetAll();
            
            ViewBag.currencies = _currencyService.GetAll();
            List<PackageGetDto> list = new List<PackageGetDto>();
            list = _packageService.GetAllByWareHouse(id);
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.currencies = _currencyService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PackagePostDto packagePostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(packagePostDto);
            }
            _packageService.Create(packagePostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _packageService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.statuses=_PackageStatusService.GetAll();
            ViewBag.currencies = _currencyService.GetAll();
            ViewBag.wareHouses= _wareHouseService.GetAll();
            PackageUpdateDto packageUpdateDto = new PackageUpdateDto();
            packageUpdateDto.packageGetDto = _packageService.GetById(id);
            if (packageUpdateDto.packageGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(packageUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PackageUpdateDto packageUpdateDto)
        {
            //PackageGetDto packageGetDto= _packageService.GetById(packageUpdateDto.packageGetDto.Id);
            //packageUpdateDto.packageGetDto = packageGetDto;
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.statuses = _PackageStatusService.GetAll();
            //    ViewBag.currencies = _currencyService.GetAll();
            //    ViewBag.wareHouses = _wareHouseService.GetAll();
            //    return View(packageUpdateDto);
            //}
            _packageService.Update(packageUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
