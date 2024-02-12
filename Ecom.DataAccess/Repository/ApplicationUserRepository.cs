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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDBContext _dbcontext;

        public ApplicationUserRepository(ApplicationDBContext applicationDBContext ):base( applicationDBContext )
        {
            _dbcontext = applicationDBContext;
        }
        
    }
}
