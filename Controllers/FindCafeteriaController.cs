using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectKMITL.Models;
using System.Web;
using ProjectKMITL.Data;

namespace ProjectKMITL.Controllers
{
    [Route("/[controller]/[action]")]
    public class FindCafeteriaController : Controller
    {
        private readonly OrderDbContext _context;

        public FindCafeteriaController(OrderDbContext context)
        {
            _context = context;

        }

        // GET: FindCafeteria
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("Cafeteria") != null)
            {
                HttpContext.Session.Remove("Cafeteria");
            }
            
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Cafeteria c1 = new Cafeteria();
            c1.CafeteriaImg = "Cafeteria/b1.png";
            c1.Name = "โรงอาหารพระเทพ";
            c1.Location = "3 ถ. ฉลองกรุง แขวงลำปลาทิว เขตลาดกระบัง กรุงเทพมหานคร 10520 (ข้างตึกพระเทพ, ใกล้ตึก ECC)";
            c1.Image = "LocationMap/c1.png";
            c1.Destination = "PhraThepCafeteria";

            var c2 = new Cafeteria();
            c2.CafeteriaImg = "Cafeteria/b2.png";
            c2.Name = "โรงอาหาร A";
            c2.Location = "3 ถ. ฉลองกรุง แขวงลาดกระบัง เขตลาดกระบัง กรุงเทพมหานคร 10520 (ข้างตึก A, ใกล้ตึก HM)";
            c2.Image = "LocationMap/c2.png";
            c2.Destination = "CafeteriaA";

            var c3 = new Cafeteria();
            c3.CafeteriaImg = "Cafeteria/b3.png";
            c3.Name = "โรงอาหารถิ่นชงโค";
            c3.Location = "3 ถ. ฉลองกรุง แขวงลาดกระบัง เขตลาดกระบัง กรุงเทพมหานคร 10520 (ใกล้ตึกวิศวกรรมการวัดคุมม)";
            c3.Image = "LocationMap/c3.png";
            c3.Destination = "ThinChongKhoCafeteria";

            var c4 = new Cafeteria();
            c4.CafeteriaImg = "Cafeteria/b4.png";
            c4.Name = "โรงอาหาร C";
            c4.Location = "3 ถนน ฉลองกรุง แขวงลาดกระบัง เขตลาดกระบัง กรุงเทพมหานคร 10520 (ตรงข้ามตึกโหล)";
            c4.Image = "LocationMap/c4.png";
            c4.Destination = "CafeteriaC";


            List<Cafeteria> allCafeteria = new List<Cafeteria>();
            allCafeteria.Add(c1);
            allCafeteria.Add(c2);
            allCafeteria.Add(c3);
            allCafeteria.Add(c4);

            return View(allCafeteria);
        }

        public IActionResult PhraThepCafeteria()
        {
            HttpContext.Session.SetString("Cafeteria", "PhraThepCafeteria");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "kanom.jpg";
            res1.detail = "ร้านไก่ทอดเทคโน";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "kanom.jpg";
            res2.detail = "ร้านส้มตำ";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "kanom.jpg";
            res3.detail = "ร้านลุงหนวด";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "kanom.jpg";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "kanom.jpg";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }
        public IActionResult CafeteriaA()
        {
            HttpContext.Session.SetString("Cafeteria", "CafeteriaA");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "kanom.jpg";
            res1.detail = "ร้านไก่ทอดเทคโน";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "kanom.jpg";
            res2.detail = "ร้านส้มตำ";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "kanom.jpg";
            res3.detail = "ร้านลุงหนวด";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "kanom.jpg";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "kanom.jpg";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }

        public IActionResult CafeteriaC()
        {
            HttpContext.Session.SetString("Cafeteria", "CafeteriaC");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "kanom.jpg";
            res1.detail = "ร้านไก่ทอดเทคโน";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "kanom.jpg";
            res2.detail = "ร้านส้มตำ";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "kanom.jpg";
            res3.detail = "ร้านลุงหนวด";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "kanom.jpg";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "kanom.jpg";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }

        public IActionResult ThinChongKhoCafeteria()
        {
            HttpContext.Session.SetString("Cafeteria", "ThinChongKhoCafeteria");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "kanom.jpg";
            res1.detail = "ร้านไก่ทอดเทคโน";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "kanom.jpg";
            res2.detail = "ร้านส้มตำ";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "kanom.jpg";
            res3.detail = "ร้านลุงหนวด";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "kanom.jpg";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "kanom.jpg";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }

        [HttpPost]
        public IActionResult SetTempData(string value)
        {
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            HttpContext.Session.SetString("Restaurant", value);
            return RedirectToAction("Restaurant","FindCafeteria" ,new { cafeteria = cafeteria, restaurant = value});
        }

        public IActionResult RestaurantPath()
        {
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            string restaurant = HttpContext.Session.GetString("Restaurant");
            return RedirectToAction("Restaurant", "FindCafeteria", new { cafeteria = cafeteria, restaurant = restaurant});
        }

        [HttpGet]
        [Route("/FindCafeteria/{cafeteria}/{restaurant}")]
        public IActionResult Restaurant(string cafeteria, string restaurant)
        {
            ViewBag.res = restaurant;
            string Head = "";
            if (cafeteria == "CafeteriaA") Head = "โรงอาหาร A";
            else if (cafeteria == "CafeteriaC") Head = "โรงอาหาร C";
            else if (cafeteria == "PhraThepCafeteria") Head = "โรงอาหารพระเทพ";
            else Head = "โรงอาหารถิ่นชงโค";
            ViewBag.Head = Head;
            HttpContext.Session.SetString("Head", Head);
            ViewBag.caf = cafeteria;
            

            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "kanom.jpg";
            res1.detail = "ข้าวแกงกะหรี่";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "kanom.jpg";
            res2.detail = "ข้าวไก่คาราเกะ";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "kanom.jpg";
            res3.detail = "ข้าวแกงเขียวหวาน";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "kanom.jpg";
            res4.detail = "สเต็กไก่";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "kanom.jpg";
            res5.detail = "ข้าวมันไก่";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);

            return View(allRes);
        }

        public static List<OrderListModel> ListOrder;
        [HttpPost]
        public IActionResult Cart2(string orderList, string countList, string returnUrl)
        {
            HttpContext.Session.SetString("orderList", orderList);
            HttpContext.Session.SetString("orderCount", countList);
            string[] order = orderList.Split(',');
            string[] count = countList.Split(",");
            int[] orderCount = new int[100];
            for (int i = 0; i < count.Length; i++)
            {
                int num = int.Parse(count[i]);
                orderCount[i] = num;
            }
            
            List<OrderListModel> list = new List<OrderListModel>();
            for (int i = 0; i < order.Length; i++)
            {
                OrderListModel model = new OrderListModel();
                model.name = order[i];
                model.count = orderCount[i];
                list.Add(model);
            }
            ListOrder = list;
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            string restaurant = HttpContext.Session.GetString("Restaurant");
            return RedirectToAction("Cart", "FindCafeteria" ,new {cafeteria = cafeteria, restaurant = restaurant });
        }

       
        [HttpGet]
        [Route("/FindCafeteria/{cafeteria}/{restaurant}/[action]")]
        public IActionResult Cart(string cafeteria, string restaurant)
        {   ViewBag.res = HttpContext.Session.GetString("Restaurant");
            ViewBag.Head = HttpContext.Session.GetString("Head");
            return View(ListOrder);
        }

        public IActionResult OrderedPath()
        {
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            string restaurant = HttpContext.Session.GetString("Restaurant");
            return RedirectToAction("Ordered", "FindCafeteria", new { cafeteria = cafeteria, restaurant = restaurant });
        }

        [HttpGet]
        [Route("/FindCafeteria/{cafeteria}/{restaurant}/[action]")]
        public IActionResult Ordered() {
            OrderModel model = new OrderModel();
            model.NameDepositor = HttpContext.Session.GetString("UserName");
            model.Cafeteria = HttpContext.Session.GetString("Cafeteria");
            model.Restaurant = HttpContext.Session.GetString("Restaurant");
            model.OrderList = HttpContext.Session.GetString("orderList");
            model.OrderCount = HttpContext.Session.GetString("orderCount");
            model.NameDepository = "";
            _context.Orders.Add(model);
            _context.SaveChanges();
            return View();
        }


    }
}
