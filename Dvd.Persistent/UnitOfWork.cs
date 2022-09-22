using Dvd.Application.Interfaces;
using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Persistent.Repositories;

namespace Dvd.Persistent
{
	public class UnitOfWork : IUnitOfWork,IDisposable
	{
		private Context _context; 
		private bool _disposed = false;
		public UnitOfWork(Context context)
		{
			_context = context;
			Authorization = new AuthorizationRepository(context);
		}

		public IAuthorizationRepository Authorization { get; set; }

		public virtual void Dispose()
		{
			if (!_disposed)
			{
				_context.Dispose();
				_disposed = true;
			}
		}
	}
}
