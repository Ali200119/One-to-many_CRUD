using System;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Fiorello.Services
{
	public class LayoutService: ILayoutService
	{
        private readonly AppDbContext _context;
        private readonly ICartService _cartService;

        public LayoutService(AppDbContext context,
                             ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        

        public HeaderVM GetHeaderDatas()
        {
            Dictionary<string, string> settings = _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);

            List<CartVM> cartDatas = _cartService.GetCartDatas();

            return new HeaderVM { Settings = settings, CartCount = cartDatas.Sum(p => p.Count) };
        }

        public async Task<FooterVM> GetFooterDatas()
        {
            Dictionary<string, string> settings = _context.Settings.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);

            IEnumerable<SocialMedia> socialMedias = await _context.SocialMedias.ToListAsync();

            return new FooterVM { Settings = settings, SocialMedias = socialMedias };
        }
    }
}