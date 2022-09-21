using Dvd.Application.Interfaces.BusinessLogic.Base;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Dvd.Persistent.Repositories.Base
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		internal readonly Context _context;
		public GenericRepository(Context context)
		{
			_context=context;
		}
		public async Task<T> CreateAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public Task Delete(T entity)
		{
			_context.Remove(entity);
			return Task.CompletedTask;
		}

		public Task<T?> FirstAsync()
		{
			throw new NotImplementedException();
		}

		public virtual Task<List<T>> GetAllAsync()
		{
			return _context.Set<T>().ToListAsync();
		}

		

		public Task<T?> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<T?> LastAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity) => Task.FromResult(entity);
	}
}
