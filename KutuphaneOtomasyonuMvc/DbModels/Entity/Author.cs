using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.DbModels.Entity
{
    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}