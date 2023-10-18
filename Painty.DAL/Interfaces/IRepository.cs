using System;
namespace Painty.DAL.Interfaces
{
	public interface IRepository<T> where T : class
	{
		T GetById(int id);

		IEnumerable<T> GetAll();

		Task Add(T enitity);

		Task Delete(int id);

		Task<T> Update(T entity);
	}
}

