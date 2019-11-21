using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovelTee.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Created { get; set; }
    }
}