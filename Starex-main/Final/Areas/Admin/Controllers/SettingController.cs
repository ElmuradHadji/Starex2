using Bussiness.Services.Abstract;
using Core.Entities.DTOs.SettingDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            List<SettingGetDto> list = _settingService.GetAll();
            return View(list);
        }
        
        
        [HttpGet]
        public IActionResult Update(int id)
        {
            SettingUpdateDto settingUpdateDto = new SettingUpdateDto();
            settingUpdateDto.Logo = _settingService.GetById(id).Logo;
            settingUpdateDto.Adress = _settingService.GetById(id).Adress;
            settingUpdateDto.Phone = _settingService.GetById(id).Phone;
            settingUpdateDto.Id=id;
            if (settingUpdateDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(settingUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(SettingUpdateDto settingUpdateDto)
        {
            _settingService.Update(settingUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
