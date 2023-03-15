using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public  interface IUserRepository
    {
        public List<User> GetUsers();
        public User GetUserDetails(int userId);

        public User GetUserDetails(string username, string password);
        public User CreateUser(User user);
    }
}
