using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public readonly IWebHostEnvironment _env;
        public ProductsController(IProductService productService,ICategoryService categoryService,IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var Product = await _productService.GetById(Id);
            ViewBag.CategoryId =
            new SelectList(await _categoryService.GetCategories(), "Id", "Name",Product.Category);
            return View(Product);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            var product = await _productService.GetById(Id);

            if (product == null)
            {
                return NotFound();
            }
            var wwroot = _env.WebRootPath;
            var image = Path.Combine(wwroot, "images\\", product.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(product);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var product = await _productService.GetById(Id);
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(ProductDTO product)
        {
            await _productService.Remove(product.Id);
            return RedirectToAction("Index");
        }
    }
}
