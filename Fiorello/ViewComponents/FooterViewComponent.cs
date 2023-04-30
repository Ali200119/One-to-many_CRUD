using System;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
	public class FooterViewComponent: ViewComponent
	{
		private readonly ILayoutService _layoutService;

        public FooterViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult(View(await _layoutService.GetFooterDatas()));
		}
	}
}