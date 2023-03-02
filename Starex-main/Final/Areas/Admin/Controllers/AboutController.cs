using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using Core.Utilities.Extentions;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            List<AboutGetDto> list = _aboutService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            AboutUpdateDto aboutUpdateDto = new AboutUpdateDto
            {
                aboutGetDto = _aboutService.GetById(id)
            }; 
            if (aboutUpdateDto.aboutGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            
            return View(aboutUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(AboutUpdateDto aboutUpdateDto)
        {
            if (!aboutUpdateDto.aboutPostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(aboutUpdateDto);
            }
            if (!aboutUpdateDto.aboutPostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(aboutUpdateDto);
            }
            //var result= _aboutService.Create(aboutPostDto);
            _aboutService.Update(aboutUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
