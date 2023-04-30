using System;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
	public class ExpertService: IExpertService
	{
        private readonly AppDbContext _context;

        public ExpertService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Expert>> GetAll()
        {
            return await _context.Experts.Include(e => e.Persons).ToListAsync();
        }

        public async Task<Expert> GetById(int? id)
        {
            return await _context.Experts.Include(e => e.Persons).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAllPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonById(int? id)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}