using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Models;
using System.Diagnostics;

namespace ProjectKMITL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {  
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FindCafeteria()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Work()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult PhraThepCafeteria()
        {
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "1";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "2";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "3";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "4";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "5";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}