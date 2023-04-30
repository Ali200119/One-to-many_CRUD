using System;
using Fiorello.Models;

namespace Fiorello.ViewModels
{
	public class SliderVM
	{
		public IEnumerable<Slider> Sliders { get; set; }
		public SliderInfo SliderInfo { get; set; }
	}
}