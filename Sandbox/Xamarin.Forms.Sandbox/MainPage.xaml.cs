using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
    {
		public string Text { get; set; } = Guid.NewGuid().ToString();
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = this;
		}

		private async void Button2_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			int count = Navigation.NavigationStack.Count - 1;
			for (int i = count; i > 0; i--)
			{
				Navigation.RemovePage(Navigation.NavigationStack[i]);
			}
		}
	}
}