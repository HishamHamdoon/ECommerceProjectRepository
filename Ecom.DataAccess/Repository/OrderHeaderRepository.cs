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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        private readonly ApplicationDBContext _dbcontext;

        public OrderHeaderRepository(ApplicationDBContext applicationDBContext ):base( applicationDBContext )
        {
            _dbcontext = applicationDBContext;
        }
        public void Save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(OrderHeader orderHeader)
        {
            _dbcontext.Update(orderHeader);
            Save();
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus)
		{
            var orderfromDb = _dbcontext.OrderHeaders.FirstOrDefault( x => x.Id == id );
            if ( orderfromDb != null ) 
            { 
                orderfromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderfromDb.PaymentStatus = paymentStatus;
                }

            }
		}

		public void UpdateStripePaymentId(int id, string sessionId, string? paymentIntentId)
		{
			var orderfromDb = _dbcontext.OrderHeaders.FirstOrDefault(x=>x.Id == id);
            if ( orderfromDb != null )
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderfromDb.SessionId = sessionId;
                }
				if (!string.IsNullOrEmpty(paymentIntentId))
				{
					orderfromDb.PaymentIntentId = paymentIntentId;
                    orderfromDb.PaymentDate = DateTime.Now;
				}
			}
		}
	}
}
