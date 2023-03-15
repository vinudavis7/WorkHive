using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<User> GetUsers()
        {
            try
            {
                return _userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public User GetUserDetails(int userId)
        {
            try
            {
                return _userRepository.GetUserDetails(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserDetails(string username, string password)
        {
            try
            {
                return _userRepository.GetUserDetails(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User CreateUser(User user)
        {
            try
            {
                return _userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
