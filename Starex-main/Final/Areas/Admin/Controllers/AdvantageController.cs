using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.Utilities.Extentions;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.AdvantageDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AdvantageController : Controller
    {
        private readonly IAdvantageService _advantageService;

        public AdvantageController(IAdvantageService advantageService)
        {
            _advantageService = advantageService;
        }

        public IActionResult Index()
        {
            List<AdvantageGetDto> list = _advantageService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdvantagePostDto advantagePostDto)
        {
            if (!advantagePostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(advantagePostDto);
            }
            if (!advantagePostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(advantagePostDto);
            }
            _advantageService.Create(advantagePostDto);
            return RedirectToAction (nameof(Index));
        }
        public IActionResult Delete(int id) 
        { 
            _advantageService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _advantageService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            AdvantageUpdateDto advantageUpdateDto = new AdvantageUpdateDto();
            advantageUpdateDto.advantageGetDto = _advantageService.GetById(id);
            if (advantageUpdateDto.advantageGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(advantageUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(AdvantageUpdateDto advantageUpdateDto)
        {
            if (!advantageUpdateDto.advantagePostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(advantageUpdateDto);
            }
            if (!advantageUpdateDto.advantagePostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(advantageUpdateDto);
            }
            _advantageService.Update(advantageUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
