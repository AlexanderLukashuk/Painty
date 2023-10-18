using System;
namespace Painty.DAL.Entities
{
	public class Image
	{
        public int Id { get; set; }

        public string? Path { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}

