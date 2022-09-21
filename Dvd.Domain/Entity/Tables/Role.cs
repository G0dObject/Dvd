using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Tables
{
    public class Role : EntityBase
	{
        public int Name { get; set; }
        virtual public ICollection<User> Users {get;set;}

	}
}
