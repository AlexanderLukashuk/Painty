using System;
using Microsoft.EntityFrameworkCore;
using Painty.DAL.Entities;

namespace Painty.DAL.EF
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<Image> Images { get; set; }

		public DbSet<Friendship> Friendships { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasMany(u => u.Images)
				.WithOne()
				.HasForeignKey(i => i.UserId);
        }
    }
}

