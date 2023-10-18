using System;
namespace Painty.DAL.Entities
{
	public class User
	{
        public int Id { get; set; }

        public string? UserName { get; set; }

        public ICollection<Friendship>? Friendships { get; set; }

        private List<Image> _images = new List<Image>();

        public IReadOnlyCollection<Image> Images => _images.AsReadOnly();
    }
}

