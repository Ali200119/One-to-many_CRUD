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

        public ProductController(IProductService productService)
        {
            _productService = productService;
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
    }
}
