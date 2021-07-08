using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var loginUser = HttpContext.Session["LoginUser"] as User;

            var ctx = new DatabaseContext();
            List<HomeIndexViewModel> model = ctx.Users.ToList().Select(p => new HomeIndexViewModel() { FirstName = p.FirstName, LastName = p.LastName }).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}