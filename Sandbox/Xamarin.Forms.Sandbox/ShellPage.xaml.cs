using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Xamarin.Forms.Sandbox
{
	public class FlyoutItemExtended : FlyoutItem
	{
		public bool IsVisible
		{
			set
			{
				if (value)
				{
					if (!Shell.Current.Items.Contains(this))
						Shell.Current.Items.Add(this);
				}
				else
				{
					if (Shell.Current.Items.Contains(this))
						Shell.Current.Items.Remove(this);
				}
			}
		}
	}

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellPage : Shell
	{

		
		public ShellPage()
		{
			if (this.Items?.Count > 0)
				this.Items.Clear();

			InitializeComponent();
			this.BindingContext = new ShellViewModel();
			this.Navigating += OnShellPageNavigating;
			this.Navigated += OnShellNavigated;
		}

		void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
		{
			Preferences.Set("LastKnownUrl", e.Current.Location.ToString());
		}

		void OnShellPageNavigating(object sender, ShellNavigatingEventArgs e)
		{
		}

		async public void ProcessInitialNavigation(string url)
		{
			if(!String.IsNullOrWhiteSpace(url))
			{
				await this.GoToAsync(url);
				return;
			}

			var lastLocation = Preferences.Get("LastKnownUrl", (string)null);
			if(!String.IsNullOrWhiteSpace(lastLocation))
			{
				try
				{
					await this.GoToAsync(lastLocation);
				}
				catch { }
			}
		}

		async void Button_Clicked(object sender, EventArgs e)
		{
			await GoToAsync("MainPage");
		}
	}

	public class ShellViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand OpenUrlCommand { get; }

		public ShellViewModel()
		{
			OpenUrlCommand = new Command(async () =>
			{
				await Xamarin.Essentials.Launcher.TryOpenAsync(@"https://dotnetconf.net/Page?Id=12");
			});
		}
	}
}