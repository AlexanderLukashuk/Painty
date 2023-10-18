using System;
using Painty.DAL.EF;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.DAL.Repositories
{
	public class FriendshipRepository : IRepository<Friendship>
	{
		private readonly ApplicationDbContext _context;

		public FriendshipRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task Add(Friendship enitity)
        {
            await _context.Friendships.AddAsync(enitity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var friend = await GetById(id);
            if (friend != null)
            {
                _context.Friendships.Remove(friend);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Friendship> GetAll()
        {
            return _context.Friendships;
        }

        public async Task<Friendship> GetById(int id)
        {
            return await _context.Friendships.FindAsync(id);
        }

        public async Task<Friendship> Update(Friendship entity)
        {
            _context.Friendships.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

