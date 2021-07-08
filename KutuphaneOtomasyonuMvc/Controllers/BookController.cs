using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.Book;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class BookController : Controller
    {
        // GET: Book
        DatabaseContext db = new DatabaseContext();
        public ActionResult BookToList()
        {
            var book = db.Books.ToList();
            return View(book);
        }
       
        public ActionResult Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("BookToList");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            List<SelectListItem> categories = (from i in db.Categories.ToList() select new SelectListItem { Text = i.CategoryName, Value = i.Id.ToString() }).ToList();
            ViewBag.category = categories;

            List<SelectListItem> authors = db.Authors.ToList().Select(j => new SelectListItem() { Text = string.Format("{0} {1}", j.FirstName, j.LastName), Value = j.Id.ToString() }).ToList();
            ViewBag.author = authors;
            return View();
        }
        [HttpPost]
        public ActionResult Insert(BookModel model)
        {
            var book = new Book() { AuthorId = model.AuthorId, CategoryId = model.CategoryId, BookName = model.BookName, PageNumber = model.PageNumber, ShelfNumber = model.ShelfNumber };


            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("BookToList");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var book = db.Books.FirstOrDefault(p => p.Id == id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Update(BookModel category)
        {
            var entity = db.Books.FirstOrDefault(p => p.Id == category.Id);
            entity.CategoryId = category.CategoryId;
            entity.AuthorId = category.AuthorId;
            entity.BookName = category.BookName;
            entity.ShelfNumber = category.ShelfNumber;
            entity.PageNumber = category.PageNumber;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return View(entity);
        }
    }
}