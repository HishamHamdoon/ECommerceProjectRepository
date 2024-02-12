using Ecom.DataAccess.Repository.IRepository;
using Ecom.DataAccess.Repository;
using ECommerceProject.Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Ecom.DataAccess.Data;

namespace Ecom.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _dbcontext;

        public CategoryRepository(ApplicationDBContext applicationDBContext ):base( applicationDBContext )
        {
            _dbcontext = applicationDBContext;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(Category category)
        {
            _dbcontext.Update(category);
            Save();
        }
    }
}
