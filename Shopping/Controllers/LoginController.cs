using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(User u)
        {
            using (DBModels db = new DBModels())
            {
                var a = db.Users.Where(x => x.UserName == u.UserName && x.Password == u.Password).FirstOrDefault();
                if (a ==null)
                {
                    u.ErrorMesssage = "Wrong Password";
                    return View("Login", u);
                }
                else
                {
                    Session["UserId"] = u.UserId;
                    return RedirectToAction("Products", "Product");//action name,  controller name                
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}