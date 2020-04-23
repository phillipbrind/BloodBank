﻿using BloodBank_PBD.Models;
using System.Collections.Generic;
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
            foreach (User user in userlist)
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
            if (ModelState.IsValid)
            {
                try
                {
                    db.Tests.Add(test);
                    db.SaveChanges();

                    return View("GetAllTests");
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

            List<User> userlist = db.Users.ToList();
            List<string> fullname = new List<string>();
            foreach (User user in userlist)
            {
                fullname.Add(user.FirstName + " " + user.LastName);
            }
            ViewBag.FullNameList = new SelectList(fullname);
            ViewBag.Progress = new SelectList(progress);

            return View(test);
        }

        public ActionResult UpdateTest()
        {
            return View();
        }

        public ActionResult DeleteTest(int id)
        {
            Test test = db.Tests.Find(id);
            db.Tests.Remove(test);
            db.SaveChanges();

            return View();
        }

        public ActionResult GetTest()
        {
            return View();
        }

        public ActionResult GetAllTests()
        {
            return View(db.Tests.ToList());
        }
    }
}