using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Models;

namespace ProjectKMITL.Controllers.Home
{
    [Route("Home/[controller]/[action]")]
    public class FindCafeteriaController : Controller
    {
        // GET: FindCafeteria
        [Route("/Home/FindCafeteria")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Cafeteria c1 = new Cafeteria();
            c1.CafeteriaImg = "Restaurant/b1.png";
            c1.Name = "โรงอาหารพระเทพ";
            c1.Location = "3 ถ. ฉลองกรุง แขวงลำปลาทิว เขตลาดกระบัง กรุงเทพมหานคร 10520 (ใกล้ตึกพระเทพ, ตึก ECC)";
            c1.Image = "LocationMap/c1.png";

            var c2 = new Cafeteria();
            c2.CafeteriaImg = "Restaurant/b2.png";
            c2.Name = "โรงอาหาร A";
            c2.Location = "ECC";
            c2.Image = "LocationMap/c2.png";

            var c3 = new Cafeteria();
            c3.CafeteriaImg = "Restaurant/b3.png";
            c3.Name = "โรงอาหารถิ่นชงโค";
            c3.Location = "ECC";
            c3.Image = "LocationMap/c3.png";

            var c4 = new Cafeteria();
            c4.CafeteriaImg = "Restaurant/b4.png";
            c4.Name = "โรงอาหาร C";
            c4.Location = "ECC";
            c4.Image = "LocationMap/c4.png";


            List<Cafeteria> allCafeteria = new List<Cafeteria>();
            allCafeteria.Add(c1);
            allCafeteria.Add(c2);
            allCafeteria.Add(c3);
            allCafeteria.Add(c4);

            return View(allCafeteria);
        }

        public IActionResult Restaurant()
        {
            return View();
        }
    }
}
