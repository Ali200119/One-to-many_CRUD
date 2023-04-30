using System;
namespace Fiorello.Areas.Admin.ViewModels
{
	public class ProductDetailsVM
	{
        public string Name { get; set; }
        public IEnumerable<string> Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string CategoryName { get; set; }
    }
}