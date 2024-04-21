using data_and_repo_pattern.helper.MenuApiRequest;
using data_and_repo_pattern.helper.OrderApiRequest;
using data_and_repo_pattern.helper.UserApiRequest;
using data_and_repo_pattern.ViewModel;
using food_order_system_admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace food_order_system_admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IOrderApiRequest _iorder;
        IMenuApiRequest _imenu;
        IUserApiRequest _iuser;

        public HomeController(ILogger<HomeController> logger, IOrderApiRequest iorder, IMenuApiRequest imenu, IUserApiRequest iuser)
        {
            _logger = logger;
            _iorder = iorder;
            _iuser = iuser;
            _imenu = imenu;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<AdminDataViewModel> GetAdminData()
        {
            AdminDataViewModel advm = new AdminDataViewModel();
            advm.TotalMenu = await _imenu.GetTotalMenu();
            advm.TotalUsers = await _iuser.GetUserCount();
            advm.PendingOrder = await _iorder.GetPendingTotal();
            advm.DeliveredOrder = await _iorder.GetDeliveredTotal();
            return advm;
        }

        public async Task<IActionResult> _admindata()
        {
            var result = await GetAdminData();
            return PartialView("_admindata", result);
        }

    }
}