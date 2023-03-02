using Bussiness.Services.Abstract;
using DataAccess;
using Entities.DTOs.OrderForMeDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderForMeService _orderService;
        private readonly ICurrencyService _currencyService;
        private readonly IOrderStatusService _orderStatusService;
        private readonly IWareHouseService _wareHouseService;
        private readonly AppDbContext _context;

        public OrderController(IOrderForMeService orderService, AppDbContext context, ICurrencyService currencyService, IOrderStatusService orderStatusService, IWareHouseService wareHouseService)
        {
            _orderService = orderService;
            _context = context;
            _currencyService = currencyService;
            _orderStatusService = orderStatusService;
            _wareHouseService = wareHouseService;
        }

        public IActionResult Index()
        {
            //int? id = _context.Users.Where(p => p.Name == User.Identity.Name).FirstOrDefault().WareHouseId;
            ViewBag.statuses = _orderStatusService.GetAll();

            ViewBag.currencies = _currencyService.GetAll();
            List<OrderForMeGetDto> list = new List<OrderForMeGetDto>();
            list = _orderService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.currencies = _currencyService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderForMePostDto orderPostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderPostDto);
            }
            _orderService.Create(orderPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.statuses = _orderStatusService.GetAll();
            ViewBag.currencies = _currencyService.GetAll();
            ViewBag.wareHouses = _wareHouseService.GetAll();
            OrderForMeUpdateDto orderUpdateDto = new OrderForMeUpdateDto();
            orderUpdateDto.orderForMeGetDto = _orderService.GetById(id);
            if (orderUpdateDto.orderForMeGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(orderUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(OrderForMeUpdateDto orderUpdateDto)
        {
            //orderGetDto orderGetDto= _orderService.GetById(orderUpdateDto.orderGetDto.Id);
            //orderUpdateDto.orderGetDto = orderGetDto;
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.statuses = _orderStatusService.GetAll();
            //    ViewBag.currencies = _currencyService.GetAll();
            //    ViewBag.wareHouses = _wareHouseService.GetAll();
            //    return View(orderUpdateDto);
            //}
            _orderService.Update(orderUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
