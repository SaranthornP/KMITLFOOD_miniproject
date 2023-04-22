using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjectKMITL.Models;

namespace ProjectKMITL.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public List<UserModel> PutValue()
        {

            var users = new List<UserModel>
            {
                new UserModel{id=1, username="dasdas", password="1234"},
                new UserModel{id=2, username="64010827", password="1234"}
            };

            return users;
        }

        [HttpPost]
        public IActionResult Verify(UserModel usr)
        {
            var u = PutValue();

            var ue = u.Where(u => u.username.Equals(usr.username));

            var up = ue.Where(u => u.password.Equals(usr.password));

            if(up.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("Login Success");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login Failed");
            }
        }
    }
}
