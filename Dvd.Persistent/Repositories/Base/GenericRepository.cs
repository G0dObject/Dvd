using Dvd.Application.Interfaces.BusinessLogic.Base;
using Microsoft.EntityFrameworkCore;

namespace Dvd.Persistent.Repositories.Base
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		internal readonly Context _context;
		public GenericRepository(Context context)
		{
			_context = context;
		}
		public async Task<T> CreateAsync(T entity)
		{

			_ = await _context.Set<T>().AddAsync(entity);
			_ = await _context.SaveChangesAsync();
			return entity;
		}

		public Task Delete(T entity)
		{
			_ = _context.Remove(entity);
			return Task.CompletedTask;
		}

		public async Task<T?> FirstAsync()
		{
			return await _context.Set<T>().FirstOrDefaultAsync();
		}

		public virtual Task<List<T>> GetAllAsync()
		{
			return _context.Set<T>().ToListAsync();
		}
		public virtual async Task<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public Task<T?> LastAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			return Task.FromResult(entity);
		}
	}
}
