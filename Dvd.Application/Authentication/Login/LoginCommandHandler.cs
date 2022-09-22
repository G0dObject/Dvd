using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;
using MediatR;

namespace Dvd.Application.Authentication.Login
{
	public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
	{
		private IUnitOfWork _unitOfWork;
		public LoginCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		async Task<User> IRequestHandler<LoginCommand, User>.Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			
			foreach (var auth in await _unitOfWork.Authorization.GetAllAsync())
			{
				if (request.UserName == auth.UserName && request.Password == auth.Password)
				{
					
				}
			}
			return new User();
		}
	}
}
