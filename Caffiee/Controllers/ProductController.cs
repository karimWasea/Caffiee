using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servess;

namespace Caffiee.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _ctx;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _ctx = unitOfWork;
        }

        // GET: Products
        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 10;
            var products = _ctx._Product.GetAll(pageNumber,pageSize);
            return View(products);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _ctx._Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            PopulateCategoriesDropDownList();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVm productVm)
        {
            if (ModelState.IsValid)
            {
                _ctx._Product.Create(productVm);
                _ctx._Product.Save();
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(productVm.CategoryId);
            return View(productVm);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _ctx._Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateCategoriesDropDownList(product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductVm productVm)
        {
            if (ModelState.IsValid)
            {
                _ctx._Product.Update(productVm);
                _ctx._Product.Save();
                return RedirectToAction(nameof(Index));
            }
            PopulateCategoriesDropDownList(productVm.CategoryId);
            return View(productVm);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _ctx._Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ctx._Product.Delete(id);
            _ctx._Product.Save();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateCategoriesDropDownList(object selectedCategory = null)
        {
            var categoriesQuery = from c in _ctx._Category.GetAll()
                                  orderby c.CategoryName
                                  select c;

            ViewBag.CategoryId = new SelectList(categoriesQuery, "Id", "CategoryName", selectedCategory);
        }
    }
}
