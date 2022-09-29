using System.ComponentModel;

namespace Dvd.Client.Model
{
	public class RegisterModel : IDataErrorInfo
	{
		public string UserName { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string PasswordConfirm { get; set; } = string.Empty;

		public string Error { get; private set; } = string.Empty;

		public string this[string columnName]
		{
			get
			{
				Error = string.Empty;
				switch (columnName)
				{
					case "UserName":
						if (UserName!.Length < 6 || UserName == null)
						{
							Error = "Username must contain six letters";
						}
						break;

					case "Password":
						if (Password!.Length < 6 || columnName == null)
						{
							Error = "Password must contain six letters";
						}
						break;
					case "PasswordConfirm":
						if (PasswordConfirm != Password)
						{
							Error = "All password fields my be equals";
						}
						break;

					default:
						break;
				}
				return Error;
			}
		}


	}
}
