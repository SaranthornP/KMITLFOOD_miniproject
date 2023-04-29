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
            public IActionResult Index()
        {
            IEnumerable<OrderModel> allOrder = _context.Orders;
            var list = allOrder.Where(x => x.NameDepository == "");

            ViewBag.Username = HttpContext.Session.GetString("UserName");
            return View(list);
        }
    }
}
