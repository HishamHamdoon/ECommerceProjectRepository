using Ecom.DataAccess.Repository;
using Ecom.DataAccess.Repository.IRepository;
using Ecom.Models.Models;
using ECommerceProject.Ecom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ECommerceProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(products);
        }
		public IActionResult Summary()
		{
			IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
			return View(products);
		}

		public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int productId)
        {
            if (productId == 0 || productId == null)
            {
                return NotFound();
            }
            var dbProduct = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category");
            if (dbProduct ==null)
            {
                return NotFound();
            }
        ShoppingCart cart = new ()
        {
                Product = dbProduct,
                ProductId = productId,
                Count=1
        };
        return View(cart);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Details(ShoppingCart shoppinCart)
    {
            var claimsIdentity = (ClaimsIdentity)(User).Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppinCart.ApplicationUserId = userId;
            ShoppingCart cartfromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId
            && u.ProductId == shoppinCart.ProductId);

            if (cartfromDb != null)
            {
                //shopping cart is exist
                cartfromDb.Count += shoppinCart.Count;
                _unitOfWork.ShoppingCart.Update(cartfromDb);
            }
            else
            {

                _unitOfWork.ShoppingCart.Add(shoppinCart);
            }

            _unitOfWork.Save();
            TempData["success"] = "Product added to Cart successfully :)";
            return RedirectToAction(nameof(Index));
     }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    }
}