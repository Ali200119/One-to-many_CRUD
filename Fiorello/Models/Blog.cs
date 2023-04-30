using System;
namespace Fiorello.Models
{
	public class Blog: BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public ICollection<BlogPost> BlogPosts { get; set; }
	}
}