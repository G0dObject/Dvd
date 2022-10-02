using Dvd.Application.Interfaces;
using Dvd.Domain.Entity.Tables;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dvd.Client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly IUnitOfWork _unitOfWork;
		public MainWindow(IUnitOfWork unitOfWork, Role role)
		{
			_unitOfWork = unitOfWork;
			InitializeComponent();
			LoadData();


		}
		private void Application_Exit(object sender, System.Windows.ExitEventArgs e)
		{
			Environment.Exit(0);
		}

		private void LoadData_Click(object sender, RoutedEventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			datagrid.Items.Clear();
			var disks = _unitOfWork.Disk.GetAllAsync();
			datagrid.AutoGenerateColumns = true;
			datagrid.BeginningEdit += (s, ss) => ss.Cancel = true;

			foreach (var item in disks.Result)
			{
				datagrid.Items.Add(item);

			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
			{
				if (vis is DataGridRow)
				{
					var row = (DataGridRow)vis;
					row.DetailsVisibility =
					row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
					break;
				}
			}
		}
	}
}
