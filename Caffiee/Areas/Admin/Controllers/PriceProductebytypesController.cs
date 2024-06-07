﻿using C_Utilities;

using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servess;

using static C_Utilities.Enumes;

namespace Caffiee.Areas.Admin.Controllers
{
    [Area(ConstsntValuse.Admin)]

    public class PriceProductebytypesController : BaseController
    {


        public PriceProductebytypesController(
            UnitOfWork unitOfWork,
            UserManager<Applicaionuser> userManager,
            SignInManager<Applicaionuser> signInManager) : base(unitOfWork, userManager, signInManager)
        {

        }


        [HttpGet]
        public IActionResult Index(PriceProductebytypesVM Entity, int? page)
        {

            Entity.PageNumber = page ?? 1;
            var Entitys = _unitOfWork._PriceProductebytypes.Search(Entity);
            return View(Entitys);
        }



        [HttpGet]

        public IActionResult GetProductbytyp(PriceProductebytypesVM Entity, int? page)
        {
            ViewBag.CustomerType = Entity.CustomerType;

            Entity.PageNumber = page ?? 1;
            var Entitys = _unitOfWork._PriceProductebytypes.SearchForTypes(Entity);
            return View(Entitys);
        }





        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var Entity = _unitOfWork._PriceProductebytypes.Get(id);
            if (Entity == null)
            {
                return NotFound();
            }
            return View(Entity);
        }

        // GET: Products/Create
        public IActionResult Save(int Id, int ProductId)
        {
            if (Id > 0)
            {

                var Entity = _unitOfWork._PriceProductebytypes.Get(Id);
                Entity.ProductId = ProductId;
                Entity.ProductName = _unitOfWork._Product.Get(ProductId).ProductName;
                Entity.ProductOldPrice = (int?)_unitOfWork._Product.Get(ProductId).Price;
                //product.CategoryIdList = _unitOfWork._Ilookup.GetCategories();

                Entity.CustomerTypeIdList = _unitOfWork._Ilookup.GetCustomerType();

                return View(Entity);

            }
            else
            {
                var Entitys = new PriceProductebytypesVM();
                Entitys.ProductId = ProductId;
                Entitys.ProductName = _unitOfWork._Product.Get(ProductId).ProductName;
                Entitys.ProductOldPrice = (int?)_unitOfWork._Product.Get(ProductId).Price;

                Entitys.CustomerTypeIdList = _unitOfWork._Ilookup.GetCustomerType();

                return View(Entitys);


            }

        }



        // POST: Products/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Save(PriceProductebytypesVM Entity)
        {
            Entity.CustomerTypeIdList = _unitOfWork._Ilookup.GetCustomerType();
            ModelState.Remove("CategoryName");
            ModelState.Remove("ProductName");
            ModelState.Remove("CustomerTypeName");

            if (!ModelState.IsValid)
            {
                return View(Entity);

            }
            if (!_unitOfWork._PriceProductebytypes.CheckIfExisit(Entity))
            {
                _unitOfWork._PriceProductebytypes.Save(Entity);
                TempData["Message"] = "Cannot save the category. Please check the form.";
                TempData["MessageType"] = "danger";

                return RedirectToAction(nameof(Index));


            }
            TempData["Message"] = "Cannot save the category. Please check the form.";
            TempData["MessageType"] = "danger";

            return View(Entity);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork._PriceProductebytypes.Delete(id);
                TempData["Message"] = "Cannot save the category. Please check the form.";
                TempData["MessageType"] = "danger";
                return Json(new { success = true, message = "Successfully deleted!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AddShopingCaterCashHistory(PriceProductebytypesVM Entity)
        {
            Entity.totalprice = Entity.price * Entity.ShopingCaterQantity;
            _unitOfWork._PriceProductebytypes.AddShopingCaterCashHistory(Entity);
            TempData["Message"] = $"{Entity.totalprice}  تم اضافه المنتج بسعر "; // "Added successfully"
            TempData["MessageType"] = "Save";

            return Json(new { success = true, message = TempData["Message"] });
        }









        [HttpGet]
        public IActionResult GetallfromShopingCart(PriceProductebytypesVM Entity, int? page)
        {
            ViewBag.CustomerType = Entity.CustomerType;
            ViewBag.Catid = Entity.Catid;
            Entity.PageNumber = page ?? 1;
            var Entitys = _unitOfWork._PriceProductebytypes.GetallfromShopingCart(Entity);
            return View(Entitys); // Replace "ShoppingCartPartial" with your actual partial view name
        }
        //[HttpPost]


        [HttpGet]

        public IActionResult FreeFinancialUserCash(CustomerType CustomerType  )
        {

            var Entity = new PriceProductebytypesVM();
            Entity.CustomerType = (CustomerType)CustomerType;
                _unitOfWork._PriceProductebytypes.FreeFinancialUserCash( "","");
            var model = _unitOfWork._PriceProductebytypes.SearchForTypes(Entity);
            return View("GetProductbytyp" , model); // Replace "ShoppingCartPartial" with your actual partial view name
        }


    }




}
