using System;
using System.ComponentModel.DataAnnotations;
using Fiorello.Models;

namespace Fiorello.Areas.Admin.ViewModels
{
	public class ProductEditVM
	{
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<IFormFile> Photos { get; set; }

        public List<string>? ProductImages { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public bool? SoftDelete { get; set; }
    }
}