using Bussiness.Services.Abstract;
using Entities.DTOs.DeliveryPointDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DeliveryPointController : Controller
    {
        private readonly IDeliveryPointService _deliveryPointService;
        private readonly ICountryService _countryService;
        private readonly IBranchService _branchService;

        public DeliveryPointController(IDeliveryPointService deliveryPointService, ICountryService countryService, IBranchService branchService)
        {
            _deliveryPointService = deliveryPointService;
            _countryService = countryService;
            _branchService = branchService;
        }

        public IActionResult Index()
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.branches = _branchService.GetAll();
            List<DeliveryPointGetDto> list = _deliveryPointService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.branches = _branchService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(DeliveryPointPostDto deliveryPointPostDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.countries = _countryService.GetAll();
                ViewBag.branches = _branchService.GetAll();
                return View(deliveryPointPostDto);
            }
            _deliveryPointService.Create(deliveryPointPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _deliveryPointService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ModifyActivationStatus(int id)
        {
            _deliveryPointService.ModifyActivation(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.countries = _countryService.GetAll();
            ViewBag.branches = _branchService.GetAll();
            DeliveryPointUpdateDto deliveryPointUpdateDto = new DeliveryPointUpdateDto();
            deliveryPointUpdateDto.deliveryPointGetDto = _deliveryPointService.GetById(id);
            if (deliveryPointUpdateDto.deliveryPointGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(deliveryPointUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(DeliveryPointUpdateDto deliveryPointUpdateDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.countries = _countryService.GetAll();
            //    ViewBag.branches=_branchService.GetAll();
            //    return View(deliveryPointUpdateDto);
            //}
            _deliveryPointService.Update(deliveryPointUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
