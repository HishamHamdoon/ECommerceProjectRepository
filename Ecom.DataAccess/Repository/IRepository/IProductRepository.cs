using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface IProductRepository:IRepository<Product>
    {
        void Update(Product product); 
        
    }
}
