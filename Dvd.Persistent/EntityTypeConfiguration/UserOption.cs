using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dvd.Persistent.EntityTypeConfiguration
{
	internal class UserOption : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			_ = builder.HasKey(u => u.Id);
			_ = builder.Property(u => u.UserName);
			_ = builder.Property(u => u.Password);
		}
	}
}
