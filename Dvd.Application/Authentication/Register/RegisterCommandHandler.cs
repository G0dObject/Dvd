using CQRS.Command;
using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;

namespace Dvd.Application.Authentication.Register
{
	public class RegisterCommandHandler : ICommandHandler<RegisterCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;
		public RegisterCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<int> Handle(RegisterCommand request)
		{
			User current = new()
			{
				UserName = request.UserName,
				Password = request.Password,
				Role = await _unitOfWork.Authorization.GetDefaultRole()
			};
			
			var result = _unitOfWork.Authorization.CreateAsync(current);
			return result.Id;
		}
	}
}
