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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Categories> GetCategories()
        {
            try
            {
                return _dbContext.Categories.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
