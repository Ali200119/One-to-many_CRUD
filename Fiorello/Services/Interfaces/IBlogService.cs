using System;
using Fiorello.Models;

namespace Fiorello.Services.Interfaces
{
	public interface IBlogService
	{
		Task<Blog> GetAll();
		Task<IEnumerable<BlogPost>> GetAllBlogPosts();
		Task<BlogPost> GetBlogPostById(int? id);
	}
}