using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectKMITL.Models;

namespace ProjectKMITL.Controllers
{
    [Route("Home/FindCafeteria/[controller]/[action]")]
    public class RestaurantController : Controller
    {
        public static string name = null;

        [Route("Home/FindCafeteria/[controller]/{name}")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Cafeteria") == null)
            {
                RedirectToAction("Index", "Home");
            }
            else
            {
                name = HttpContext.Session.GetString("Cafeteria");
            }
            return View();
        }
    }
}
/*
             if (HttpContext.Session.GetString("Restaurant") != null)
            {
                name = HttpContext.Session.GetString("Restaurant");
            }

            if (name == null)
            {
                return RedirectToAction("Index", "Home");
            }
 */