using System;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
	public class HeaderViewComponent: ViewComponent
	{
		private readonly ILayoutService _layoutService;

        public HeaderViewComponent(ILayoutService layoutService)
        {
            _layoutService = layoutService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult(View(new HeaderVM { Settings = _layoutService.GetHeaderDatas().Settings, CartCount = _layoutService.GetHeaderDatas().CartCount}));
		}
	}
}