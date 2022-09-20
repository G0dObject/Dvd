using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvd.Persistent.EntityTypeConfiguration
{
	internal class UserOption : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			_ = builder.HasKey(u => u.UserName);
			_ = builder.HasKey(u => u.Password);
		}
	}
}
