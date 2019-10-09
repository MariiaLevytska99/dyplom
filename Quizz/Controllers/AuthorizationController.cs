using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Quizz.Models;
using Quizz.Repository;

namespace Quizz.Controllers
{
    public class AuthorizationController : Controller
    {
        private QuizzDbContext db = new QuizzDbContext();
        // GET: Authorization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
        public ActionResult Registration()
        {
            ViewBag.Message = "Your login page";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "User_ID,Firstname,LastName,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Password")] User user)
        {
                User find_u = db.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();
                if(find_u == null)
                {
                    return RedirectToAction("Login");
                }


            return RedirectToRoute(new { controller = "UserPage", action = "Index" });       
        }
        [HttpGet]
        public ActionResult Enterance(string Email, string Password)
        {
            if (Email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Where(u=>u.Email.Equals(Email) && u.Password.Equals(Password)).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Registration");
        }
        public ActionResult Enter()
        {
            User user = new User
            {
                Email = "oleg.zubach@gmail.com",
                Password = "123456789"
            };
            if (ModelState.IsValid)
            {
               
                using (QuizzDbContext db = new QuizzDbContext())
                {
                    var obj = db.Users.Where(u => u.Email.Equals("oleg.zubach@gmail.com") && u.Password.Equals("123456789")).FirstOrDefault();
                    if (obj != null)
                    {
                        return RedirectToAction("Registration");
                    }
                }
            }
            ViewBag.Message = "Your registration page";

            return RedirectToAction("Login");
 
        }
      /*  [HttpPost]
        public ActionResult Enter(User user)
        {
          if(ModelState.IsValid)
            {
                using (QuizzDbContext db = new QuizzDbContext())
                {
                    var obj = db.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();
                    if(obj != null)
                    {
                        return RedirectToAction("Registration");
                    }
                }
            }
           return View(user);
           // return View();
        }*/
        // GET: Users/Edit/5
        /*  public ActionResult Edit(int? id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              User user = db.Users.Find(id);
              if (user == null)
              {
                  return HttpNotFound();
              }
              return View(user);
          }*/

       /* public ActionResult Edit([Bind(Include = "User_ID,Firstname,LastName,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }*/
    }
}
