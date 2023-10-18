using System;
namespace Painty.DAL.Entities
{
	public class Friendship
	{
        public int Id { get; set; }

        public int User1Id { get; set; }

        public int User2Id { get; set; }

        public User? User1 { get; set; }

        public User? User2 { get; set; }
    }
}

