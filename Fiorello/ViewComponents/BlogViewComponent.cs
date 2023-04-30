using System;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fiorello.ViewComponents
{
	public class BlogViewComponent: ViewComponent
	{
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;

        public BlogViewComponent(AppDbContext context,
                                 IBlogService blogService)
        {
            _context = context;
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View(await _blogService.GetAll()));
        }
	}
}