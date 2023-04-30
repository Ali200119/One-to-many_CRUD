using System;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Newtonsoft.Json;

namespace Fiorello.Services
{
	public class CartService: ICartService
	{
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public List<CartVM> GetCartDatas()
        {
            List<CartVM> cart;

            if (_httpContextAccessor.HttpContext.Request.Cookies["cart"] != null && _httpContextAccessor.HttpContext.Request.Cookies["cart"].Count() != 0)
            {
                cart = JsonConvert.DeserializeObject<List<CartVM>>(_httpContextAccessor.HttpContext.Request.Cookies["cart"]);
            }

            else
            {
                cart = new List<CartVM>();
            }

            return cart;
        }

        public void AddProductToCart(CartVM existedProduct, Product product, List<CartVM> cart)
        {
            if (existedProduct != null)
            {
                existedProduct.Count++;
            }

            else
            {
                cart.Add(new CartVM
                {
                    Id = product.Id,
                    Count = 1
                });
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));
        }

        public void DeleteProductFromCart(int? id)
        {
            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(_httpContextAccessor.HttpContext.Request.Cookies["cart"]);

            cart.Remove(cart.FirstOrDefault(cp => cp.Id == id));

            _httpContextAccessor.HttpContext.Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));
        }

        public void IncreaseProductCount(int? id)
        {
            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(_httpContextAccessor.HttpContext.Request.Cookies["cart"]);

            cart.FirstOrDefault(cp => cp.Id == id).Count++;

            _httpContextAccessor.HttpContext.Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));
        }

        public void DecreaseProductCount(int? id)
        {
            List<CartVM> cart = JsonConvert.DeserializeObject<List<CartVM>>(_httpContextAccessor.HttpContext.Request.Cookies["cart"]);

            CartVM product = cart.FirstOrDefault(cp => cp.Id == id);

            if (product.Count > 1)
            {
                product.Count--;
            }

            _httpContextAccessor.HttpContext.Response.Cookies.Append("cart", JsonConvert.SerializeObject(cart));
        }
    }
}