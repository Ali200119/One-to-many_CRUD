using System;
using System.Collections.Generic;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
	public class CategoryService: ICategoryService
	{
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Category>> GetAll() => await _context.Categories.ToListAsync();

        public async Task<Category> GetById(int? id) => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<int> GetCountAsync() => await _context.Categories.CountAsync();

        public async Task<List<Category>> GetPaginatedDataAsync(int page, int take) => await _context.Categories.Skip(page * take - take).Take(take).ToListAsync();
    }
}