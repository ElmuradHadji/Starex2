using Bussiness.Services.Abstract;
using Entities.DTOs.FAQDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class FAQController : Controller
    {
        private readonly IFAQService _FAQService;
        private readonly IFAQCategoryService _FAQCategoryService;

        public FAQController(IFAQService fAQService, IFAQCategoryService fAQCategoryService)
        {
            _FAQService = fAQService;
            _FAQCategoryService = fAQCategoryService;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _FAQCategoryService.GetAll();
            List<FAQGetDto> list = _FAQService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories=_FAQCategoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(FAQPostDto FAQPostDto)
        {
            _FAQService.Create(FAQPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _FAQService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _FAQService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Categories = _FAQCategoryService.GetAll();
            FAQUpdateDto FAQUpdateDto = new FAQUpdateDto();
            FAQUpdateDto.FAQGetDto = _FAQService.GetById(id);
            if (FAQUpdateDto.FAQGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(FAQUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(FAQUpdateDto FAQUpdateDto)
        {
            _FAQService.Update(FAQUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
