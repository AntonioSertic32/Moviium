using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesCoreAPI.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Records> Records { get; set; }
    }
}
