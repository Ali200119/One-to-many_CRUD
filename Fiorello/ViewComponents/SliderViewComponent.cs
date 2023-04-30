using System;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
	public class SliderViewComponent: ViewComponent
	{
		private readonly ISliderService _sliderService;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult(View(new SliderVM
			{
				Sliders = await _sliderService.GetAll(),
				SliderInfo = await _sliderService.GetInfo()
			}));
		}
	}
}