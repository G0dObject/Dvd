using Dvd.Application.Interfaces;
using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Persistent.Repositories;
using System.Net;

namespace Dvd.Persistent
{
	public class UnitOfWork : IUnitOfWork
	{
		public Context _context;
		public UnitOfWork(Context context)
		{
			_context = context;
			Authorization = new AuthorizationRepository(context);
		}

		public IAuthorizationRepository Authorization { get; set; }
	}
}
