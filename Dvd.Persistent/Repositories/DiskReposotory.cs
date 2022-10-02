using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Domain.Entity.Tables;
using Dvd.Persistent.Repositories.Base;

namespace Dvd.Persistent.Repositories
{
	public class DiskReposotory : GenericRepository<Disk>, IDiskRepository
	{
		private new readonly Context _context;
		public DiskReposotory(Context context) : base(context)
		{
			_context = context;
		}

	}
}
