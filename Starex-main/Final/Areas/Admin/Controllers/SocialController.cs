using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.Entities.DTOs.SocialDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SocialController : Controller
    {
        private readonly ISocialService _socialService;
        private readonly ISettingService _settingService;

        public SocialController(ISocialService socialService, ISettingService settingService)
        {
            _socialService = socialService;
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            List<SocialGetDto> list = _socialService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.setting = _settingService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(SocialPostDto socialPostDto)
        {

            _socialService.Create(socialPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _socialService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _socialService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            SocialUpdateDto socialUpdateDto = new SocialUpdateDto();
            socialUpdateDto.socialGetDto = _socialService.GetById(id);
            if (socialUpdateDto.socialGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(socialUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(SocialUpdateDto socialUpdateDto)
        {
            _socialService.Update(socialUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
