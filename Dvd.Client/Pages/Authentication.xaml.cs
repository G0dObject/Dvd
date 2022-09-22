using Dvd.Persistent;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Windows;

namespace Client.Pages
{
	/// <summary>
	/// Interaction logic for Authentication.xaml
	/// </summary>
	public partial class Authentication : Window
	{
		public Authentication()
		{
			InitializeComponent();
			Context g = new Context(new DbContextOptions<Context>());
			
			UnitOfWork unitOfWork = new UnitOfWork(g);
			unitOfWork.Authorization.CreateAsync(new Dvd.Domain.Entity.Authorization.Authorization());
		}
	}
}
