using Dvd.Application.Interfaces;
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

		public async Task CreateAdmin()
		{

			if (await Exist("Admin1")) ;
			{
				await _context!.Users!.AddAsync(new User { Role = new Role { Name = "Admin" }, Password = "Admin1", UserName = "Admin1" });
				await _context!.SaveChangesAsync();
			}
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
		public async Task<bool> Exist(string name)
		{
			var c = await _context!.Users!.FirstOrDefaultAsync(u => u.UserName == name);
			if (c==null)
			{
				return false;
			}
			return true;
		}
		public async Task<Role> GetRole(int id)
		{
			Role? role = await _context!.Roles!.FirstOrDefaultAsync(u => u.Id == id);
			return role ?? throw new NullReferenceException();
		}
	}
}
