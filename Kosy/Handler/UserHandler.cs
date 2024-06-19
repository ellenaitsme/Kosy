using Kosy.Models;
using Kosy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kosy.Handler
{
    public class UserHandler
    {
        UserRepository userRepo = new UserRepository();

        public User ValidateUser(string username, string password)
        {
            User user = userRepo.GetUserByUsername(username);
            if (user != null && user.UserPassword == password)
            {
                return user;
            }
            return null;
        }

        public bool IsUsernameUnique(string username)
        {
            return userRepo.IsUsernameUnique(username);
        }

        public void RegisterUser(string username, string email, DateTime dob, string gender, string password)
        {
            int id = userRepo.GenerateId();
            userRepo.RegisterUser(id, username, email, dob, gender, "User", password);
        }

        public User GetUserById(int id)
        {
            return userRepo.GetUserById(id);
        }

        public List<User> GetAllCustomers()
        {
            return userRepo.GetUsersByRole();
        }

        public void UpdateUser(User user)
        {
            userRepo.UpdateUser(user);
        }
    }
}