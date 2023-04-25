using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetCategories(AppDbContext _dbContext)
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
        public Category GetCategoryDetails(AppDbContext _dbContext, int categoryId)
        {
            try
            {
                return _dbContext.Categories.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category Createcategory(AppDbContext _dbContext, string categoryName)
        {
            try
            {
                Category category = new Category();
                category.CategoryName = categoryName;
                _dbContext.Categories.Add(category);
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category UpdateCategory(AppDbContext _dbContext, Category category)
        {
            try
            {
                var obj = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
                obj.CategoryName = category.CategoryName;
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Category> GetPopularCategories(AppDbContext _dbContext)
        {
            try
            {
                var recentCategories = _dbContext.Categories.Include(cat=>cat.Jobs).OrderByDescending(cat => cat.Jobs.Count).Take(5).ToList();
                return recentCategories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddJobToCollection(AppDbContext context, Job job, Category category)
        {
            category.Jobs.Add(job);
        }
    }
}
