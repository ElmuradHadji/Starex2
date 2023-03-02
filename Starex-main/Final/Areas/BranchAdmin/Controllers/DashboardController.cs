using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final.Areas.BranchAdmin.Controllers
{
    [Area("BranchAdmin")]
    [Authorize(Roles = "BranchAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
