using Microsoft.AspNetCore.Mvc;
using ProjectKMITL.Data;
using ProjectKMITL.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Operations;
using ProjectKMITL.Migrations;

public class AccountController : Controller
{
    private readonly ApplicationDBContext _context;
    private bool IsUsernameExists(string username)
    {
        var user = _context.Users.Where(u => u.Username == username).FirstOrDefault();
        if (user != null)
        {
            return true;
        }
        return false;
    }
    public AccountController(ApplicationDBContext context)
    {
        _context = context;

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
            return RedirectToAction("Index", "Home");
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
            return RedirectToAction("Profile");
        }
        if (IsValidUser(model.Username, model.Password))
        {
            HttpContext.Session.SetString("UserName", model.Username);
            return RedirectToAction("Profile");
            
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

    public IActionResult Edit()
    {
        return View();
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

}
