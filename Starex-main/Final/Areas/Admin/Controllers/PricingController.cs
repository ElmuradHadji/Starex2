using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Entities.DTOs.PricingDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PricingController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly ICurrencyService _currencyService;
        private readonly IPricingService _pricingService;

        public PricingController(IPricingService pricingService, ICountryService countryService, ICurrencyService currencyService)
        {
            _pricingService = pricingService;
            _countryService = countryService;
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.currencies = _currencyService.GetAll();
            List<PricingGetDto> list = _pricingService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.currencies = _currencyService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PricingPostDto pricingPostDto)
        {
            _pricingService.Create(pricingPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _pricingService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.currencies = _currencyService.GetAll();
            PricingUpdateDto pricingUpdateDto = new PricingUpdateDto();
            pricingUpdateDto.pricingGetDto = _pricingService.GetById(id);
            if (pricingUpdateDto.pricingGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(pricingUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PricingUpdateDto pricingUpdateDto)
        {
            _pricingService.Update(pricingUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
