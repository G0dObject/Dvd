using Dvd.Application.Authentication.Login;
using Dvd.Application.Authentication.Register;
using Dvd.Domain.Entity.Tables;
using Dvd.Persistent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Pages
{
	public partial class Authentication : Window
	{
		private readonly Context _context;
		private readonly UnitOfWork _unitOfWork;
		private bool _isRegister = true;
		public Authentication()
		{
			InitializeComponent();
			_context = new Context(new DbContextOptions<Context>());
			_unitOfWork = new UnitOfWork(_context);
		}

		private void RegistrationButton(object sender, RoutedEventArgs e)
		{
			try
			{
				RegisterCommand registerCommand = new(RUsername.Text, RPassword.Password, new Role() { Name = "User" });
				RegisterCommandHandler handler = new(_unitOfWork);
				_ = Task.Run(() => handler.Handle(registerCommand));
			}
			catch (Exception)
			{
				throw;
			}
		}
		private async void LoginButton(object sender, RoutedEventArgs e)
		{
			try
			{
				LoginQuery loginQuery = new(LUsername.Text, LPassword.Password);
				LoginQueryHandler handler = new(_unitOfWork);

				int userid = await handler.Handle(loginQuery);
				_ = userid == 0 ? MessageBox.Show("Login or Password incorrect") : MessageBox.Show("Loggin correct");
			}
			catch (Exception)
			{
				throw;
			}
		}
		private void SwapMode(object sender, RoutedEventArgs e)
		{
			if (_isRegister)
			{
				Login.Visibility = Visibility.Visible;
				Register.Visibility = Visibility.Hidden;

				SwapButton.Content = "Register";
				_isRegister = false;
			}
			else
			{
				Login.Visibility = Visibility.Hidden;
				Register.Visibility = Visibility.Visible;

				SwapButton.Content = "Login";
				_isRegister = true;
			}
		}
	}
}


