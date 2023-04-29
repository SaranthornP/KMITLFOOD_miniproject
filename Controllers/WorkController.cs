using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Data;
using ProjectKMITL.Models;

namespace ProjectKMITL.Controllers
{
    public class WorkController : Controller
    {

        private readonly OrderDbContext _context;

        public WorkController(OrderDbContext context)
        {
            _context = context;

        }
        [HttpGet]
            public IActionResult Index(){
            string Username = HttpContext.Session.GetString("UserName");
            if (Username == null) return RedirectToAction("Index", "Home");
            IEnumerable<OrderModel> allOrder = _context.Orders;
            var list = allOrder.Where(x => x.NameDepository == "");

            ViewBag.Username = HttpContext.Session.GetString("UserName");
            return View(list);
        }

        [HttpPost]
        public IActionResult Confirm(int Id) {
            IEnumerable<OrderModel> allOrder = _context.Orders;
            var list = allOrder.Where(x => x.Id == Id);

            return View(list);
        }

        [HttpPost]
        public IActionResult AcceptOrder(int Id)
        {
            IEnumerable<OrderModel> allOrder = _context.Orders;
            var list = _context.Orders.Find(Id);

            string Username = HttpContext.Session.GetString("UserName");
            list.NameDepository = Username;

            if (ModelState.IsValid)
            {
                _context.Orders.Update(list);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Work");
        }

    }
}
