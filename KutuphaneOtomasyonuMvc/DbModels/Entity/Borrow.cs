using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.DbModels.Entity
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime BarrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}