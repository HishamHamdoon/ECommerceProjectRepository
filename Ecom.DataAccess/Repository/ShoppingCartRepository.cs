using Ecom.DataAccess.Repository.IRepository;
using Ecom.DataAccess.Repository;
using ECommerceProject.Ecom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Ecom.DataAccess.Data;
using Ecom.Models.Models;

namespace Ecom.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDBContext _dbcontext;

        public ShoppingCartRepository(ApplicationDBContext applicationDBContext ):base( applicationDBContext )
        {
            _dbcontext = applicationDBContext;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _dbcontext.ShoppingCarts.Update(shoppingCart);
            Save();
        }
    }
}
