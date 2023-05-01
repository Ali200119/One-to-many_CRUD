using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface IProductService
	{
		Task<Product> GetById(int? id);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetFullDataById(int? id);
		Task<List<Product>> GetPaginatedDatasAsync(int page, int take);
		Task<int> GetCountAsync();
    }
}