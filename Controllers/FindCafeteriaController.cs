using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Models;

namespace ProjectKMITL.Controllers
{
    public class FindCafeteriaController : Controller
    {
        // GET: FindCafeteria
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Cafeteria c1 = new Cafeteria();
            c1.Name = "โรงอาหารพระเทพ";
            c1.Location = "3 ถ. ฉลองกรุง แขวงลำปลาทิว เขตลาดกระบัง กรุงเทพมหานคร 10520 (ใกล้ตึกพระเทพ, ตึก ECC)";
            c1.Image = "c1.png";

            var c2 = new Cafeteria();
            c2.Name = "โรงอาหาร A";
            c2.Location = "ECC";
            c2.Image = "c2.png";

            var c3 = new Cafeteria();
            c3.Name = "โรงอาหารถิ่นชงโค";
            c3.Location = "ECC";
            c3.Image = "c3.png";

            var c4 = new Cafeteria();
            c4.Name = "โรงอาหาร C";
            c4.Location = "ECC";
            c4.Image = "c4.png";


            List<Cafeteria> allCafeteria = new List<Cafeteria>();
            allCafeteria.Add(c1);
            allCafeteria.Add(c2);
            allCafeteria.Add(c3);
            allCafeteria.Add(c4);

            return View(allCafeteria);
        }

        // GET: FindCafeteria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FindCafeteria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FindCafeteria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FindCafeteria/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FindCafeteria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FindCafeteria/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FindCafeteria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
