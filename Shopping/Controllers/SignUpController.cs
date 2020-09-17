using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Shopping.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult AddOrEdit()
        {
            User dbModel = new User();
            return  View();
        }
        [HttpPost]
        public ActionResult send(User user)
        {
           using(DBModels db=new DBModels())
            {
                db.Users.Add(user);
                db.SaveChanges();

            }

            return RedirectToAction("Login", "Login");
        }
    }
}