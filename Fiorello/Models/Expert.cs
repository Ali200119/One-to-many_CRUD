using System;
using System.ComponentModel.DataAnnotations;

namespace Fiorello.Models
{
	public class Expert: BaseEntity
	{
        [Required]
        public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public ICollection<Person>? Persons { get; set; }
	}
}