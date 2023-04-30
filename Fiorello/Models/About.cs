using System;
namespace Fiorello.Models
{
	public class About: BaseEntity
	{
		public string VideoCover { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public ICollection<Advantage> Advantages { get; set; }
	}
}