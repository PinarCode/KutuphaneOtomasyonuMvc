using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneOtomasyonuMvc.Constant;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DatabaseContext db = new DatabaseContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var kullanici = db.Users.FirstOrDefault(k => k.Email == model.Email && k.Password == model.Password);
            if(kullanici != null)
            {
                HttpContext.Session["LoginUser"] = kullanici;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}