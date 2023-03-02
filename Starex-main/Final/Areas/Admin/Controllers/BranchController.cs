using Bussiness.Services.Abstract;
using Entities.DTOs.BranchDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly ICountryService _countryService;

        public BranchController(IBranchService branchService, ICountryService countryService)
        {
            _branchService = branchService;
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            ViewBag.countries = _countryService.GetAll();
            List<BranchGetDto> list = _branchService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = _countryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(BranchPostDto branchPostDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.countries = _countryService.GetAll();
                return View(branchPostDto);
            }
            _branchService.Create(branchPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _branchService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _branchService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.countries = _countryService.GetAll();
            BranchUpdateDto branchUpdateDto = new BranchUpdateDto();
            branchUpdateDto.branchGetDto = _branchService.GetById(id);
            if (branchUpdateDto.branchGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(branchUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(BranchUpdateDto branchUpdateDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.countries = _countryService.GetAll();
            //    return View(branchUpdateDto);
            //}
            _branchService.Update(branchUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
