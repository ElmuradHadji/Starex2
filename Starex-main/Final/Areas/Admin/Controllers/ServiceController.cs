using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.Utilities.Extentions;
using Entities.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ServiceController : Controller
    {
        private readonly IServiceService _ServiceService;

        public ServiceController(IServiceService ServiceService)
        {
            _ServiceService = ServiceService;
        }

        public IActionResult Index()
        {
            List<ServiceGetDto> list = _ServiceService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicePostDto servicePostDto)
        {
            if (!servicePostDto.formFile.IsImage())
            {
                ModelState.AddModelError("formFile", "Yanlış Format!");
                return View(servicePostDto);
            }
            if (!servicePostDto.formFile.IsSizeOk(2))
            {
                ModelState.AddModelError("formFile", "2 mb-dan böyük ölçü!");
                return View(servicePostDto);
            }
            _ServiceService.Create(servicePostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _ServiceService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ServiceUpdateDto serviceUpdateDto = new ServiceUpdateDto();
            serviceUpdateDto.serviceGetDto = _ServiceService.GetById(id);
            if (serviceUpdateDto.serviceGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(serviceUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(ServiceUpdateDto ServiceUpdateDto)
        {
            _ServiceService.Update(ServiceUpdateDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _ServiceService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
