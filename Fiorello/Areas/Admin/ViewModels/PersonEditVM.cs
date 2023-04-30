using System;
using Fiorello.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello.Areas.Admin.ViewModels
{
	public class PersonEditVM: BaseEntity
	{
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public int ExpertId { get; set; } = 1;

        public Expert? Expert { get; set; }
    }
}