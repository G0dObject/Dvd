using CQRS.Command;
using Dvd.Domain.Entity.Tables;
using System.ComponentModel.DataAnnotations;

namespace Dvd.Application.Authentication.Register
{
	public class RegisterCommand : ICommand<int>
	{
		public RegisterCommand(string? username, string? password, Role role)
		{
			UserName = username;
			Password = password;
			Role = role;
		}
		[Required]
		public string? UserName { get; set; }
		[Required]
		public string? Password { get; set; }

		public Role Role { get; set; }

	}
}
