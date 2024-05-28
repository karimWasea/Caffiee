using Caffiee.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Servess;

using System.Diagnostics;

namespace Caffiee.Controllers
{
   
    public class BaseController : Controller
    {
        protected UnitOfWork _unitOfWork;
         public BaseController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
