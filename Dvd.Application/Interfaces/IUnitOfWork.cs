using Dvd.Application.Interfaces.BusinessLogic;

namespace Dvd.Application.Interfaces
{
	public interface IUnitOfWork
	{
		public IAuthorizationRepository Authorization { get; set; }
	}
}
