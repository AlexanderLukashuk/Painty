using System;
namespace Painty.DAL.Interfaces
{
	public interface IRepository<T> where T : class
	{
        Task<T> GetById(int id);

		Task<IEnumerable<T>> GetAll();

		Task Add(T enitity);

		Task Delete(int id);

		Task<T> Update(T entity);
	}
}

