using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Tables
{
	public class Role : EntityBase
	{
		public string Name { get; set; }
		public virtual ICollection<User> Users { get; set; }
	}
}
