using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.Areas.Admin.ViewModels;
using Fiorello.Helpers;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public ProductController(IProductService productService,
                                 ICategoryService categoryService,
                                 IWebHostEnvironment env,
                                 AppDbContext context)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env = env;
            _context = context;
        }



        public async Task<IActionResult> Index(int page = 1, int take = 3)
        {
            List<Product> products = await _productService.GetPaginatedDatasAsync(page, take);

            List<ProductListVM> mappedDatas = GetMappedDatas(products);

            int pageCount = await GetPageCountAsync(take);

            Paginate<ProductListVM> paginatedDatas = new Paginate<ProductListVM>(mappedDatas, page, pageCount);

            ViewBag.Order = page * take - take;

            return View(paginatedDatas);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await GetCategoriesAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM model)
        {
            ViewBag.Categories = await GetCategoriesAsync();

            if (!ModelState.IsValid) return View(model);

            foreach (var photo in model.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "File type must be image.");
                    return View(model);
                }
            }

            List<ProductImage> productImages = new List<ProductImage>();

            foreach (var photo in model.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

                await photo.CreateLocalFileAsync(path);

                ProductImage productImage = new ProductImage
                {
                    Name = fileName
                };

                productImages.Add(productImage);
            }

            productImages.FirstOrDefault().IsMain = true;

            decimal convertedPrice = decimal.Parse(model.Price.Replace(".", ","));

            Product newProduct = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = convertedPrice,
                Count = model.Count,
                CategoryId = model.CategoryId,
                ProductImages = productImages
            };

            await _context.ProductImages.AddRangeAsync(productImages);
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetByIdWithIncludes(id);
            if (product is null) return NotFound();

            List<string> images = new List<string>();

            foreach (var image in product.ProductImages)
            {
                images.Add(image.Name);
            }

            ProductDetailsVM productDetailsVM = new ProductDetailsVM
            {
                Name = product.Name,
                Description = product.Description,
                CategoryName = product.Category.Name,
                Price = product.Price,
                Count = product.Count,
                Images = images
            };

            return View(productDetailsVM);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }



        private List<ProductListVM> GetMappedDatas(List<Product> products)
        {
            List<ProductListVM> mappedDatas = new List<ProductListVM>();

            foreach (var product in products)
            {
                ProductListVM productVM = new ProductListVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryName = product.Category.Name,
                    Count = product.Count,
                    Price = product.Price,
                    MainImage = product.ProductImages.FirstOrDefault(pi => pi.IsMain).Name
                };

                mappedDatas.Add(productVM);
            }

            return mappedDatas;
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int productCount = await _productService.GetCountAsync();

            return (int)Math.Ceiling((decimal)productCount / take);
        }

        private async Task<SelectList> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryService.GetAll();
            return new SelectList(categories, "Id", "Name");
        }
    }
}