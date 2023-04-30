using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(ISliderService sliderService, AppDbContext context, IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _sliderService.GetAll();

            return View(sliders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _sliderService.GetById(id);
            if (slider is null) return NotFound();

            return View(slider);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file must be image.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

            await slider.Photo.CreateLocalFileAsync(path);

            slider.Image = fileName;

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _sliderService.GetById(id);
            if (slider is null) return NotFound();

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Type of file must be image");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

            Slider oldImage = await _context.Sliders.AsNoTracking().FirstOrDefaultAsync(s => s.Id == slider.Id);
            string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "img", oldImage.Image);

            FileHelper.DeleteFileFromPath(oldImagePath);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }

            slider.Image = fileName;

            _context.Sliders.Update(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _sliderService.GetById(id);
            if (slider is null) return NotFound();

            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", slider.Image);

            FileHelper.DeleteFileFromPath(path);

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}