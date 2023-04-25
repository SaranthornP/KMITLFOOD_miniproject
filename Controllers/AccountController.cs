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
    public IActionResult Register(UserModel user)
    {
        if (IsUsernameExists(user.Username))
        {
            ModelState.AddModelError(string.Empty, "Username already exists");
            return View(user);
        }

        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        return View(user);
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

        if (IsValidUser(model.Username, model.Password))
        {
            HttpContext.Session.SetString("UserName", model.Username);
            TempData["Username"] = model.Username;
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
