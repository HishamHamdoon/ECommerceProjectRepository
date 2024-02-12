using Ecom.DataAccess.Repository;
using Ecom.DataAccess.Repository.IRepository;
using Ecom.Models.Models;
using Ecom.Models.ViewModels;
using Ecom.Utitlity;
using ECommerceProject.Ecom.DataAccess.Data;
using ECommerceProject.Ecom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ECommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_User_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }
        [HttpGet]
        public IActionResult Upsert(int ? id)
        {
            
                ProductVM productVM = new()
                {
                    CategoryList = _unitOfWork.Category.GetAll(u=>u.Id==id).Select(u => new SelectListItem
               {
                   Text = u.Name,
                   Value = u.Id.ToString(),
               }),
                    Product = new Product()
                };
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update 
                productVM.Product = _unitOfWork.Product.Get(u => u.Id==id);
                return View(productVM);

            }
           
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");
                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //delete old file
                        var oldImageUrl = Path.Combine(wwwRootPath,obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);

                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.Product.ImageUrl = @"\images\product\" +filename; 
                }
                if (obj.Product.Id==0)
                {
                    //if (obj.Product.ImageUrl==null)
                    //{
                        _unitOfWork.Product.Add(obj.Product);
                        TempData["success"] = "Product Created Successfully";
                    //}
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                    TempData["success"] = "Product Updated Successfully";

                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ProductVM productVM = new()
                {
                    CategoryList = _unitOfWork.Category.GetAll().Select
                    (u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString(),
                    }),
                    Product = new Product()
                };
                return View(productVM);
            }
            //return View();

        }
       
        
        
        [HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Category category = _unitOfWork.Category.Get(x => x.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Product product = _unitOfWork.Product.Get(x => x.Id == id);
        //        if (product == null)
        //        {
        //            return NotFound();
        //        }
        //        _unitOfWork.Product.Remove(product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product Deleted Successfully";
        //        return RedirectToAction("index");
        //    }
        //}
        #region api calls
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return Json(new { data = productList });
        }
         
        public IActionResult Delete(int? id)
        {
            var productToDelete = _unitOfWork.Product.Get(u=>u.Id == id);
            if (productToDelete == null)
            {
                return Json(new { success = false,message= "Error while deleting" });
            }
            var oldImagePath = Path.Combine(
                _webHostEnvironment.WebRootPath, productToDelete.ImageUrl.TrimStart('\\')
                );
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Product.Remove(productToDelete);
            _unitOfWork.Save();

            return Json(new { success = true,message = "Product deleted successfully"});
        }
        #endregion


    }
}
