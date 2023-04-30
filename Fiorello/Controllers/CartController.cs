using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fiorello.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(AppDbContext context,
                              ICartService cartService,
                              IProductService productService)
        {
            _context = context;
            _cartService = cartService;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {
            List<CartVM> cart = _cartService.GetCartDatas();

            List<CartDetailVM> cartDetails = new();


            foreach (var product in cart)
            {
                Product dbProduct = await _productService.GetFullDataById(product.Id);
                cartDetails.Add(new CartDetailVM
                {
                    Id = dbProduct.Id,
                    Name = dbProduct.Name,
                    Image = dbProduct.ProductImages.Where(pi => pi.IsMain && !pi.SoftDelete).FirstOrDefault().Name,
                    Price = dbProduct.Price,
                    Count = product.Count
                });
            }

            return View(cartDetails);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteProductFromBasket(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            _cartService.DeleteProductFromCart(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseCount(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            _cartService.IncreaseProductCount(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseCount(int? id)
        {
            if (id is null) return BadRequest();
            Product dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (dbProduct is null) return NotFound();

            _cartService.DecreaseProductCount(id);

            return Ok();
        }
    }
}