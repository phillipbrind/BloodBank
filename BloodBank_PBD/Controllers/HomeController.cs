using BloodBank_PBD.Models;
using BloodBank_PBD.ViewModel;
using BloodBank_PBD.ViewModel.MessageViewModel;
using System;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class HomeController : Controller
    {
        private const string ADMIN = "admin";
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

            string encrypted_pass = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(ulm.Password)));

            if (db.Users.Where(x => x.UserName.Equals(ulm.UserName) && x.Password.Equals(encrypted_pass)).Count() == 0)
            {
                ViewBag.PasswordError = "You entered an incorrect password";

                return View(ulm);
            }

            Session["Username"] = ulm.UserName;
            Session["Role"] = ulm.UserName.Equals(ADMIN) ? "Admin" : "User";

            return View("Index");
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            string[] bloodTypes = { "O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+" };
            ViewBag.BloodTypes = new SelectList(bloodTypes);

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User user)
        {
            System.Diagnostics.Debug.WriteLine("phdespi: " + user.UserName);

            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AddContactMessage(Message message)
        {
            Blood_Bank_InfoEntities contactDB = new Blood_Bank_InfoEntities();

            if (ModelState.IsValid)
            {
                try
                {
                    contactDB.Messages.Add(message);
                    contactDB.SaveChanges();
                    string statusMessage = "Message sent";

                    return RedirectToAction("ShowStatusMessage", new { statusMessage = statusMessage });
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
            }

            return View("Contact", message);
        }

        public ActionResult ShowStatusMessage(string statusMessage)
        {
            ViewBag.StatusMessage = statusMessage;

            return View("Contact");
        }

    }
}