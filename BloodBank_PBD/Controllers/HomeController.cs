using BloodBank_PBD.Models;
using BloodBank_PBD.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class HomeController : Controller
    {
        private Blood_Bank_Entities db = new Blood_Bank_Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel ulm)
        {
            if (db.Users.Where(x => x.UserName.Equals(ulm.UserName)).Count() == 0)
            {
                ViewBag.UserError = "Username does not exists";

                return View(ulm);
            }
            else
            {
                string encrypted_pass = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(ulm.Password)));

                if (db.Users.Where(x => x.UserName.Equals(ulm.UserName) && x.Password.Equals(encrypted_pass)).Count() == 0)
                {
                    ViewBag.PasswordError = "You entered an incorrect password";

                    return View(ulm);
                }
            }

            Session["Username"] = ulm.UserName;

            return View("Index");
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}