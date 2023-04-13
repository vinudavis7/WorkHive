using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public  interface ICategoryRepository
    {
        public List<Category> GetCategories(AppDbContext context);
        public List<Category> GetPopularCategories(AppDbContext context);
        public Category GetCategoryDetails(AppDbContext context,int categoryId);
        public Category Createcategory(AppDbContext context,string category);
        public Category UpdateCategory(AppDbContext context,Category category);
        public void AddJobToCollection(AppDbContext context, Job job, Category category);

    }
}
