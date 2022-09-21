using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Persistent.Repositories.Base;
using System.Net;

namespace Dvd.Persistent.Repositories
{
	public class AuthorizationRepository : GenericRepository<Authorization>, IAuthorizationRepository
	{
		Context _context;
		public AuthorizationRepository(Context context) : base(context)
		{
			_context = context;
		}
		public bool Correct {get; set;}
	}
}
