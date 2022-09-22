using Cqrs.Command;
using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;



namespace Dvd.Application.Authentication.Register
{
	public class RegisterCommandHandler : ICommandHandler<RegisterCommand,User>
	{
		private IUnitOfWork _unitOfWork;
		public RegisterCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		
	}
}
