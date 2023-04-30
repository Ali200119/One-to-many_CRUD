using System;
using System.Collections.Generic;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;

        public BlogService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Blog> GetAll() => await _context.Blogs.Include(b => b.BlogPosts).FirstOrDefaultAsync();

        public async Task<IEnumerable<BlogPost>> GetAllBlogPosts() => await _context.BlogPosts.ToListAsync();

        public async Task<BlogPost> GetBlogPostById(int? id) => await _context.BlogPosts.FirstOrDefaultAsync(bp => bp.Id == id);
    }
}