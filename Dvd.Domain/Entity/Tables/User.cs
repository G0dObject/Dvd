﻿using Dvd.Domain.Entity.Base;

namespace Dvd.Domain.Entity.Tables
{
	public class User:EntityBase
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
	}
}
