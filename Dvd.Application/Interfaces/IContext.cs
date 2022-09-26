using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;

namespace Dvd.Application.Interfaces
{
	public interface IContext
	{
		public DbSet<User>? Users { get; set; }
		public DbSet<Role>? Roles { get; set; }
		public DbSet<Disk>? Disks { get; set; }
		public DbSet<Rented>? Renteds { get; set; }
	}
}
