using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello.Models
{
	public class Slider: BaseEntity
	{
		public string? Image { get; set; }

		[NotMapped, Required]
		public IFormFile Photo { get; set; }
	}
}