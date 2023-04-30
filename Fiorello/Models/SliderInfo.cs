using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello.Models
{
	public class SliderInfo: BaseEntity
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public string? SignatureImage { get; set; }

		[Required, NotMapped]
		public IFormFile SignaturePhoto { get; set; }
	}
}