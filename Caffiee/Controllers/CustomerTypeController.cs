using C_Utilities;

using Caffiee.Models;

using Microsoft.AspNetCore.Mvc;

using Servess;

using System.Diagnostics;

namespace Caffiee.Controllers
{

    [Area(ConstsntValuse.Admin)]
    //[Authorize(Roles = SystemRols.SuperAdmin)]
    public class CustomerTypeController : BaseController
    {
        public CustomerTypeController(UnitOfWork unitOfWork) : base(unitOfWork)
        {

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
