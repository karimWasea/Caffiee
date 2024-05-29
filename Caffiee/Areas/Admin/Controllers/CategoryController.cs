//using C_Utilities;

//using Cf_Viewmodels;
//using DataAcessLayers;
//using Interfaces;
//using Microsoft.AspNetCore.Mvc;
//using Servess;
//using System.Drawing.Printing;

//namespace Caffiee.Areas.Admin.Controllers
//{
//    [Area(ConstsntValuse.Admin)]

//    public class CategoryController : Controller
//    {
//        public readonly IUnitOfWork _ctx;

//        public CategoryController(IUnitOfWork ctx)
//        {
//            _ctx = ctx;
//        }

//        public IActionResult Index(int? page)
//        {
//            //_ctx._Category.GetAll();
//            //return View(_context.Categories.Select(x => new CategoryVm
//            //{
//            //    CategoryName = x.CategoryName,
//            //    Description = x.Description,
//            //    Id = x.Id,
//            //}).ToList());

//            int pageNumber = page ?? 1;
//            int pageSize = 10;
//            var categories = _ctx._Category.GetAll(pageNumber, pageSize);
//            return View(categories);
//        }

//        public IActionResult Details(int id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var category = _ctx._Category.Get(id);

//            if (category == null)
//            {
//                return NotFound();
//            }

//            return View(category);
//        }
//        public IActionResult Create()
//        {
//            return View();

//        }
//        [HttpPost]
//        public IActionResult Create(CategoryVm category)
//        {
//            if (ModelState.IsValid)
//            {
//                _ctx._Category.Create(category);
//                _ctx._Category.Save();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(category);

//        }
//        public IActionResult Edit(int id)
//        {
//            var product = _ctx._Category.Get(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(CategoryVm categoryVm)
//        {
//            if (ModelState.IsValid)
//            {
//                _ctx._Category.Update(categoryVm);
//                _ctx._Category.Save();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(categoryVm);
//        }
//        public IActionResult Delete(int id)
//        {
//            var category = _ctx._Category.Get(id);

//            if (category == null)
//            {
//                return NotFound();
//            }
//            return View(category);
//        }
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var category = _ctx._Category.Get(id);
//            if (category == null)
//            {
//                return NotFound();
//            }
//            _ctx._Category.Delete(id);
//            _ctx._Category.Save();
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
