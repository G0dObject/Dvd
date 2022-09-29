using Dvd.Domain.Entity.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dvd.Persistent.EntityTypeConfiguration
{
	internal class RentedOption : IEntityTypeConfiguration<Rented>
	{
		public void Configure(EntityTypeBuilder<Rented> builder)
		{
			_ = builder.HasKey(r => r.Id);
			_ = builder.Property(r => r.TakeTime);
			_ = builder.Property(r => r.DeliveryTime);
		}
	}
}
