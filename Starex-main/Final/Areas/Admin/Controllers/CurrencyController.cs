using Bussiness.Services.Abstract;
using Entities.DTOs.CurrencyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            List<CurrencyGetDto> list = _currencyService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CurrencyPostDto currencyPostDto)
        {
            _currencyService.Create(currencyPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _currencyService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CurrencyUpdateDto currencyUpdateDto = new CurrencyUpdateDto();
            currencyUpdateDto.currencyGetDto = _currencyService.GetById(id);
            if (currencyUpdateDto.currencyGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(currencyUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(CurrencyUpdateDto currencyUpdateDto)
        {
            _currencyService.Update(currencyUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
