using ECommerceProject.Ecom.Models;

namespace Ecom.DataAccess.Repository.IRepository
{
    public interface  ICategoryRepository:IRepository<Category>
    {
        void Update(Category category); 
        
    }
}
