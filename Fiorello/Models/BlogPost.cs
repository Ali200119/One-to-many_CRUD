using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello.Models
{
	public class BlogPost: BaseEntity
	{
		public string? Image { get; set; }

		[Required, NotMapped]
		public IFormFile Photo { get; set; }

		[Required]
		public DateTime Date { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public int BlogId { get; set; } = 1;
		public Blog? Blog { get; set; }
	}
}