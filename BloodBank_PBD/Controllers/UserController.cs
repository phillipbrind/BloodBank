using BloodBank_PBD.Models;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class UserController : Controller
    {
        Blood_Bank_Entities db = new Blood_Bank_Entities();

        public ActionResult CreateUser(User user)
        {
            user.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));

            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var ex in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", ex.Entry.Entity.GetType().Name, ex.Entry.State);

                    foreach (var se in ex.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            se.PropertyName, se.ErrorMessage);
                    }
                }
                throw;
            }

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