using System;
using Fiorello.Models;

namespace Fiorello.ViewModels
{
	public class HeaderVM
	{
		public Dictionary<string, string> Settings { get; set; }
		public int CartCount { get; set; }
    }
}