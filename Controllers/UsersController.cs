using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LibraryAppMVC.Data;
using System.Runtime;
using LibraryAppMVC.Models;

namespace LibraryAppMVC.Controllers
{
    public class UsersController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.LibraryCard);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
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
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.LibraryCards, "UserID", "UserID");
            return View();
        }

        // POST: Users/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Email,DateOfBirth,Password,PswdConfirmed,Login")] User user)
        {
            if (ModelState.IsValid)
            {
                var isEmailExist = IsEmailExist(user.Email);
                if (isEmailExist)
                {
                    ModelState.AddModelError("EmailExist", "Ponady Email już istnieje");
                    return View(user);
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.LibraryCards, "UserID", "UserID", user.UserID);
            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser loginUser, string ReturnUrl="")
        {
            User user = db.Users.FirstOrDefault(s => s.Login == loginUser.Login);
            if(user != null)
            {
                if(string.Compare(user.Password, loginUser.Password) == 0)
                {
                    int time_out = loginUser.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(loginUser.Login, loginUser.RememberMe, time_out);
                    string encrypt = FormsAuthentication.Encrypt(ticket);
                    var cookies = new HttpCookie(FormsAuthentication.FormsCookieName, encrypt);
                    cookies.Expires = DateTime.Now.AddMinutes(time_out);
                    cookies.HttpOnly = true;
                    Response.Cookies.Add(cookies);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                        
                    }
                }
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.UserID = new SelectList(db.LibraryCards, "UserID", "UserID", user.UserID);
            return View(user);
        }

        // POST: Users/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,DateOfBirth")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.LibraryCards, "UserID", "UserID", user.UserID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
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
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [NonAction]
        private bool IsEmailExist(string email)
        {
            User user = db.Users.Where(a => a.Email == email).FirstOrDefault();
            return user != null;
        } //metoda sprawdzająca czy podany mail już istnieje
    }

    
}
