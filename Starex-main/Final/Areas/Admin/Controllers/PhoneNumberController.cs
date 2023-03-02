using Bussiness.Services.Abstract;
using Entities.DTOs.PhoneNumberDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PhoneNumberController : Controller
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        public IActionResult Index()
        {
            List<PhoneNumberGetDto> list = _phoneNumberService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhoneNumberPostDto phoneNumberPostDto)
        {
            _phoneNumberService.Create(phoneNumberPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _phoneNumberService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            PhoneNumberUpdateDto phoneNumberUpdateDto = new PhoneNumberUpdateDto();
            phoneNumberUpdateDto.phoneNumberGetDto = _phoneNumberService.GetById(id);
            if (phoneNumberUpdateDto.phoneNumberGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(phoneNumberUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PhoneNumberUpdateDto phoneNumberUpdateDto)
        {
            _phoneNumberService.Update(phoneNumberUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
