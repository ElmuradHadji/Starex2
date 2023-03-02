using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.Utilities.Extentions;
using Entities.DTOs.CountryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ICurrencyService _currencyService;

        public CountryController(ICountryService countryService, ICurrencyService currencyService)
        {
            _countryService = countryService;
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            ViewBag.Currencies = _currencyService.GetAll();
            List<CountryGetDto> list = _countryService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Currencies = _currencyService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CountryPostDto countryPostDto)
        {
            if (!countryPostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(countryPostDto);
            }
            if (!countryPostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(countryPostDto);
            }
            _countryService.Create(countryPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _countryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Currencies = _currencyService.GetAll();
            CountryUpdateDto countryUpdateDto = new CountryUpdateDto();
            countryUpdateDto.countryGetDto = _countryService.GetById(id);
            if (countryUpdateDto.countryGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(countryUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(CountryUpdateDto countryUpdateDto)
        {
            if (countryUpdateDto.countryPostDto.formFile is not null)
            {
                if (!countryUpdateDto.countryPostDto.formFile.IsImage())
                {
                    ModelState.AddModelError("formFile", "Yanlış Format!");
                    return View(countryUpdateDto);
                }
                if (!countryUpdateDto.countryPostDto.formFile.IsSizeOk(2))
                {
                    ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                    return View(countryUpdateDto);
                }
            }
            _countryService.Update(countryUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
