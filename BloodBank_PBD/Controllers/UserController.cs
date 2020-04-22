﻿using BloodBank_PBD.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BloodBank_PBD.Controllers
{
    public class UserController : Controller
    {
        private Blood_Bank_Entities db = new Blood_Bank_Entities();
        private string[] bloodTypes = { "O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+" };

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Where(x => x.UserName.Equals(user.UserName)).Count() != 0)
                {
                    ViewBag.UserExistError = "User already exists";

                    return RedirectToAction("SignUp", "Home", user);
                }

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

            return RedirectToAction("SignUp", "Home", user);
        }

        public ActionResult UpdateUser(int id)
        {
            User user = db.Users.Find(id);
            ViewBag.BloodTypes = new SelectList(bloodTypes);

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("GetAllUsers");
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

            return View(user);
        }

        public ActionResult UpdateUserInfo(string username)
        {
            User user = db.Users.Where(m => m.UserName.Equals(username)).FirstOrDefault();
            ViewBag.BloodTypes = new SelectList(bloodTypes);

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUserInfo(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Password)));

                try
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("UpdateUserInfo", user);
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

            ViewBag.BloodTypes = new SelectList(bloodTypes);

            return View(user);
        }

        public ActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }

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