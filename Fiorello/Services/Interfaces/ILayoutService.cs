using System;
using Fiorello.ViewModels;

namespace Fiorello.Services.Interfaces
{
	public interface ILayoutService
	{
        HeaderVM GetHeaderDatas();
        Task<FooterVM> GetFooterDatas();
    }
}