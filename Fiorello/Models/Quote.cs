using System;
namespace Fiorello.Models
{
	public class Quote: BaseEntity
	{
		public string Image { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
	}
}