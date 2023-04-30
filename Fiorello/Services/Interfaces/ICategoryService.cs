using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface ICategoryService
	{
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int? id);
        Task<List<Category>> GetPaginatedDataAsync(int page, int take);
        Task<int> GetCountAsync();
    }
}