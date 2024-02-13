using Ecom.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }
        public IActionResult Index()
		{
			return View();
		}


		#region api calls
		public IActionResult GetAll()
		{
			var orderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
			return Json(new { data = orderList });
		}
		
		#endregion
	}
}
