using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DatabaseContext db = new DatabaseContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            User user = new User();
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserAddress = model.UserAddress;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            user.Password = model.Password;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login","Login");
        }
    }
}