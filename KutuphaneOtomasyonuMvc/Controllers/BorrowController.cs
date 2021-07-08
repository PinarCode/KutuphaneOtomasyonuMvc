using KutuphaneOtomasyonuMvc.DbModels.Context;
using KutuphaneOtomasyonuMvc.DbModels.Entity;
using KutuphaneOtomasyonuMvc.Filter;
using KutuphaneOtomasyonuMvc.Models.Borrow;
using KutuphaneOtomasyonuMvc.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneOtomasyonuMvc.Controllers
{
    [AuthFilter]
    public class BorrowController : Controller
    {
        // GET: Borrow
        DatabaseContext db = new DatabaseContext();
        [HttpGet]
        public ActionResult BorrowToBook(int id)
        {
            var book = db.Books.Where(p => p.Id == id).FirstOrDefault();
            var author = db.Authors.FirstOrDefault(p => p.Id == book.AuthorId);

            BorrowModel model = new BorrowModel()
            {
                AuthorId = author.Id,
                BookId = id,
                BookName = book.BookName,
                PageNumber = book.PageNumber,
                ShelfNumber = book.ShelfNumber,
                FirstName = author.FirstName,
                LastName = author.LastName,
                UserId = (HttpContext.Session["LoginUser"] as User).Id
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult BorrowToBook(BorrowModel model)
        {
            var borrow = new Borrow() { UserId = model.UserId, BookId = model.BookId, BarrowDate = model.BarrowDate, ReturnDate = model.ReturnDate };
            db.Borrows.Add(borrow);
            db.SaveChanges();
            return RedirectToAction("BorrowList");
        }
        public ActionResult BorrowList()
        {
            var userId = (HttpContext.Session["LoginUser"] as User).Id;
            var entity = db.Borrows.Where(p => p.UserId == userId).ToList();

            List<UserBorrowModeli> model = new List<UserBorrowModeli>();

            foreach (var item in entity)
            {
                var author = db.Books.FirstOrDefault(p => p.Id == item.BookId).Author;

                UserBorrowModeli userBorrow = new UserBorrowModeli()
                {
                    BookAuthor = string.Format("{0} {1}", author.FirstName, author.LastName),
                    BookName = item.Book.BookName,
                    BorrowEndDate = item.ReturnDate,
                    BorrowStartDate = item.BarrowDate
                };

                model.Add(userBorrow);
            }

            return View(model);
        }

        public ActionResult BorrowListForAdmin()
        {
            List<SelectListItem> users = db.Users.ToList().Select(j => new SelectListItem() { Text = string.Format("{0} {1}", j.FirstName, j.LastName), Value = j.Id.ToString() }).ToList();
            ViewBag.user = users;
            return View();
        }

        public ActionResult BorrowListForAdminData(int userId)
        {
            var user = db.Borrows.Where(p => p.UserId == userId).ToList();
            List<UserBorrowAdminListModel> model = new List<UserBorrowAdminListModel>();

            foreach (var item in user)
            {
                var author = db.Books.FirstOrDefault(p => p.Id == item.BookId).Author;

                UserBorrowAdminListModel userBorrow = new UserBorrowAdminListModel()
                {
                    BookAuthor = string.Format("{0} {1}", author.FirstName, author.LastName),
                    BookName = item.Book.BookName,
                    BorrowEndDate = item.ReturnDate.ToString("dd/MM/yyyy"),
                    BorrowStartDate = item.BarrowDate.ToString("dd/MM/yyyy")
                };

                model.Add(userBorrow);
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Delete(int id)
        {
            var borrow = db.Borrows.Find(id);
            db.Borrows.Remove(borrow);
            db.SaveChanges();
            return RedirectToAction("BorrowList");
        }
    }
}