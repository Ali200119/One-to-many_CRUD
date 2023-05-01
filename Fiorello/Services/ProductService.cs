using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll() => await _context.Products.Include(p => p.ProductImages).ToListAsync();

        public async Task<Product> GetById(int? id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Product> GetFullDataById(int? id) => await _context.Products.Include(p => p.Category).Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Product>> GetPaginatedDatasAsync(int page, int take) => await _context.Products.Include(p => p.Category).Include(p => p.ProductImages).Skip(page * take - take).Take(take).ToListAsync();

        public async Task<int> GetCountAsync() => await _context.Products.CountAsync();
    }
}