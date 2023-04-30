using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fiorello.Models;

namespace Fiorello.Areas.Admin.ViewModels
{
	public class SliderInfoEditVM: BaseEntity
	{
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string? SignatureImage { get; set; }

        public IFormFile? SignaturePhoto { get; set; }
    }
}