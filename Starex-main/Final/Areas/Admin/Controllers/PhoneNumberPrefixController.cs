using Bussiness.Services.Abstract;
using Core.Entities.DTOs.PhoneNumberPrefixDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PhoneNumberPrefixController : Controller
    {
        private readonly IPhoneNumberPrefixService _phoneNumberPrefixService;

        public PhoneNumberPrefixController(IPhoneNumberPrefixService phoneNumberPrefixService)
        {
            _phoneNumberPrefixService = phoneNumberPrefixService;
        }

        public IActionResult Index()
        {
            List<PhoneNumberPrefixGetDto> list = _phoneNumberPrefixService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PhoneNumberPrefixPostDto phoneNumberPrefixPostDto)
        {

            _phoneNumberPrefixService.Create(phoneNumberPrefixPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _phoneNumberPrefixService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            PhoneNumberPrefixUpdateDto phoneNumberPrefixUpdateDto = new PhoneNumberPrefixUpdateDto();
            phoneNumberPrefixUpdateDto.phoneNumberPrefixGetDto = _phoneNumberPrefixService.GetById(id);
            if (phoneNumberPrefixUpdateDto.phoneNumberPrefixGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(phoneNumberPrefixUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PhoneNumberPrefixUpdateDto phoneNumberPrefixUpdateDto)
        {
            _phoneNumberPrefixService.Update(phoneNumberPrefixUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
