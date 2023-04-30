using System;
using Fiorello.Models;

namespace Fiorello.ViewModels
{
	public class HomeVM
	{
		public IEnumerable<Slider> Sliders { get; set; }
		public SliderInfo SliderInfo { get; set; }
		public About About { get; set; }
		public Expert Expert { get; set; }
		public Subscribe Subscribe { get; set; }
		public IEnumerable<Quote> Quotes { get; set; }
		public IEnumerable<Instagram> Instagrams { get; set; }
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}