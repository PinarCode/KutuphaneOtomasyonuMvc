using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.Models.Borrow
{
    public class UserBorrowModeli
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BorrowStartDate { get; set; }
        public DateTime BorrowEndDate { get; set; }
    }
}