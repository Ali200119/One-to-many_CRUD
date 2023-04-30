using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface IExpertService
	{
		Task<IEnumerable<Expert>> GetAll();
		Task<Expert> GetById(int? id);
		Task<IEnumerable<Person>> GetAllPersons();
		Task<Person> GetPersonById(int? id);
	}
}