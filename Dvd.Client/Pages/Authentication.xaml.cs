using Dvd.Application.Authentication.Login;
using Dvd.Application.Authentication.Register;
using Dvd.Client;
using Dvd.Client.Model;
using Dvd.Domain.Entity.Tables;
using Dvd.Persistent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;

namespace Client.Pages
{
	public partial class Authentication : Window
	{
		private readonly Context _context;
		private readonly UnitOfWork _unitOfWork;
		private bool _isRegister = true;
		private int _userid;
		private readonly RegisterModel command;
		public Authentication()
		{
			command = new RegisterModel();

			_context = new Context(new DbContextOptions<Context>());
			_unitOfWork = new UnitOfWork(_context);
			InitializeComponent();
			DataContext = command;
		}

		private async void RegistrationButton(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(command.Error))
			{
				try
				{
					RegisterCommand registerCommand = new(RUsername.Text, RPassword.Text, new Role() { Name = "User" });
					RegisterCommandHandler handler = new(_unitOfWork);
					_ = await handler.Handle(registerCommand);
					Ok();
				}
				catch (Exception)
				{
					throw;
				}
			}
		}
		private async void LoginButton(object sender, RoutedEventArgs e)
		{
			try
			{
				LoginQuery loginQuery = new(LUsername.Text, LPassword.Text);
				LoginQueryHandler handler = new(_unitOfWork);

				_userid = await handler.Handle(loginQuery);
				if (_userid == 0)
				{
					_ = MessageBox.Show("Login or Password incorrect");

				}
				else
				{
					Ok();
				}

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
		private async void Ok()
		{
			User? user = await _unitOfWork.Authorization.GetByIdAsync(_userid);
			MainWindow mainWindow = new(_unitOfWork, user!.Role);
			Hide();

			mainWindow.Show();
			Close();
		}
	}
}


