using Bussiness.Services.Abstract;
using Entities.DTOs.OrderStatusDTOs;
using Entities.DTOs.PackageStatusDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class OrderStatusController : Controller
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        public IActionResult Index()
        {
            List<OrderStatusGetDto> list = _orderStatusService.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(OrderStatusPostDto orderStatusPostDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderStatusPostDto);
            }
            _orderStatusService.Create(orderStatusPostDto);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _orderStatusService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            OrderStatusUpdateDto orderStatusUpdateDto = new OrderStatusUpdateDto();
            orderStatusUpdateDto.orderStatusGetDto = _orderStatusService.GetById(id);
            if (orderStatusUpdateDto.orderStatusGetDto.Id == 0) { return RedirectToAction("NotFound", "Error"); }
            return View(orderStatusUpdateDto);
        }
        [HttpPost]
        public IActionResult Update(OrderStatusUpdateDto orderStatusUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return View(orderStatusUpdateDto.orderStatusPostDto);
            }
            _orderStatusService.Update(orderStatusUpdateDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
