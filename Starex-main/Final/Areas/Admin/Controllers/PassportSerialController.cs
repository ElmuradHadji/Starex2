using Bussiness.Services.Abstract;
using Core.Entities.DTOs.PassportSerialDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PassportSerialController : Controller
    {
        private readonly IPassportSerialService _passportSerialService;

        public PassportSerialController(IPassportSerialService passportSerialService)
        {
            _passportSerialService = passportSerialService;
        }

        public IActionResult Index()
        {
            List<PassportSerialGetDto> list = _passportSerialService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PassportSerialPostDto passportSerialPostDto)
        {

            _passportSerialService.Create(passportSerialPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _passportSerialService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            PassportSerialUpdateDto passportSerialUpdateDto = new PassportSerialUpdateDto();
            passportSerialUpdateDto.passportSerialGetDto = _passportSerialService.GetById(id);
            if (passportSerialUpdateDto.passportSerialGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(passportSerialUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PassportSerialUpdateDto passportSerialUpdateDto)
        {
            _passportSerialService.Update(passportSerialUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
