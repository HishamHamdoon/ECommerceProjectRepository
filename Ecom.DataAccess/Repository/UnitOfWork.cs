using Ecom.DataAccess.Repository.IRepository;
using ECommerceProject.Ecom.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //initialise interfaces
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

       // IOrderHeaderRepository IUnitOfWork.OrderHeader => throw new NotImplementedException();

        private readonly ApplicationDBContext _dbcontext;

        public UnitOfWork(ApplicationDBContext applicationDBContext)
        {
            _dbcontext = applicationDBContext;
            Category = new CategoryRepository(_dbcontext);
            Product = new ProductRepository(_dbcontext);
            Company = new CompanyRepository(_dbcontext);
            ShoppingCart = new ShoppingCartRepository(_dbcontext);
            OrderDetail = new OrderDetailRepository(_dbcontext);
            OrderHeader = new OrderHeaderRepository(_dbcontext);
            ApplicationUser = new ApplicationUserRepository(_dbcontext);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}
