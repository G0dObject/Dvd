using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Dvd.Application.Interfaces
{
    public interface IContext 
	{
		public DbSet<User>? User { get; set; }
		public DbSet<Role>? Role { get; set; }
	}
}
