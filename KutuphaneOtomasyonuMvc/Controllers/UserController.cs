using KutuphaneOtomasyonuMvc.Constant;
using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class UserController : Controller
    {
        // GET: User
        DatabaseContext db = new DatabaseContext();
        public ActionResult UserToList()
        {
            var users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserToList");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var user = db.Users.FirstOrDefault(p=> p.Id == id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Update(UserModel user)
        {
            var entity = db.Users.FirstOrDefault(p => p.Id == user.Id);
            entity.UserName = user.UserName;
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.UserAddress = user.UserAddress;
            entity.PhoneNumber = user.PhoneNumber;
            db.Users.Add(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return View(entity);
        }
       
    }
}