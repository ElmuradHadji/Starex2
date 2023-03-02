using Bussiness.Services.Abstract;
using Entities.DTOs.PackageStatusDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class PackageStatusController : Controller
    {
        private readonly IPackageStatusService _packageStatusService;

        public PackageStatusController(IPackageStatusService packageStatusService)
        {
            _packageStatusService = packageStatusService;
        }

        public IActionResult Index()
        {
            List<PackageStatusGetDto> list = _packageStatusService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PackageStatusPostDto packageStatusPostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(packageStatusPostDto);
            }
            _packageStatusService.Create(packageStatusPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _packageStatusService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            PackageStatusUpdateDto packageStatusUpdateDto = new PackageStatusUpdateDto();
            packageStatusUpdateDto.packageStatusGetDto = _packageStatusService.GetById(id);
            if (packageStatusUpdateDto.packageStatusGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(packageStatusUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(PackageStatusUpdateDto packageStatusUpdateDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    packageStatusUpdateDto.packageStatusGetDto = _packageStatusService.GetById(packageStatusUpdateDto.packageStatusGetDto.Id);
            //    return View(packageStatusUpdateDto);
            //}
            _packageStatusService.Update(packageStatusUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
