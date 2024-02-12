using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail orderDetail); 
        
    }
}
