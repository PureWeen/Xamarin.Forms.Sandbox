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
            label.Text = "<b>I am some text</b>";
            button.Clicked += Button_Clicked;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (label.TextType == TextType.Html)
                label.TextType = TextType.PlainText;
            else
                label.TextType = TextType.Html;
        }
    }
}