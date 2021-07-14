using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.DbModels.Entity
{
    public class Category
    {
        public Category()
        {
            this.Books = new List<Book>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}