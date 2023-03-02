using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _dbContext;

        public JobRepository(AppDbContext dbContext)
            {
              _dbContext = dbContext;
            }
       public  List<Jobs> GetJobs()
        {
            try
            {
                return _dbContext.Jobs.Include(b => b.Category).Include(b => b.Client).ToList();
               // return _dbContext.Jobs.Include("Categories").ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
