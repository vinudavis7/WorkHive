using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Interface
{
    public interface ICategoryRepository
    {
        public List<Categories> GetCategories();

    }
}
