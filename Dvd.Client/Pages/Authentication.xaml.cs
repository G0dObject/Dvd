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
		private Role _role = new Role();
		private int _userid;
		private readonly RegisterModel command;
		public Authentication()
		{
			command = new RegisterModel();

			_context = new Context(new DbContextOptions<Context>());
			_unitOfWork = new UnitOfWork(_context);
			InitializeComponent();
			DataContext = command;

			_unitOfWork.Authorization.CreateAdmin();
		}

		private async void RegistrationButton(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(command.Error))
			{
				try
				{
					RegisterCommand registerCommand = new(RUsername.Text, RPassword.Text, new Role() { Name = "User" });
					RegisterCommandHandler handler = new(_unitOfWork);

					if (await _unitOfWork.Authorization.Exist(registerCommand.UserName!))
					{
						MessageBox.Show("user already registered");
						return;
					}
					_userid = await handler.Handle(registerCommand);

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

				int result = await handler.Handle(loginQuery);

				_role = await _unitOfWork.Authorization.GetRole(result);
				Ok();
			}
			catch (Exception)
			{
				MessageBox.Show("Что-то не так, попробуйте снова");
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
		private void Ok()
		{
			MainWindow mainWindow = new(_unitOfWork, _role);
			Hide();

			mainWindow.Show();
			Close();
		}
	}
}


