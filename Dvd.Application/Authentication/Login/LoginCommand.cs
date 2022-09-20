using Dvd.Domain.Entity.Tables;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dvd.Application.Authentication.Login
{
	internal class LoginCommand : IRequest<User>
	{
		[Required]
		public string? UserName { get; set; }
		[Required]
		public int Password { get; set; }
	}
}
