﻿using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dvd.Persistent.EntityTypeConfiguration
{
    internal class RoleOption : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			_ = builder.HasKey(u => u.Name);
		}
	}
}
