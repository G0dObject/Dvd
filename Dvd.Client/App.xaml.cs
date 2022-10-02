using Dvd.Persistent;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dvd.Client
{
	public partial class App : System.Windows.Application
	{
		private void Application_Exit(object sender, System.Windows.ExitEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}