using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using Xamarin.Essentials;

namespace Xamarin.Forms.Sandbox
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellPage : Shell
	{
		public ShellPage()
		{
			InitializeComponent();
			this.BindingContext = new ShellViewModel();
			this.Navigating += OnShellPageNavigating;
			this.Navigated += OnShellNavigated;
		}

		async void OnShellNavigated(object sender, ShellNavigatedEventArgs e)
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
	}
}