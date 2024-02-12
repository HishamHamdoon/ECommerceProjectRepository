using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface  ICompanyRepository:IRepository<Company>
    {
        void Update(Company company); 
        
    }
}
