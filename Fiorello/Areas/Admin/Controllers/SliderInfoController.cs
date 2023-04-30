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
    public class SliderInfoController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderInfoController(ISliderService sliderService,
                                    AppDbContext context,
                                    IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _context = context;
            _env = env;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderInfo> sliderInfos = await _sliderService.GetAllInfos();

            return View(sliderInfos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderInfo sliderInfo)
        {
            if (!ModelState.IsValid) return View();

            if (!sliderInfo.SignaturePhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError("SignaturePhoto", "File type must be image.");
                return View();
            }

            SliderInfo existedSliderInfo = await _context.SliderInfo.FirstOrDefaultAsync(si => si.Title.Trim().ToLower() == sliderInfo.Title.Trim().ToLower());

            if (existedSliderInfo is not null)
            {
                ModelState.AddModelError("Title", "Slider Info with this title already exists.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + sliderInfo.SignaturePhoto.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

            await sliderInfo.SignaturePhoto.CreateLocalFileAsync(path);

            sliderInfo.SignatureImage = fileName;

            await _context.SliderInfo.AddAsync(sliderInfo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            SliderInfo sliderInfo = await _sliderService.GetInfoById(id);
            if (sliderInfo is null) return NotFound();

            return View(sliderInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            SliderInfo sliderInfo = await _sliderService.GetInfoById(id);
            if (sliderInfo is null) return NotFound();

            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", sliderInfo.SignatureImage);

            FileHelper.DeleteFileFromPath(path);

            _context.SliderInfo.Remove(sliderInfo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            SliderInfo sliderInfo = await _sliderService.GetInfoById(id);
            if (sliderInfo is null) return NotFound();

            SliderInfoEditVM sliderInfoVM = new SliderInfoEditVM
            {
                Id = sliderInfo.Id,
                Title = sliderInfo.Title,
                Description = sliderInfo.Description,
                SignatureImage = sliderInfo.SignatureImage,
                SoftDelete = sliderInfo.SoftDelete
            };

            return View(sliderInfoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SliderInfoEditVM sliderInfoEditVM)
        {
            SliderInfo sliderInfo = await _context.SliderInfo.AsNoTracking().FirstOrDefaultAsync(si => si.Id == sliderInfoEditVM.Id);

            if (!ModelState.IsValid)
            {
                sliderInfoEditVM.SignatureImage = sliderInfo.SignatureImage;
                return View(sliderInfoEditVM);
            }

            if (sliderInfoEditVM.SignaturePhoto is null && sliderInfoEditVM.Title.Trim().ToLower() == sliderInfo.Title.Trim().ToLower() && sliderInfoEditVM.Description.Trim().ToLower() == sliderInfo.Description.Trim().ToLower()) return RedirectToAction(nameof(Index));

            if (sliderInfoEditVM.SignaturePhoto is null) sliderInfoEditVM.SignatureImage = sliderInfo.SignatureImage;

            else
            {
                if (!sliderInfoEditVM.SignaturePhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError("SignaturePhoto", "File type must be image.");
                    sliderInfoEditVM.SignatureImage = sliderInfo.SignatureImage;
                    return View(sliderInfoEditVM);
                }

                string fileName = Guid.NewGuid().ToString() + "_" + sliderInfoEditVM.SignaturePhoto.FileName;
                string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

                string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "img", sliderInfo.SignatureImage);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await sliderInfoEditVM.SignaturePhoto.CopyToAsync(stream);
                }

                FileHelper.DeleteFileFromPath(oldImagePath);

                sliderInfoEditVM.SignatureImage = fileName;
            }

            SliderInfo updatedSliderInfo = new SliderInfo
            {
                Id = sliderInfoEditVM.Id,
                Title = sliderInfoEditVM.Title,
                Description = sliderInfoEditVM.Description,
                SignatureImage = sliderInfoEditVM.SignatureImage,
                SoftDelete = sliderInfoEditVM.SoftDelete
            };

            _context.SliderInfo.Update(updatedSliderInfo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}