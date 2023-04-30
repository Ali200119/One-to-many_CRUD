using System;
using Fiorello.Models;
using Fiorello.ViewModels;

namespace Fiorello.Services.Interfaces
{
	public interface ICartService
	{
        List<CartVM> GetCartDatas();
        void AddProductToCart(CartVM existedProduct, Product product, List<CartVM> cart);
        void DeleteProductFromCart(int? id);
        void IncreaseProductCount(int? id);
        void DecreaseProductCount(int? id);
    }
}