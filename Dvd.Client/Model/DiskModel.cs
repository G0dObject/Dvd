using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dvd.Client.Model
{
	public class DiskModel : INotifyPropertyChanged
	{
		public string? Id
		{
			get => Id; set
			{
				Id = value;
				OnPropertyChanged(nameof(Id));
			}
		}
		public string? Name
		{
			get => Name; set
			{
				Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		public string? AgeCategory
		{
			get => AgeCategory; set
			{
				AgeCategory = value;
				OnPropertyChanged(nameof(AgeCategory));
			}
		}
		public bool IsTaken
		{
			get => IsTaken; set
			{
				IsTaken = value;
				OnPropertyChanged(nameof(IsTaken));
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
