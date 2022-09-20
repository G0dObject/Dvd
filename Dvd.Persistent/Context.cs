using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;
using Dvd.Persistent.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Dvd.Persistent
{
	public class Context : DbContext, IContext
	{
		public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions) { _ = Initializer.Initialize(this); }

		public DbSet<User>? User { get; set; }
		public DbSet<Role>? Role { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				_ = optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["SqLite"].ConnectionString);
			}
		}
		protected override void OnModelCreating(ModelBuilder option)
		{
			_ = option.ApplyConfiguration(new UserOption());
			_ = option.ApplyConfiguration(new RoleOption());
			base.OnModelCreating(option);
		}
	}
}
