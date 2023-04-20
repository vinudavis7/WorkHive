using BLL.Interface;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Categories> GetCategories()
        {
            try
            {
                return _categoryRepository.GetCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
