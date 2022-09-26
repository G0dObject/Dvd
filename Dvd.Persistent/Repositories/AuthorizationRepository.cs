using Dvd.Application.Interfaces.BusinessLogic;
using Dvd.Domain.Entity.Tables;
using Dvd.Persistent.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Dvd.Persistent.Repositories
{
	public class AuthorizationRepository : GenericRepository<User>, IAuthorizationRepository
	{
		private new readonly Context? _context;
		private readonly string _defaultRole = "User";
		public AuthorizationRepository(Context context) : base(context)
		{
			_context = context;
		}

		public async Task<Role> GetDefaultRole()
		{
			if (await _context!.Roles!.FirstOrDefaultAsync(f => f.Name == _defaultRole) == null)
			{
				_ = await _context!.Roles!.AddAsync(new Role() { Name = _defaultRole });
				_ = await _context.SaveChangesAsync();
			}
			Role result = await _context!.Roles!.FirstAsync(f => f.Name == _defaultRole);
			return result;
		}
	}
}
