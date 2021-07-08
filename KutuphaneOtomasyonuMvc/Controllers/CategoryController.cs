using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.Category;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class CategoryController : Controller
    {
        // GET: Category
        DatabaseContext db = new DatabaseContext();
        public ActionResult CategoryToList()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryToList");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = db.Categories.FirstOrDefault(p => p.Id == id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Update(CategoryModel category)
        {
            var entity = db.Categories.FirstOrDefault(p => p.Id == category.Id);
            entity.CategoryName = category.CategoryName;
            db.Categories.Add(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return View(entity);
        }
    }
}