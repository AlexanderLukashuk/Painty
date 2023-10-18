using System;
using Microsoft.EntityFrameworkCore;
using Painty.DAL.EF;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.DAL.Repositories
{
	public class UserRepository : IRepository<User>
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task Add(User enitity)
        {
            await _context.Users.AddAsync(enitity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

