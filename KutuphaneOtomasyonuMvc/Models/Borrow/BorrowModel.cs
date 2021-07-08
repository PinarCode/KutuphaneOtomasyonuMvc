using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.Models.Borrow
{
    public class BorrowModel
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public string ShelfNumber { get; set; }
        public int PageNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}