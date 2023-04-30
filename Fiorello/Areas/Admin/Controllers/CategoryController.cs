using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Areas.Admin.ViewModels;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(AppDbContext context,
                                  ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }



        public async Task<IActionResult> Index(int page = 1, int take = 2)
        {
            List<Category> categories = await _categoryService.GetPaginatedDataAsync(page, take);

            List<CategoryListVM> mappedDatas = GetMappedDatas(categories);

            int pageCount = await GetPageCountAsync(take);

            Paginate<CategoryListVM> paginatedDatas = new Paginate<CategoryListVM>(mappedDatas, page, pageCount);

            ViewBag.Order = page * take - take;

            return View(paginatedDatas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid) return View();

                Category existedCatgeory = await _context.Categories.FirstOrDefaultAsync(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());

                if (existedCatgeory is not null)
                {
                    ModelState.AddModelError("Name", "Category with this name is already exists");
                    return View();
                }

                //throw new Exception("Model statetimiz bugun bizi yolda qoydu");

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetById(id);
            if (category is null) return NotFound();

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetById(id);
            if (category is null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid) return View();

            Category dbCategory = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == category.Id);

            if (category.Name.Trim() == dbCategory.Name.Trim()) return RedirectToAction(nameof(Index));

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetById(id);
            if (category is null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private List<CategoryListVM> GetMappedDatas(List<Category> categories)
        {
            List<CategoryListVM> mappedDatas = new List<CategoryListVM>();

            foreach (var category in categories)
            {
                CategoryListVM categoryVM = new CategoryListVM
                {
                    Id = category.Id,
                    Name = category.Name
                };

                mappedDatas.Add(categoryVM);
            }

            return mappedDatas;
        }

        private async Task<int> GetPageCountAsync(int take)
        {
            int categoryCount = await _categoryService.GetCountAsync();
            return (int)Math.Ceiling((decimal)categoryCount / take);
        }
    }
}