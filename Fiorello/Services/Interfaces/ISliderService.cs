using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface ISliderService
	{
		Task<IEnumerable<Slider>> GetAll();
        Task<Slider> GetById(int? id);
        Task<SliderInfo> GetInfo();
		Task<IEnumerable<SliderInfo>> GetAllInfos();
		Task<SliderInfo> GetInfoById(int? id);
	}
}