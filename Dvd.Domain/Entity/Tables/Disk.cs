using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Tables
{
	public class Disk : EntityBase
	{
		public string Name { get; set; }
		public string AgeCategory { get; set; }
		public bool IsTaken { get; set; }
	}
}
