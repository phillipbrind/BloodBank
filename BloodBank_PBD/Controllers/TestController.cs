using BloodBank_PBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class TestController : Controller
    {
        Blood_Bank_Entities db = new Blood_Bank_Entities();

        public ActionResult CreateTest(Test test)
        {
            db.Tests.Add(test);
            db.SaveChanges();

            return View();
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