using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneOtomasyonuMvc.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}