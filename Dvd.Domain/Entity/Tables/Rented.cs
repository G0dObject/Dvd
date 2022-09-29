using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Tables
{
	public class Rented : EntityBase
	{
		public DateTime TakeTime { get; set; }
		public DateTime DeliveryTime { get; set; }
		public User User { get; set; }
		public Disk Disk { get; set; }
	}
}
