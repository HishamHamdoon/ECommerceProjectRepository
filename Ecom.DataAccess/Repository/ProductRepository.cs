using Ecom.DataAccess.Repository.IRepository;
using Ecom.Models.Models;
using ECommerceProject.Ecom.DataAccess.Data;

namespace Ecom.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDBContext _dbcontext;

        public ProductRepository(ApplicationDBContext applicationDBContext ):base( applicationDBContext )
        {
            _dbcontext = applicationDBContext;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(Product product)
        {
            _dbcontext.Update(product);
            Save();
        }
    }
}
