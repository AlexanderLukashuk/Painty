using System;
using Microsoft.EntityFrameworkCore;
using Painty.DAL.EF;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.DAL.Repositories
{
	public class ImageRepository : IRepository<Image>
	{
		private readonly ApplicationDbContext _context;

		public ImageRepository(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task Add(Image enitity)
        {
            await _context.Images.AddAsync(enitity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var image = await GetById(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetById(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<Image> Update(Image entity)
        {
            _context.Images.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}

