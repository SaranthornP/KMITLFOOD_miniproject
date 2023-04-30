using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Data;
using ProjectKMITL.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;


public class AccountController : Controller
{
    private readonly ApplicationDBContext _context;
    private readonly OrderDbContext _db;
    private bool IsUsernameExists(string username)
    {
        var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
        if (user != null)
        {
            return true;
        }
        return false;
    }
    public AccountController(ApplicationDBContext context, OrderDbContext db)
    {
        _context = context;
        _db = db;

    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel userGet)
    {
        UserModel user = new UserModel();
        user.Username = userGet.Username;
        user.Password = userGet.Password;
        user.Firstname = userGet.Firstname;
        user.Lastname = userGet.Lastname;
        user.Phone = userGet.Phone;
        if (IsUsernameExists(user.Username))
        {
            ModelState.AddModelError(string.Empty, "Username already exists");
            userGet.Password = "";
            userGet.ConfirmPassword = "";
            return View(userGet);
        }

        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        userGet.Password = "";
        userGet.ConfirmPassword = "";
        return View(userGet);
    }


    // GET: /Account/Login
    [HttpGet]
    public ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    // POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginViewModel model, string returnUrl)
    {
        if (model.Username == "admin" &&  model.Password == "1")
        {
            HttpContext.Session.SetString("UserName", model.Username);
            return RedirectToAction("Index", "Home");
        }
        if (IsValidUser(model.Username, model.Password))
        {
            HttpContext.Session.SetString("UserName", model.Username);
            return RedirectToAction("Index", "Home");
            
        }
        if(!IsValidUser(model.Username, model.Password))
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Remove("UserName");
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Profile()
    {
        if (HttpContext.Session.GetString("UserName") == "admin")
        {
            UserModel admin = new UserModel();
            admin.Username = "admin";
            admin.Phone = "NULL";
            admin.Firstname = "NULL";
            admin.Lastname = "NULL";
            admin.Password = "1";
            return View(admin);
        }
        if (HttpContext.Session.GetString("UserName") == null)
        {
            return RedirectToAction("Login");
        }
        string username = HttpContext.Session.GetString("UserName");
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        UserModel userModel = user;
        return View(userModel);
    }

    public IActionResult EditProfile()
    {
        string username = HttpContext.Session.GetString("UserName");
        var user = _context.Users.FirstOrDefault(u => u.Username == username);
        var obj = _context.Users.Find(user.UserId);
        return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProfile(UserModel obj)
    {
        var usrObj = _context.Users.Find(obj.UserId);
        if (usrObj != null) { 
        usrObj.Firstname = obj.Firstname;
        usrObj.Lastname = obj.Lastname;
        usrObj.Phone = obj.Phone;
        }
        else
        {
            return Content("Null");
        }

        if (ModelState.IsValid)
        {
            _context.Users.Update(usrObj);
            _context.SaveChanges();
            IEnumerable<OrderModel> allOrder = _db.Orders;
            var list = allOrder.Where(x => x.Username == usrObj.Username);
            foreach(var item in list)
            {
                item.FirstnameDepositor = obj.Firstname;
                item.LastnameDepositor=obj.Lastname;
                _db.Orders.Update(item);
            }
            _db.SaveChanges();
            list = allOrder.Where(x => x.UsernameDepository == usrObj.Username);
            foreach(var item in list)
            {
                item.FirstnameDepository = obj.Firstname;
                item.LastnameDepository = obj.Lastname;
                _db.Orders.Update(item);
            }
            _db.SaveChanges();
            return RedirectToAction("Profile");

        }

        return RedirectToAction("EditProfile");
    }

    private bool IsValidUser(string username, string password)
    {
        var isValid = false;
        IEnumerable <UserModel> allUser = _context.Users;
        
        // ตรวจสอบว่ามีผู้ใช้งานที่ตรงกับ username และ password ในฐานข้อมูลหรือไม่
            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                isValid = true;
            }

        return isValid;
    }

    public IActionResult ฝากซื้อ()
    {
        IEnumerable<OrderModel> allOrder = _db.Orders;
        string Username = HttpContext.Session.GetString("UserName");
        var list = allOrder.Where(x => x.Username == Username);
        var count = allOrder.Count(x => x.Username == Username);
        ViewBag.listnum = count;
        return View(list);
    }

    public IActionResult รับฝาก()
    {
        IEnumerable<OrderModel> allOrder = _db.Orders;
        string Username = HttpContext.Session.GetString("UserName");
        var list = allOrder.Where(x => x.UsernameDepository == Username);
        var count = allOrder.Count(x => x.UsernameDepository == Username);
        ViewBag.listnum2 = count;
        return View(list);
    }

    [Route("[controller]/ฝากซื้อ/Detail")]
    public IActionResult Detail(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        } 
        var obj = _db.Orders.Find(id);

        if (obj == null)
        {
            return NotFound();
        }
        if (obj.UsernameDepository == "")
        {
            ViewBag.PhoneT = "";
        }
        else
        {
            var phone = _context.Users.SingleOrDefault(x => x.Username == obj.UsernameDepository);
            ViewBag.PhoneT = phone.Phone;
        }
        return View(obj);
    }

    [Route("[controller]/ฝากซื้อ/DetailWork")]
    public IActionResult DetailWork(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var obj = _db.Orders.Find(id);

        if (obj == null)
        {
            return NotFound();
        }
        var phone = _context.Users.SingleOrDefault(x => x.Username == obj.Username);
        ViewBag.Phone = phone.Phone;
        return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var obj = _db.Orders.Find(id);

        if (obj == null)
        {
            return NotFound();
        }
        _db.Orders.Remove(obj);
        _db.SaveChanges();
        return RedirectToAction("รับฝาก", "Account");
    }

}
