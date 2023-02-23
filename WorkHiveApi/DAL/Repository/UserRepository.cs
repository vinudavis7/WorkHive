using DAL.Repository.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public  UserRepository(AppDbContext dbContext)
            {
            _dbContext = dbContext;
            }
       public  IList<Users> GetUsers()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
