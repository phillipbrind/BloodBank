using BloodBank_PBD.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class TestController : Controller
    {
        private Blood_Bank_Entities db = new Blood_Bank_Entities();

        public ActionResult CreateTest(Test test)
        {
            try
            {
                db.Tests.Add(test);
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