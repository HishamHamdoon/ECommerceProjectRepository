using Ecom.DataAccess.Repository;
using Ecom.DataAccess.Repository.IRepository;
using Ecom.Models.Models;
using Ecom.Models.ViewModels;
using Ecom.Utitlity;
using ECommerceProject.Ecom.DataAccess.Data;
using ECommerceProject.Ecom.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.Role_User_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var companyList = _unitOfWork.Company.GetAll().ToList();
            return View(companyList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {

            Company company = new();
            
            if (id == null || id == 0)
            {
                //create
                return View(company);
            }
            else
            {
                //update 
                company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);

            }

        }
        [HttpPost]
        public IActionResult Upsert(Company obj)
        {

            if (ModelState.IsValid)
            {
                

               
                if (obj.Id == 0)
                {
                    //if (obj.Product.ImageUrl==null)
                    //{
                    _unitOfWork.Company.Add(obj);
                    TempData["success"] = "Company Created Successfully";
                    //}
                }
                else
                {
                    _unitOfWork.Company.Update(obj);
                    TempData["success"] = "Company Updated Successfully";

                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
               
                return View(obj);
            }
            //return View();

        }

        //[HttpPost]
        //public IActionResult Create(Company company)
        //{
        //    if (company.Name == company.Name.ToString())
        //    {
        //        ModelState.AddModelError("Name", "Company Name must not match Display order");
        //    }
        //    if (company.Name.ToLower() == "test")
        //    {
        //        ModelState.AddModelError("", "test is an invalid name for category");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Company.Add(company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Created Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company company = _unitOfWork.Company.Get(x => x.Id == id);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(company);
        //}
        //[HttpPost]
        //public IActionResult Edit(Company company)
        //{
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        _unitOfWork.Company.Update(company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Updated Successfully";
        //        return RedirectToAction("index");
        //    }
        //}
        //public IActionResult Delete(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Company company = _unitOfWork.Company.Get(x => x.Id == id);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(company);
        //}
 //       [HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        Company company = _unitOfWork.Company.Get(x => x.Id == id);
        //        if (company == null)
        //        {
        //            return NotFound();
        //        }
        //        _unitOfWork.Company.Remove(company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Deleted Successfully";
        //        return RedirectToAction("index");
        //    }
        //}

        #region api calls
        public IActionResult GetAll()
        {
            var companyList = _unitOfWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        public IActionResult Delete(int? id)
        {
            var companyToDelete = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToDelete == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            
            _unitOfWork.Company.Remove(companyToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Company deleted successfully" });
        }
        #endregion
    }
}
