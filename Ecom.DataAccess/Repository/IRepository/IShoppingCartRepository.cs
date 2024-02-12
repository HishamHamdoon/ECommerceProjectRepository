using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository:IRepository<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart); 
        
    }
}
