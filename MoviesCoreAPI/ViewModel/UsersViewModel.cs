using MoviesCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCoreAPI.ViewModel
{
    public class UsersViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static implicit operator UsersViewModel(Users user)
        {
            return new UsersViewModel
            {
                UserID = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Username = user.Username,
                Email = user.Email,
            };
        }

        public static implicit operator Users(UsersViewModel userViewModel)
        {
            return new Users
            {
                UserID = userViewModel.UserID,
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                Password = userViewModel.Password,
                Username = userViewModel.Username,
                Email = userViewModel.Email,
            };
        }

    }
}
