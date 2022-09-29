using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Dvd.Persistent.EntityTypeConfiguration
{
	internal class DiskOption : IEntityTypeConfiguration<Disk>
	{
		public void Configure(EntityTypeBuilder<Disk> builder)
		{
			_ = builder.HasKey(r => r.Id);
			_ = builder.Property(r => r.Name);
			_ = builder.Property(r=>r.IsTaken).HasDefaultValue(false);
			_ = builder.Property(r => r.AgeCategory);
		}
	}
}
