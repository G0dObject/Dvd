using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Persistent.Repositories.Base;
using System.Net;
using Authorization = Dvd.Domain.Entity.Authorization.Authorization;

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
