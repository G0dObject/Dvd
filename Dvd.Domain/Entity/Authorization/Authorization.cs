using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Authorization
{
	public class Authorization : EntityBase
	{
		public string UserName { get; set; }
		public int Password { get; set; }
	}
}
