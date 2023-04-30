using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Fiorello.Services;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;

        public BlogPostController(AppDbContext context,
                                  IBlogService blogService,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _blogService = blogService;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<BlogPost> blogPosts = await _blogService.GetAllBlogPosts();
            
            return View(blogPosts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            if (!ModelState.IsValid) return View();

            if (!blogPost.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file must be image.");
                return View();
            }

            BlogPost existedBlogPost = await _context.BlogPosts.FirstOrDefaultAsync(bp => bp.Title.Trim().ToLower() == blogPost.Title.Trim().ToLower());

            if (existedBlogPost is not null)
            {
                ModelState.AddModelError("Title", "Blog with this Title is already exists.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + blogPost.Photo.FileName;
            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogPost.Photo.CopyToAsync(stream);
            }

            blogPost.Image = fileName;

            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            BlogPost blogPost = await _blogService.GetBlogPostById(id);
            if (blogPost is null) return NotFound();

            return View(blogPost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogPost blogPost)
        {
            if (!ModelState.IsValid) return View();

            if (!blogPost.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file must be image");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + blogPost.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

            BlogPost oldImage = await _context.BlogPosts.AsNoTracking().FirstOrDefaultAsync(s => s.Id == blogPost.Id);
            string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "img", oldImage.Image);

            FileHelper.DeleteFileFromPath(oldImagePath);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blogPost.Photo.CopyToAsync(stream);
            }

            blogPost.Image = fileName;

            _context.BlogPosts.Update(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            BlogPost blogPost = await _blogService.GetBlogPostById(id);
            if (blogPost is null) return NotFound();

            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", blogPost.Image);
            FileHelper.DeleteFileFromPath(path);

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            BlogPost blogPost = await _blogService.GetBlogPostById(id);
            if (blogPost is null) return NotFound();

            return View(blogPost);
        }
    }
}