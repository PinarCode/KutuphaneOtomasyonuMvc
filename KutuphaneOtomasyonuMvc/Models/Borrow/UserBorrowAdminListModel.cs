using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.Models.Borrow
{
    public class UserBorrowAdminListModel
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BorrowStartDate { get; set; }
        public string BorrowEndDate { get; set; }
    }
}