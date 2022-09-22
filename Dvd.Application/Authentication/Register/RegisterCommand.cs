using Dvd.Domain.Entity.Tables;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Cqrs.Command;

namespace Dvd.Application.Authentication.Register
{
	public class RegisterCommand : ICommand<User>
	{
		[Required]
		public string? UserName { get; set; }
		[Required]
		public int Password { get; set; }
	}
}
