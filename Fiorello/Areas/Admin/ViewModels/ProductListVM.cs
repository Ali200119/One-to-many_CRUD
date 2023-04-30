using System;
using Fiorello.Models;

namespace Fiorello.Areas.Admin.ViewModels
{
	public class ProductListVM
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
    }
}