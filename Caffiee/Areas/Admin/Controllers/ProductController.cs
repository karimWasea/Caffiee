using C_Utilities;

using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servess;

namespace Caffiee.Areas.Admin.Controllers
{
    [Area(ConstsntValuse.Admin)]

    public class ProductController :  BaseController
    {

        public ProductController(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        // GET: Products
        [Route("Admin/Product/Index")]

        public IActionResult Index(productVM Entity, int? page )
        {
            int pageNumber = page ?? 1;

            Entity.PageNumber = pageNumber; 
            var products = _unitOfWork._Product.Search(Entity);
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _unitOfWork._Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Save(int Id)
        {
            if (Id > 0)
            {

                var product = _unitOfWork._Product.Get(Id);
                product.CategoryIdList = _unitOfWork._Ilookup.GetCategories();


                return View(product);

            }
            else
            { var Poduct= new productVM();
                Poduct.CategoryIdList = _unitOfWork._Ilookup.GetCategories();

                return View(Poduct);


            }

        }

        

        // POST: Products/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Save(productVM productVm)
        {
            productVm.CategoryIdList = _unitOfWork._Ilookup.GetCategories();
            ModelState.Remove("CategoryName");

            if (!ModelState.IsValid)
            {
                return View(productVm);

            }
             if(!_unitOfWork._Product .CheckIfExisit(productVm))
            {
                _unitOfWork._Product.Save(productVm);
                TempData["Message"] = $" successfully Add!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));


            }
            TempData["Message"] = $" cannott save!";
            TempData["MessageType"] = "Delete";

            return View(productVm);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork._Product.Delete(id);
                 return Json(new { success = true, message = "Successfully deleted!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }




    }
}
