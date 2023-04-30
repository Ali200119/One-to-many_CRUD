using System;
using System.ComponentModel.DataAnnotations;
using Fiorello.Models;

namespace Fiorello.Areas.Admin.ViewModels
{
	public class ProductCreateVM
	{
        [Required]
        public string Name { get; set; }

        [Required]
        public List<IFormFile> Photos { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}