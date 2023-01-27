using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace Assignment03.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            User user = new User();
            user.Name = Request.Form["UserName"];
            user.Email = Request.Form["email"];
            user.Password = Request.Form["Password"];
            user.Password2 = Request.Form["Password2"];
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return View("Submit", user);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Submit()
        {
            return View();
        }
        
    }
}