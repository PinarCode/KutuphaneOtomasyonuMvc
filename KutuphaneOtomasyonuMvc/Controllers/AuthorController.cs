using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.Author;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class AuthorController : Controller
    {
        // GET: Author
        DatabaseContext db = new DatabaseContext();
        public ActionResult AuthorToList()
        {
            var author = db.Authors.ToList();
            return View(author);
        }
        public ActionResult Delete(int id)
        {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("AuthorToList");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var author = db.Authors.FirstOrDefault(p => p.Id == id);
            return View(author);
        }
        [HttpPost]
        public ActionResult Update(AuthorModel author)
        {
            var entity = db.Authors.FirstOrDefault(p => p.Id == author.Id);
            entity.FirstName = author.FirstName;
            entity.LastName = author.LastName;
            db.Authors.Add(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return View(entity);
        }
    }
}