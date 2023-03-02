using Bussiness.Services.Abstract;
using Entities.DTOs.WareHouseDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _wareHouseService;
        private readonly ICountryService _countryService;

        public WareHouseController(IWareHouseService wareHouseService, ICountryService countryService)
        {
            _wareHouseService = wareHouseService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            ViewBag.countries=_countryService.GetAll();
            List<WareHouseGetDto> list = _wareHouseService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = _countryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(WareHousePostDTO wareHousePostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(wareHousePostDto);
            }
            _wareHouseService.Create(wareHousePostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _wareHouseService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _wareHouseService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.countries = _countryService.GetAll();
            WareHouseUpdateDto wareHouseUpdateDto = new WareHouseUpdateDto();
            wareHouseUpdateDto.wareHouseGetDto = _wareHouseService.GetById(id);
            if (wareHouseUpdateDto.wareHouseGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(wareHouseUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(WareHouseUpdateDto wareHouseUpdateDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.countries = _countryService.GetAll();
            //    return View(wareHouseUpdateDto);
            //}
            _wareHouseService.Update(wareHouseUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
