using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public  interface ICategoryService
    {
        public List<Category> GetCategories();
        public List<Category> GetPopularCategories();
        public Category GetCategory(int categoryId);
        public Category Createcategory(Category category);
        public Category UpdateCategory(Category category);
    }
}
