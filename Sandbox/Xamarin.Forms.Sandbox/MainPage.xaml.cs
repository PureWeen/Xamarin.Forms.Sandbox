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
		public MainPage()
		{
			InitializeComponent();
            btnClick.Clicked += BtnClick_Clicked;
		}

        async void BtnClick_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), false);
        }
    }
}