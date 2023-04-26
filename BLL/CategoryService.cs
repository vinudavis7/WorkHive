using BLL.Interface;
using DAL;
using DAL.Repository;
using DAL.Repository.Interface;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetCategories()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _categoryRepository.GetCategories(context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Category GetCategory(int categoryId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _categoryRepository.GetCategoryDetails(context, categoryId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  List<Category> GetPopularCategories()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return  _categoryRepository.GetPopularCategories(context);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Category Createcategory(string categoryName)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                   var category=  _categoryRepository.Createcategory(context, categoryName);
                    context.SaveChanges();
                    return category;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Category UpdateCategory(Category category)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return _categoryRepository.UpdateCategory(context,category);
                    context.SaveChanges();
                    return category;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
