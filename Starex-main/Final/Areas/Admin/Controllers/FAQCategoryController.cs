using Bussiness.Services.Abstract;
using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.FAQCategoryDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class FAQCategoryController : Controller
    {
        private readonly IFAQCategoryService _FAQCategoryService;

        public FAQCategoryController(IFAQCategoryService fAQCategoryService)
        {
            _FAQCategoryService = fAQCategoryService;
        }

        public IActionResult Index()
        {
            List<FAQCategoryGetDto> list = _FAQCategoryService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FAQCategoryPostDto FAQCategoryPostDto)
        {
            _FAQCategoryService.Create(FAQCategoryPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _FAQCategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _FAQCategoryService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            FAQCategoryUpdateDto FAQCategoryUpdateDto = new FAQCategoryUpdateDto();
            FAQCategoryUpdateDto.FAQCategoryGetDto = _FAQCategoryService.GetById(id);
            if (FAQCategoryUpdateDto.FAQCategoryGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(FAQCategoryUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(FAQCategoryUpdateDto FAQCategoryUpdateDto)
        {
            _FAQCategoryService.Update(FAQCategoryUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
