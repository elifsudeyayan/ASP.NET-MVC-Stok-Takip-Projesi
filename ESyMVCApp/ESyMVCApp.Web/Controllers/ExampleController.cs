using Microsoft.AspNetCore.Mvc;

namespace ESyMVCApp.Web.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoLayout()
        {
            return View();
        }
    }
}
