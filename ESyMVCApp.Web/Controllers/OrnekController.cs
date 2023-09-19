using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ESyMVCApp.Web.Controllers
{

    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {

            var productList = new List<Product2>()
            {
                new(){ Id=1, Name="Kalem" },
                new(){ Id=2, Name="Defter" },
                new(){ Id=2, Name="Silgi" },
            };
        

            return View(productList);
        }

        




        public IActionResult Index2()
        {
            // veritabanı kaydetme işlemi buradan yapılır
            return RedirectToAction("Index", "Ornek");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id });
        }
    }
}

