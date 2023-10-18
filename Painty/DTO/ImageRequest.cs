using System;
namespace Painty.DTO
{
	public class ImageRequest
	{
		public int Id { get; set; }

        public int UserId { get; set; }

        public string? Title { get; set; }
	}
}

