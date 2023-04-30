using System;
using Fiorello.Models;

namespace Fiorello.ViewModels
{
	public class FooterVM
	{
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}