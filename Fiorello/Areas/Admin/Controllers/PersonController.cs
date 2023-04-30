using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Areas.Admin.ViewModels;
using Fiorello.Data;
using Fiorello.Helpers;
using Fiorello.Models;
using Fiorello.Services;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IExpertService _expertService;
        private readonly IWebHostEnvironment _env;

        public PersonController(AppDbContext context,
                                IExpertService expertService,
                                IWebHostEnvironment env)
        {
            _context = context;
            _expertService = expertService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Person> persons = await _expertService.GetAllPersons();

            return View(persons);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (!ModelState.IsValid) return View();

            if (!person.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type must be image.");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + person.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                await person.Photo.CopyToAsync(stream);
            }

            person.Image = fileName;

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            Person person = await _expertService.GetPersonById(id);
            if (person is null) return NotFound();

            return View(person);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Person person = await _expertService.GetPersonById(id);
            if (person is null) return NotFound();

            PersonEditVM personEditVM = new PersonEditVM
            {
                Id = person.Id,
                Name = person.Name,
                Position = person.Position,
                Image = person.Image,
                SoftDelete = person.SoftDelete
            };

            return View(personEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonEditVM personEditVM)
        {
            Person person = await _context.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.Id == personEditVM.Id);

            if (!ModelState.IsValid)
            {
                personEditVM.Image = person.Image;
                return View(personEditVM);
            }

            if (personEditVM.Photo is null && personEditVM.Name.Trim().ToLower() == person.Name.Trim().ToLower() && personEditVM.Position.Trim().ToLower() == person.Position.Trim().ToLower()) return RedirectToAction(nameof(Index));

            if (personEditVM.Photo is null) personEditVM.Image = person.Image;

            else
            {
                if (!personEditVM.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type must be image.");
                    personEditVM.Image = person.Image;
                    return View(personEditVM);
                }

                string fileName = Guid.NewGuid().ToString() + "_" + personEditVM.Photo.FileName;
                string path = FileHelper.GetFilePath(_env.WebRootPath, "img", fileName);

                string oldImagePath = FileHelper.GetFilePath(_env.WebRootPath, "img", person.Image);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await personEditVM.Photo.CopyToAsync(stream);
                }

                FileHelper.DeleteFileFromPath(oldImagePath);

                personEditVM.Image = fileName;
            }

            Person updatedPerson = new Person
            {
                Id = personEditVM.Id,
                Name = personEditVM.Name,
                Position = personEditVM.Position,
                Image = personEditVM.Image,
                SoftDelete = personEditVM.SoftDelete
            };

            _context.Persons.Update(updatedPerson);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            Person person = await _expertService.GetPersonById(id);

            string path = FileHelper.GetFilePath(_env.WebRootPath, "img", person.Image);

            FileHelper.DeleteFileFromPath(path);

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}