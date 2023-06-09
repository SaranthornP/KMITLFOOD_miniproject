﻿using Microsoft.AspNetCore.Http;
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
        private readonly ApplicationDBContext _users;

        public FindCafeteriaController(OrderDbContext context, ApplicationDBContext users)
        {
            _context = context;
            _users = users;
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
            res1.name = "ร้านเทคโนอินเตอร์";
            res1.img = "Restaurant\\PhraThep\\เทคโน.jpg";
            res1.detail = "ร้านเทคโนอินเตอร์";

            var res2 = new ResModel();
            res2.name = "ร้านส้มตำ";
            res2.img = "Restaurant\\PhraThep\\ป้าศรี.jpg";
            res2.detail = "ร้านป้าศรีส้มตำ";

            var res3 = new ResModel();
            res3.name = "ร้านไอหนวด";
            res3.img = "Restaurant\\PhraThep\\ร้านไอหนวด.jpg";
            res3.detail = "ร้านไอหนวด";

            var res4 = new ResModel();
            res4.name = "ร้านมามาก๋วยเตี๋ยวเรือ";
            res4.img = "Restaurant\\PhraThep\\มามา.jpg";
            res4.detail = "ร้านมามาก๋วยเตี๋ยวเรือ";

            var res5 = new ResModel();
            res5.name = "ร้านณรงค์ข้าวมันไก่";
            res5.img = "Restaurant\\PhraThep\\ร้านณรงค์ข้าวมันไก่.jpg";
            res5.detail = "ร้านณรงค์ข้าวมันไก่";

            var res6 = new ResModel();
            res6.name = "ร้านมิลเลี่ยน";
            res6.img = "Restaurant\\PhraThep\\ร้านมิลเลี่ยน.jpg";
            res6.detail = "ร้านมิลเลี่ยน";

            var res7 = new ResModel();
            res7.name = "ร้านอิดริส";
            res7.img = "Restaurant\\PhraThep\\ร้านอิริส.jpg";
            res7.detail = "ร้านอิดริส";

            var res8 = new ResModel();
            res8.name = "ร้านไอเย็น";
            res8.img = "Restaurant\\PhraThep\\ร้านไอเย็น.jpg";
            res8.detail = "ร้านไอเย็น";



            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);
            allRes.Add(res6);
            allRes.Add(res7);
            allRes.Add(res8);

            return View(allRes);
        }
        public IActionResult CafeteriaA()
        {
            HttpContext.Session.SetString("Cafeteria", "CafeteriaA");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "Restaurant\\CafeteriaA\\ร้านวันดิสมีล.jpg";
            res1.detail = "ร้านวันดิสมีล";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "Restaurant\\CafeteriaA\\ร้านสิบเอ็ด.jpg";
            res2.detail = "ร้านสิบเอ็ด";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "Restaurant\\CafeteriaA\\ร้านครัวธนโรจน์.jpg";
            res3.detail = "ร้านครัวธนโรจน์";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "Restaurant\\CafeteriaA\\ร้านก็อดซิล่า.jpg";
            res4.detail = "ร้านก็อดซิล่า";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "Restaurant\\CafeteriaA\\ร้านยูกิ.jpg";
            res5.detail = "ร้านยูกิ";

            var res6 = new ResModel();
            res6.name = "6";
            res6.img = "Restaurant\\CafeteriaA\\ต้มยำไข่หวาน.jpg";
            res6.detail = "ร้านก๋วยเตี๋ยวยำไข่หวานและอาหารตามสั่ง";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);
            allRes.Add(res6);

            return View(allRes);
        }

        public IActionResult CafeteriaC()
        {
            HttpContext.Session.SetString("Cafeteria", "CafeteriaC");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "Restaurant\\CafeteriaC\\กาแฟโบราณ.jpg";
            res1.detail = "ร้านเพ็ญกาแฟโบราณ";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "Restaurant\\CafeteriaC\\ขาหมู.jpg";
            res2.detail = "ร้านลุงขาหมู";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "Restaurant\\CafeteriaC\\ทวินันท์.jpg";
            res3.detail = "ร้านรวินันท์ข้าวมันไก่แกงกะหรี่ญี่ปุ่น";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "Restaurant\\CafeteriaC\\ป้าวรรณ.jpg";
            res4.detail = "ร้านข้าวแกงป้าวรรณ";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "Restaurant\\CafeteriaC\\แม่ประนอม.jpg";
            res5.detail = "ร้านครัวแม่ประนอม";

            var res6 = new ResModel();
            res6.name = "6";
            res6.img = "Restaurant\\CafeteriaC\\ตามสั่ง.jpg";
            res6.detail = "ร้านอาหารตามสั่ง";

            List<ResModel> allRes = new List<ResModel>();
            allRes.Add(res1);
            allRes.Add(res2);
            allRes.Add(res3);
            allRes.Add(res4);
            allRes.Add(res5);
            allRes.Add(res6);

            return View(allRes);
        }

        public IActionResult ThinChongKhoCafeteria()
        {
            HttpContext.Session.SetString("Cafeteria", "ThinChongKhoCafeteria");
            ResModel res1 = new ResModel();
            res1.name = "1";
            res1.img = "Restaurant\\ThinChongKho\\กระต่าย.jpg";
            res1.detail = "ร้านกระต่ายทอง";

            var res2 = new ResModel();
            res2.name = "2";
            res2.img = "Restaurant\\ThinChongKho\\มุมอร่อย.jpg";
            res2.detail = "ร้านมุมอร่อย";

            var res3 = new ResModel();
            res3.name = "3";
            res3.img = "Restaurant\\ThinChongKho\\ธงฟ้า.jpg";
            res3.detail = "ร้านธงฟ้า";

            var res4 = new ResModel();
            res4.name = "4";
            res4.img = "Restaurant\\ThinChongKho\\อุ๊.jpg";
            res4.detail = "ร้านพี่อุ๊";

            var res5 = new ResModel();
            res5.name = "5";
            res5.img = "Restaurant\\ThinChongKho\\สมชาย.jpg";
            res5.detail = "ร้านสมชายตามสั่ง";

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
            return RedirectToAction("Restaurant", "FindCafeteria", new { cafeteria = cafeteria, restaurant = value });
        }

        public IActionResult RestaurantPath()
        {
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            string restaurant = HttpContext.Session.GetString("Restaurant");
            return RedirectToAction("Restaurant", "FindCafeteria", new { cafeteria = cafeteria, restaurant = restaurant });
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

            List<ResModel> allRes = new List<ResModel>();

            if (restaurant == "ร้านวันดิสมีล")
            {
                ResModel res1 = new ResModel();
                res1.name = "กะเพราไก่กรอบ";
                res1.img = "pic_food\\กะเพราไก่กรอบ.jpg";
                res1.detail = "กะเพราไก่กรอบ";

                var res2 = new ResModel();
                res2.name = "ข้าวผัดหมู";
                res2.img = "pic_food\\ข้าวผัดหมู.jpg";
                res2.detail = "ข้าวผัดหมู";

                var res3 = new ResModel();
                res3.name = "ข้าวต้มหมู";
                res3.img = "pic_food\\ข้าวต้มหมู.jpg";
                res3.detail = "ข้าวต้มหมู";

                var res4 = new ResModel();
                res4.name = "เขียวหวานไก่ราดข้าว";
                res4.img = "pic_food\\เขียวหวานไก่ราดข้าว.jpg";
                res4.detail = "เขียวหวานไก่ราดข้าว";

                var res5 = new ResModel();
                res5.name = "ผัดซีอิ๋วหมู";
                res5.img = "pic_food\\ผัดซีอิ๋วหมู.jpg";
                res5.detail = "ผัดซีอิ๋วหมู";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านสิบเอ็ด")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวไก่แซ่บ";
                res1.img = "pic_food\\ข้าวไก่แซ่บ.jpg";
                res1.detail = "ข้าวไก่แซ่บ";

                var res2 = new ResModel();
                res2.name = "หมูทอดทงคัตสึ";
                res2.img = "pic_food\\หมูทอดทงคัตสึ.jpg";
                res2.detail = "หมูทอดทงคัตสึ";

                var res3 = new ResModel();
                res3.name = "ข้าวปลาคัตสึ";
                res3.img = "pic_food\\ข้าวปลาคัตสึ.jpg";
                res3.detail = "ข้าวปลาคัตสึ";

                var res4 = new ResModel();
                res4.name = "ข้าวแกงกะหรี่ญี่ปุ่น";
                res4.img = "pic_food\\ข้าวแกงกะหรี่ญี่ปุ่น.jpg";
                res4.detail = "ข้าวแกงกะหรี่ญี่ปุ่น";

                var res5 = new ResModel();
                res5.name = "ข้าวไข่ข้น";
                res5.img = "pic_food\\ข้าวไข่ข้น.jpg";
                res5.detail = "ข้าวไข่ข้น";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านครัวธนโรจน์")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวไข่เจียวทรงเครื่อง";
                res1.img = "pic_food\\ข้าวไข่เจียวทรงเครื่อง.jpg";
                res1.detail = "ข้าวไข่เจียวทรงเครื่อง";

                var res2 = new ResModel();
                res2.name = "ข้าวไข่คั่ว";
                res2.img = "pic_food\\ข้าวไข่คั่ว.jpg";
                res2.detail = "ข้าวไข่คั่ว";

                var res3 = new ResModel();
                res3.name = "ข้าวหมูแดง";
                res3.img = "pic_food\\ข้าวหมูแดง.jpg";
                res3.detail = "ข้าวหมูแดง";

                var res4 = new ResModel();
                res4.name = "ข้าวหมูกรอบ";
                res4.img = "pic_food\\ข้าวหมูกรอบ.jpg";
                res4.detail = "ข้าวหมูกรอบ";

                var res5 = new ResModel();
                res5.name = "บะหมี่หมูแดง";
                res5.img = "pic_food\\บะหมี่หมูแดง.jpg";
                res5.detail = "บะหมี่หมูแดง";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านก็อดซิล่า")
            {
                ResModel res1 = new ResModel();
                res1.name = "กาแฟคาปูชิโน่";
                res1.img = "pic_food\\กาแฟคาปูชิโน่.jpg";
                res1.detail = "กาแฟคาปูชิโน่";

                var res3 = new ResModel();
                res3.name = "เป๊ปซี่";
                res3.img = "pic_food\\เป๊ปซี่.jpg";
                res3.detail = "เป๊ปซี่";

                var res4 = new ResModel();
                res4.name = "น้ำเปล่า";
                res4.img = "pic_food\\น้ำเปล่า.jpg";
                res4.detail = "น้ำเปล่า";

                var res5 = new ResModel();
                res5.name = "น้ำแดง";
                res5.img = "pic_food\\น้ำแดง.jpg";
                res5.detail = "น้ำแดง";


                allRes.Add(res1);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านยูกิ")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวขาหมู";
                res1.img = "pic_food\\ข้าวขาหมู.jpg";
                res1.detail = "ข้าวขาหมู";

                var res2 = new ResModel();
                res2.name = "ต้มเลือดหมู";
                res2.img = "pic_food\\ต้มเลือดหมู.jpg";
                res2.detail = "ต้มเลือดหมู";

                var res3 = new ResModel();
                res3.name = "ผัดไทยกุ้งสด";
                res3.img = "pic_food\\ผัดไทยกุ้งสด.jpg";
                res3.detail = "ผัดไทยกุ้งสด";

                var res4 = new ResModel();
                res4.name = "ข้าวผัดต้มยำ";
                res4.img = "pic_food\\ข้าวผัดต้มยำ.jpg";
                res4.detail = "ข้าวผัดต้มยำ";

                var res5 = new ResModel();
                res5.name = "ข้าวผัดแหนม";
                res5.img = "pic_food\\ข้าวผัดแหนม.jpg";
                res5.detail = "ข้าวผัดแหนม";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านก๋วยเตี๋ยวยำไข่หวานและอาหารตามสั่ง")
            {
                ResModel res1 = new ResModel();
                res1.name = "ก๋วยเตี๋ยวต้มยำไข่";
                res1.img = "pic_food\\ก๋วยเตี๋ยวต้มยำไข่.jpg";
                res1.detail = "ก๋วยเตี๋ยวต้มยำไข่";

                var res2 = new ResModel();
                res2.name = "ก๋วยเตี๋ยวคั่วไก่";
                res2.img = "pic_food\\ก๋วยเตี๋ยวคั่วไก่.jpg";
                res2.detail = "ก๋วยเตี๋ยวคั่วไก่";

                var res3 = new ResModel();
                res3.name = "ข้าวผัดอเมริกัน";
                res3.img = "pic_food\\ข้าวผัดอเมริกัน.jpg";
                res3.detail = "ข้าวผัดอเมริกัน";

                var res4 = new ResModel();
                res4.name = "ข้าวหมูทอดกระเทียม";
                res4.img = "pic_food\\ข้าวหมูทอดกระเทียม.jpg";
                res4.detail = "ข้าวหมูทอดกระเทียม";

                var res5 = new ResModel();
                res5.name = "สุกี้หมู";
                res5.img = "pic_food\\สุกี้หมู.jpg";
                res5.detail = "สุกี้หมู";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านกระต่ายทอง")
            {
                ResModel res1 = new ResModel();
                res1.name = "กาแฟเย็น";
                res1.img = "pic_food\\กาแฟ.jpg";
                res1.detail = "กาแฟเย็น";

                var res3 = new ResModel();
                res3.name = "โกโก้เย็น";
                res3.img = "pic_food\\โกโก้เย็น.jpg";
                res3.detail = "โกโก้เย็น";

                var res4 = new ResModel();
                res4.name = "นมเย็น";
                res4.img = "pic_food\\นมเย็น.jpg";
                res4.detail = "นมเย็น";

                var res5 = new ResModel();
                res5.name = "น้ำเก๊กฮวย";
                res5.img = "pic_food\\น้ำเก๊กฮวย.jpg";
                res5.detail = "น้ำเก๊กฮวย";

                allRes.Add(res1);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านมุมอร่อย")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวตับผัดพริกหยวก";
                res1.img = "pic_food\\ข้าวตับผัดพริกหยวก.jpg";
                res1.detail = "ข้าวตับผัดพริกหยวก";

                var res2 = new ResModel();
                res2.name = "ข้าวคะน้าหมูกรอบ";
                res2.img = "pic_food\\ข้าวคะน้าหมูกรอบ.jpg";
                res2.detail = "ข้าวคะน้าหมูกรอบ";

                var res3 = new ResModel();
                res3.name = "ข้าวผัดพริกแกงหมู";
                res3.img = "pic_food\\ข้าวผัดพริกแกงหมู.jpg";
                res3.detail = "ข้าวผัดพริกแกงหมู";

                var res4 = new ResModel();
                res4.name = "ข้าวผัดพริกเผาหมู";
                res4.img = "pic_food\\ข้าวผัดพริกเผาหมู.jpg";
                res4.detail = "ข้าวผัดพริกเผาหมู";

                var res5 = new ResModel();
                res5.name = "ก๋วยเตี๋ยวราดหน้าหมู";
                res5.img = "pic_food\\ก๋วยเตี๋ยวราดหน้าหมู.jpg";
                res5.detail = "ก๋วยเตี๋ยวราดหน้าหมู";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านธงฟ้า")
            {
                ResModel res1 = new ResModel();
                res1.name = "แกงเผ็ด";
                res1.img = "pic_food\\แกงเผ็ด.jpg";
                res1.detail = "แกงเผ็ด";

                var res2 = new ResModel();
                res2.name = "ผัดเผ็ด";
                res2.img = "pic_food\\ผัดเผ็ด.jpg";
                res2.detail = "ผัดเผ็ด";

                var res3 = new ResModel();
                res3.name = "ผัดผัก";
                res3.img = "pic_food\\ผัดผัก.jpg";
                res3.detail = "ผัดผัก";

                var res4 = new ResModel();
                res4.name = "ยำทะเล";
                res4.img = "pic_food\\ยำทะเล.jpg";
                res4.detail = "ยำทะเล";

                var res5 = new ResModel();
                res5.name = "ต้มจืดวุ้นเส้น";
                res5.img = "pic_food\\ต้มจืดวุ้นเส้น.jpg";
                res5.detail = "ต้มจืดวุ้นเส้น";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านพี่อุ๊")
            {
                ResModel res1 = new ResModel();
                res1.name = "ก๋วยเตี๋ยวต้มยำน้ำข้น";
                res1.img = "pic_food\\ก่วยเตี๋ยวต้มยำน้ำข้น.jpg";
                res1.detail = "ก่วยเตี๋ยวต้มยำน้ำข้น";

                var res2 = new ResModel();
                res2.name = "ก่วยเตี๋ยวน้ำใส";
                res2.img = "pic_food\\ก่วยเตี๋ยวน้ำใส.jpg";
                res2.detail = "ก่วยเตี๋ยวน้ำใส";

                var res3 = new ResModel();
                res3.name = "ก่วยเตี๋ยวหมู";
                res3.img = "pic_food\\ก่วยเตี๋ยวหมู.jpg";
                res3.detail = "ก่วยเตี๋ยวหมู";

                var res4 = new ResModel();
                res4.name = "ก่วยเตี๋ยวหมูตุ๋น";
                res4.img = "pic_food\\ก่วยเตี๋ยวหมูตุ๋น.jpg";
                res4.detail = "ก่วยเตี๋ยวหมูตุ๋น";

                var res5 = new ResModel();
                res5.name = "เย็นตาโฟ";
                res5.img = "pic_food\\เย็นตาโฟ.jpg";
                res5.detail = "เย็นตาโฟ";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านสมชายตามสั่ง")
            {
                ResModel res1 = new ResModel();
                res1.name = "คะน้าหมูกรอบ";
                res1.img = "pic_food\\คะน้าหมูกรอบ.jpg";
                res1.detail = "คะน้าหมูกรอบ";

                var res2 = new ResModel();
                res2.name = "คะน้าหมูชิ้น";
                res2.img = "pic_food\\คะน้าหมูชิ้น.jpg";
                res2.detail = "คะน้าหมูชิ้น";

                var res3 = new ResModel();
                res3.name = "ข้าวผัดหมู";
                res3.img = "pic_food\\ข้าวผัดหมู.jpg";
                res3.detail = "ข้าวผัดหมู";

                var res4 = new ResModel();
                res4.name = "พริกแกงหมูกรอบ";
                res4.img = "pic_food\\พริกแกงหมูกรอบ.jpg";
                res4.detail = "พริกแกงหมูกรอบ";

                var res5 = new ResModel();
                res5.name = "กะเพราเนื้อ";
                res5.img = "pic_food\\กะเพราเนื้อ.jpg";
                res5.detail = "กะเพราเนื้อ";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านเพ็ญกาแฟโบราณ")
            {
                ResModel res1 = new ResModel();
                res1.name = "โกโก้เย็น";
                res1.img = "pic_food\\โกโก้เย็น.jpg";
                res1.detail = "โกโก้เย็น";

                var res2 = new ResModel();
                res2.name = "ชาเขียว";
                res2.img = "pic_food\\ชาเขียว.jpg";
                res2.detail = "ชาเขียว";

                var res3 = new ResModel();
                res3.name = "กาแฟเย็น";
                res3.img = "pic_food\\กาแฟ.jpg";
                res3.detail = "กาแฟเย็น";

                var res4 = new ResModel();
                res4.name = "โอเลี้ยง";
                res4.img = "pic_food\\โอเลี้ยง.jpg";
                res4.detail = "โอเลี้ยง";

                var res5 = new ResModel();
                res5.name = "ชาดำเย็น";
                res5.img = "pic_food\\ชาดำเย็น.jpg";
                res5.detail = "ชาดำเย็น";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านครัวแม่ประนอม")
            {
                ResModel res1 = new ResModel();
                res1.name = "ไก่กรอบผัดเม็ดมะม่วง";
                res1.img = "pic_food\\ไก่กรอบผัดเม็ดมะม่วง.jpg";
                res1.detail = "ไก่กรอบผัดเม็ดมะม่วง";

                var res2 = new ResModel();
                res2.name = "ข้าวผัดห่อไข่";
                res2.img = "pic_food\\ข้าวผัดห่อไข่.jpg";
                res2.detail = "ข้าวผัดห่อไข่";

                var res3 = new ResModel();
                res3.name = "สปาเก็ตตี้";
                res3.img = "pic_food\\สปาเก็ตตี้.jpg";
                res3.detail = "สปาเก็ตตี้";

                var res4 = new ResModel();
                res4.name = "กะเพรารวมมิตร";
                res4.img = "pic_food\\กะเพรารวมมิตร.jpg";
                res4.detail = "กะเพรารวมมิตร";

                var res5 = new ResModel();
                res5.name = "กะเพราเบค่อน";
                res5.img = "pic_food\\กะเพราเบค่อน.jpg";
                res5.detail = "กะเพราเบค่อน";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านข้าวแกงป้าวรรณ")
            {
                ResModel res1 = new ResModel();
                res1.name = "ปลาดุกผัดพริก";
                res1.img = "pic_food\\ปลาดุกผัดพริก.jpg";
                res1.detail = "ปลาดุกผัดพริก";

                var res2 = new ResModel();
                res2.name = "หอยลายผัดพริกเผา";
                res2.img = "pic_food\\หอยลายผัดพริกเผา.jpg";
                res2.detail = "หอยลายผัดพริกเผา";

                var res3 = new ResModel();
                res3.name = "วุ้นเส้นผัดไข่";
                res3.img = "pic_food\\วุ้นเส้นผัดไข่.jpg";
                res3.detail = "วุ้นเส้นผัดไข่";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
            }
            if (restaurant == "ร้านรวินันท์ข้าวมันไก่แกงกะหรี่ญี่ปุ่น")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวมันไก่ต้ม";
                res1.img = "pic_food\\ข้าวมันไก่ต้ม.jpg";
                res1.detail = "ข้าวมันไก่ต้ม";

                var res2 = new ResModel();
                res2.name = "ข้าวมันไก่ย่าง";
                res2.img = "pic_food\\ข้าวมันไก่ย่าง.jpg";
                res2.detail = "ข้าวมันไก่ย่าง";

                var res3 = new ResModel();
                res3.name = "ข้าวมันไก่ทอด";
                res3.img = "pic_food\\ข้าวมันไก่ทอด.jpg";
                res3.detail = "ข้าวมันไก่ทอด";

                var res4 = new ResModel();
                res4.name = "แกงกะหรี่ญี่ปุ่นไก่ทอด";
                res4.img = "pic_food\\แกงกะหรี่ญี่ปุ่นไก่ทอด.jpg";
                res4.detail = "แกงกะหรี่ญี่ปุ่นไก่ทอด";

                var res5 = new ResModel();
                res5.name = "ข้าวหน้าไก่อบซอส";
                res5.img = "pic_food\\ข้าวหน้าไก่อบซอส.jpg";
                res5.detail = "ข้าวหน้าไก่อบซอส";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านลุงขาหมู")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวขาหมู";
                res1.img = "pic_food\\ข้าวขาหมู.jpg";
                res1.detail = "ข้าวขาหมู";

                var res2 = new ResModel();
                res2.name = "ข้าวไก่ทอดซอสญี่ปุ่น";
                res2.img = "pic_food\\ข้าวไก่ทอดซอสญี่ปุ่น.jpg";
                res2.detail = "ข้าวไก่ทอดซอสญี่ปุ่น";

                allRes.Add(res1);
                allRes.Add(res2);

            }
            if (restaurant == "ร้านอาหารตามสั่ง")
            {
                ResModel res1 = new ResModel();
                res1.name = "ผัดผักบุ้งไฟแดง";
                res1.img = "pic_food\\ผัดผักบุ้งไฟแดง.jpg";
                res1.detail = "ผัดผักบุ้งไฟแดง";

                var res2 = new ResModel();
                res2.name = "ไข่เจียวหมู";
                res2.img = "pic_food\\ไข่เจียวหมู.jpg";
                res2.detail = "ไข่เจียวหมู";

                var res3 = new ResModel();
                res3.name = "ข้าวต้ม";
                res3.img = "pic_food\\ข้าวต้ม.jpg";
                res3.detail = "ข้าวต้ม";

                var res4 = new ResModel();
                res4.name = "ยำวุ้นเส้น";
                res4.img = "pic_food\\ยำวุ้นเส้น.jpg";
                res4.detail = "ยำวุ้นเส้น";

                var res5 = new ResModel();
                res5.name = "ราดหน้า";
                res5.img = "pic_food\\ราดหน้า.jpg";
                res5.detail = "ราดหน้า";

                var res6 = new ResModel();
                res6.name = "ต้มจืดเต้าหู้";
                res6.img = "pic_food\\ต้มจืดเต้าหู้.jpg";
                res6.detail = "ต้มจืดเต้าหู้";


                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
                allRes.Add(res6);
            }
            if (restaurant == "ร้านเทคโนอินเตอร์")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวยำไก่ย่าง";
                res1.img = "pic_food\\ข้าวยำไก่ย่าง.jpg";
                res1.detail = "ข้าวยำไก่ย่าง";

                var res2 = new ResModel();
                res2.name = "ครีมซุปเห็ด";
                res2.img = "pic_food\\ครีมซุปเห็ด.jpg";
                res2.detail = "ครีมซุปเห็ด";

                var res3 = new ResModel();
                res3.name = "ข้าวไก่ย่างเทริยากิ";
                res3.img = "pic_food\\ข้าวไก่ย่างเทริยากิ.jpg";
                res3.detail = "ข้าวไก่ย่างเทริยากิ";

                var res4 = new ResModel();
                res4.name = "ข้าวไก่พะแนง";
                res4.img = "pic_food\\ข้าวไก่พะแนง.jpg";
                res4.detail = "ข้าวไก่พะแนง";

                var res5 = new ResModel();
                res5.name = "ข้าวหมูสไปร์ทซี่";
                res5.img = "pic_food\\ข้าวหมูสไปซี่.jpg";
                res5.detail = "ข้าวหมูสไปร์ทซี่";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านป้าศรีส้มตำ")
            {
                ResModel res1 = new ResModel();
                res1.name = "ส้มตำข้าวโพด";
                res1.img = "pic_food\\ส้มตำข้าวโพด.jpg";
                res1.detail = "ส้มตำข้าวโพด";

                var res2 = new ResModel();
                res2.name = "ส้มตำหมูยอ";
                res2.img = "pic_food\\ส้มตำหมูยอ.jpg";
                res2.detail = "ส้มตำหมูยอ";

                var res3 = new ResModel();
                res3.name = "น้ำตก";
                res3.img = "pic_food\\น้ำตก.jpg";
                res3.detail = "น้ำตก";

                var res4 = new ResModel();
                res4.name = "ต้มแซ่บ";
                res4.img = "pic_food\\ต้มแซ่บ.jpg";
                res4.detail = "ต้มแซ่บ";

                var res5 = new ResModel();
                res5.name = "ลาบปลา";
                res5.img = "pic_food\\ลาบปลา.jpg";
                res5.detail = "ลาบปลา";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านไอหนวด")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวไข่พะโล้";
                res1.img = "pic_food\\ข้าวไข่พะโล้.jpg"; ;
                res1.detail = "ข้าวไข่พะโล้";

                var res2 = new ResModel();
                res2.name = "ข้าวผัดเผ็ดปลาดุก";
                res2.img = "pic_food\\ข้าวผัดเผ็ดปลาดุก.jpg";
                res2.detail = "ข้าวผัดเผ็ดปลาดุก";

                var res3 = new ResModel();
                res3.name = "ข้าวผัดฟักทอง";
                res3.img = "pic_food\\ข้าวผัดฟักทอง.jpg";
                res3.detail = "ข้าวผัดฟักทอง";

                var res4 = new ResModel();
                res4.name = "ข้าวไข่เจียว";
                res4.img = "pic_food\\ข้าวไข่เจียว.jpg";
                res4.detail = "ข้าวไข่เจียว";

                var res5 = new ResModel();
                res5.name = "ข้าวผัดวุ้นเส้น";
                res5.img = "pic_food\\ข้าวผัดวุ้นเส้น.jpg";
                res5.detail = "ข้าวผัดวุ้นเส้น";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านมามาก๋วยเตี๋ยวเรือ")
            {
                ResModel res1 = new ResModel();
                res1.name = "ก๋วยเตี๋ยวเรือน้ำตก";
                res1.img = "pic_food\\ก๋วยเตี๋ยวเรือน้ำตก.jpg";
                res1.detail = "ก๋วยเตี๋ยวเรือน้ำตก";

                var res2 = new ResModel();
                res2.name = "ก๋วยเตี๋ยวต้มยำ";
                res2.img = "pic_food\\ก๋วยเตี๋ยวต้มยำ.jpg";
                res2.detail = "ก๋วยเตี๋ยวต้มยำ";

                var res3 = new ResModel();
                res3.name = "ก๋วยเตี๋ยวเนื้อตุ๋น";
                res3.img = "pic_food\\ก๋วยเตี๋ยวเนื้อตุ๋น.jpg";
                res3.detail = "ก๋วยเตี๋ยวเนื้อตุ๋น";

                var res4 = new ResModel();
                res4.name = "ก๋วยเตี๋ยวไก่";
                res4.img = "pic_food\\ก๋วยเตี๋ยวไก่.jpg";
                res4.detail = "ก๋วยเตี๋ยวไก่";

                var res5 = new ResModel();
                res5.name = "เย็นตาโฟ";
                res5.img = "pic_food\\เย็นตาโฟ.jpg";
                res5.detail = "เย็นตาโฟ";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านณรงค์ข้าวมันไก่")
            {
                ResModel res1 = new ResModel();
                res1.name = "ข้าวมันไก่ต้ม";
                res1.img = "pic_food\\ข้าวมันไก่ต้ม.jpg";
                res1.detail = "ข้าวมันไก่ต้ม";

                var res2 = new ResModel();
                res2.name = "ข้าวมันไก่ย่าง";
                res2.img = "pic_food\\ข้าวมันไก่ย่าง.jpg";
                res2.detail = "ข้าวมันไก่ย่าง";

                var res3 = new ResModel();
                res3.name = "ข้าวมันไก่ทอด";
                res3.img = "pic_food\\ข้าวมันไก่ทอด.jpg";
                res3.detail = "ข้าวมันไก่ทอด";

                var res4 = new ResModel();
                res4.name = "ข้าวหมูอบ";
                res4.img = "pic_food\\ข้าวหมูอบ.jpg";
                res4.detail = "ข้าวหมูอบ";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
            }
            if (restaurant == "ร้านมิลเลี่ยน")
            {
                ResModel res1 = new ResModel();
                res1.name = "ก๋วยเตี๋ยวคั่วไก่";
                res1.img = "pic_food\\ก๋วยเตี๋ยวคั่วไก่.jpg";
                res1.detail = "ก๋วยเตี๋ยวคั่วไก่";

                var res2 = new ResModel();
                res2.name = "ข้าวผัดน้ำพริกลงเรือ";
                res2.img = "pic_food\\ข้าวผัดน้ำพริกลงเรือ.jpg";
                res2.detail = "ข้าวผัดน้ำพริกลงเรือ";

                var res3 = new ResModel();
                res3.name = "ข้าวผัดพริกเผาหมู";
                res3.img = "pic_food\\ข้าวผัดพริกเผาหมู.jpg";
                res3.detail = "ข้าวผัดพริกเผาหมู";

                var res4 = new ResModel();
                res4.name = "ข้าวผัดสับปะรด";
                res4.img = "pic_food\\ข้าวผัดสับปะรด.jpg";
                res4.detail = "ข้าวผัดสับปะรด";

                var res5 = new ResModel();
                res5.name = "ข้าวยำคอหมูย่าง";
                res5.img = "pic_food\\ข้าวยำคอหมูย่าง.jpg";
                res5.detail = "ข้าวยำคอหมูย่าง";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }

            if (restaurant == "ร้านอิดริส")
            {
                ResModel res1 = new ResModel();
                res1.name = "ผัดผงกะหรี่";
                res1.img = "pic_food\\ผัดผงกะหรี่.jpg";
                res1.detail = "ผัดผงกะหรี่";

                var res2 = new ResModel();
                res2.name = "ต้มข่า";
                res2.img = "pic_food\\ต้มข่า.jpg";
                res2.detail = "ต้มข่า";

                var res3 = new ResModel();
                res3.name = "ไข่เจียวกุ้ง";
                res3.img = "pic_food\\ไข่เจียวกุ้ง.jpg";
                res3.detail = "ไข่เจียวกุ้ง";

                var res4 = new ResModel();
                res4.name = "ยำมาม่า";
                res4.img = "pic_food\\ยำมาม่า.jpg";
                res4.detail = "ยำมาม่า";

                var res5 = new ResModel();
                res5.name = "ผัดพริกหยวก";
                res5.img = "pic_food\\ผัดพริกหยวก.jpg";
                res5.detail = "ผัดพริกหยวก";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }
            if (restaurant == "ร้านไอเย็น")
            {
                ResModel res1 = new ResModel();
                res1.name = "เกี๊ยวไข่";
                res1.img = "pic_food\\เกี๊ยวไข่.jpg";
                res1.detail = "เกี๊ยวไข่";

                var res2 = new ResModel();
                res2.name = "เฉาก๊วยนมสด";
                res2.img = "pic_food\\เฉาก๊วยนมสด.jpg";
                res2.detail = "เฉาก๊วยนมสด";

                var res3 = new ResModel();
                res3.name = "น้ำแข็งไส";
                res3.img = "pic_food\\น้ำแข็งไส.jpg";
                res3.detail = "น้ำแข็งไส";

                var res4 = new ResModel();
                res4.name = "ผลไม้";
                res4.img = "pic_food\\ผลไม้.jpg";
                res4.detail = "ผลไม้";

                var res5 = new ResModel();
                res5.name = "ลูกชิ้นทอด";
                res5.img = "pic_food\\ลูกชิ้นทอด.jpg";
                res5.detail = "ลูกชิ้นทอด";

                allRes.Add(res1);
                allRes.Add(res2);
                allRes.Add(res3);
                allRes.Add(res4);
                allRes.Add(res5);
            }



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
            return RedirectToAction("Cart", "FindCafeteria", new { cafeteria = cafeteria, restaurant = restaurant });
        }


        [HttpGet]
        [Route("/FindCafeteria/{cafeteria}/{restaurant}/[action]")]
        public IActionResult Cart(string cafeteria, string restaurant)
        {
            ViewBag.res = HttpContext.Session.GetString("Restaurant");
            ViewBag.Head = HttpContext.Session.GetString("Head");
            return View(ListOrder);
        }

        [HttpPost]
        public IActionResult OrderedPath(string count)
        {
            HttpContext.Session.SetString("orderCount", count);
            string cafeteria = HttpContext.Session.GetString("Cafeteria");
            string restaurant = HttpContext.Session.GetString("Restaurant");
            return RedirectToAction("Ordered", "FindCafeteria", new { cafeteria = cafeteria, restaurant = restaurant });
        }

        [HttpGet]
        [Route("/FindCafeteria/{cafeteria}/{restaurant}/[action]")]
        public IActionResult Ordered()
        {
            OrderModel model = new OrderModel();
            model.Username = HttpContext.Session.GetString("UserName");
            IEnumerable<UserModel> User = _users.Users;
            var list = User.Where(x => x.Username == model.Username);
            foreach(var item in list)
            {
                model.FirstnameDepositor = item.Firstname;
                model.LastnameDepositor= item.Lastname;
            }
            model.Cafeteria = HttpContext.Session.GetString("Head");
            model.Restaurant = HttpContext.Session.GetString("Restaurant");
            model.OrderList = HttpContext.Session.GetString("orderList");
            model.OrderCount = HttpContext.Session.GetString("orderCount");
            model.UsernameDepository = "";
            model.FirstnameDepository = "";
            model.LastnameDepository = "";
            
            _context.Orders.Add(model);
            _context.SaveChanges();
            HttpContext.Session.Remove("Head");
            HttpContext.Session.Remove("Cafeteria");
            HttpContext.Session.Remove("Restaurant");
            HttpContext.Session.Remove("orderList");
            HttpContext.Session.Remove("orderCount");
            return RedirectToAction("ฝากซื้อ", "Account");
        }


    }
}
