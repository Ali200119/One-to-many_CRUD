using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExpertController : Controller
    {
        private readonly AppDbContext _context;
        private IExpertService _expertService;

        public ExpertController(AppDbContext context, IExpertService expertService)
        {
            _context = context;
            _expertService = expertService;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<Expert> experts = await _expertService.GetAll();

            return View(experts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Expert expert)
        {
            if (!ModelState.IsValid) return View();

            Expert existedExpert = await _context.Experts.FirstOrDefaultAsync(e => e.Title.Trim().ToLower() == expert.Title.Trim().ToLower());

            if (existedExpert is not null)
            {
                ModelState.AddModelError("Title", "Expert with this name is already exists");
                return View();
            }

            await _context.Experts.AddAsync(expert);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            Expert expert = await _expertService.GetById(id);
            if (expert is null) return NotFound();

            return View(expert);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Expert expert = await _expertService.GetById(id);
            if (expert is null) return NotFound();

            return View(expert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expert expert)
        {
            if (!ModelState.IsValid) return View();

            Expert dbExpert = await _context.Experts.AsNoTracking().FirstOrDefaultAsync(e => e.Id == expert.Id);

            if (expert.Title.Trim() == dbExpert.Title.Trim() && expert.Description.Trim() == dbExpert.Description.Trim()) return RedirectToAction(nameof(Index));

            _context.Experts.Update(expert);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Expert expert = await _expertService.GetById(id);
            if (expert is null) return NotFound();

            _context.Experts.Remove(expert);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}