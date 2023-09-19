using ESyMVCApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ESyMVCApp.Web.Controllers
{
    public class ProductsController : Controller
    { 
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;
        public ProductsController(AppDbContext context)
        {
            _productRepository = new ProductRepository();

            //DI container
            //Dependency Injection Pattern

            _context = context;
            //Linq Method

      
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();


            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index"); 
        
        }
        [HttpGet]
        public IActionResult  Update(int id)
        {

            var product = _context.Products.Find(id);

            return View(product);
        }

        [HttpPost]

        public IActionResult Update(Product updateProduct)
        {

            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
