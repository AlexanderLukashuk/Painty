using System;
namespace Painty.DTO
{
	public class UserDTO
	{
		public int Id { get; set; }

		public string? UserName { get; set; }

		public IEnumerable<ImageDTO>? Images { get; set; }

		public IEnumerable<FriendDTO>? Friends { get; set; }
	}
}

