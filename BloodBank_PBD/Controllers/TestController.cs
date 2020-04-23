using BloodBank_PBD.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class TestController : Controller
    {
        private Blood_Bank_Entities db = new Blood_Bank_Entities();
        private string[] progress = { "Submitted", "Processed", "Completed" };

        public ActionResult CreateTest()
        {
            List<User> userlist = db.Users.ToList();
            List<string> fullname = new List<string>();
            foreach (var user in userlist)
            {
                fullname.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.FullNameList = new SelectList(fullname);
            ViewBag.Progress = new SelectList(progress);

            return View();
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            List<User> userlist = db.Users.ToList();

            if (ModelState.IsValid)
            {
                foreach (var user in userlist)
                {
                    if (test.DonorFullName.StartsWith(user.FirstName) && test.DonorFullName.EndsWith(user.LastName))
                    {
                        test.UserId = user.UserId;
                        break;
                    }
                }

                try
                {
                    db.Tests.Add(test);
                    db.SaveChanges();

                    return RedirectToAction("GetAllTests");
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

            List<string> fullname = new List<string>();
            foreach (var user in userlist)
            {
                fullname.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.FullNameList = new SelectList(fullname);
            ViewBag.Progress = new SelectList(progress);

            return View(test);
        }

        public ActionResult UpdateTest(Test test)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(test).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("GetAllTests");
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

            return View();
        }

        public ActionResult DeleteTest(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();

            return View();
        }

        public ActionResult GetTest(string username)
        {
            return View(db.Tests.Where(m => m.User.UserName.Equals(username)).ToList());
        }

        public ActionResult GetAllTests()
        {
            return View(db.Tests.ToList());
        }
    }
}