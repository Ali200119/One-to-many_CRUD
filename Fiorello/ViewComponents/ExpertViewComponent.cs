using System;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
	public class ExpertViewComponent: ViewComponent
	{
		private readonly IExpertService _expertService;

        public ExpertViewComponent(IExpertService expertService)
        {
            _expertService = expertService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult(View(await _expertService.GetAll()));
		}
	}
}