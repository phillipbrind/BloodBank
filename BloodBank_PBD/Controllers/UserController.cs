using BloodBank_PBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class UserController : Controller
    {
        Blood_Bank_Entities db = new Blood_Bank_Entities();

        public ActionResult CreateUser(User user)
        {
            user.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));

            db.Users.Add(user);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateUser()
        {
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("GetAllUsers");
        }

        public ActionResult GetUser()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            return View(db.Users.ToList());
        }
    }
}