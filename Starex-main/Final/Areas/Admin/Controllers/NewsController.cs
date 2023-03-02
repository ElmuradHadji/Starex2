using Bussiness.Services.Abstract;
using Core.Utilities.Extentions;
using Entities.DTOs.AdvantageDTOs;
using Entities.DTOs.NewsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            List<NewsGetDto> list = _newsService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewsPostDto newsPostDto)
        {
            if (!newsPostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(newsPostDto);
            }
            if (!newsPostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(newsPostDto);
            }
            _newsService.Create(newsPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _newsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            NewsUpdateDto newsUpdateDto = new NewsUpdateDto();
            newsUpdateDto.newsGetDto = _newsService.GetById(id);
            if (newsUpdateDto.newsGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(newsUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(NewsUpdateDto NewsUpdateDto)
        {
            _newsService.Update(NewsUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
