using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final.Areas.WareHouseAdmin.Controllers
{
    [Area("WareHouseAdmin")]
    [Authorize(Roles = "WareHouseAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
