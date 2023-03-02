using Bussiness.Services.Abstract;
using Core.Entities.DTOs.GenderDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class GenderController : Controller
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        public IActionResult Index()
        {
            List<GenderGetDto> list = _genderService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(GenderPostDto GenderPostDto)
        {
            
            _genderService.Create(GenderPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _genderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            GenderUpdateDto genderUpdateDto = new GenderUpdateDto();
            genderUpdateDto.genderGetDto = _genderService.GetById(id);
            if (genderUpdateDto.genderGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(genderUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(GenderUpdateDto genderUpdateDto)
        {
            _genderService.Update(genderUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
