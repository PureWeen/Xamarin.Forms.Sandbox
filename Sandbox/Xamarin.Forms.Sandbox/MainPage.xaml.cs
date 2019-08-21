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
            var label = new Label
            {
                AutomationId = "TextTypeLabel",
                Text = "<h1>Hello World!</h1>"
            };

            var button = new Button
            {
                AutomationId = "ToggleTextTypeButton",
                Text = "Toggle HTML/Plain"
            };

            button.Clicked += (s, a) =>
            {
                label.TextType = label.TextType == TextType.Html ? TextType.PlainText : TextType.Html;
            };


            Label htmlLabel = new Label() { TextType = TextType.Html };
            Label normalLabel = new Label();
            Label nullLabel = new Label() { TextType = TextType.Html };

            Button toggle = new Button()
            {
                Text = "Toggle some more things",
                Command = new Command(() =>
                {
                    htmlLabel.Text = $"<b>{DateTime.UtcNow}</b>";
                    normalLabel.Text = $"<b>{DateTime.UtcNow}</b>";

                    if (String.IsNullOrWhiteSpace(nullLabel.Text))
                        nullLabel.Text = "hi there";
                    else
                        nullLabel.Text = null;
                })
            };


            var stacklayout = new StackLayout();
           // stacklayout.Children.Add(label);
           // stacklayout.Children.Add(button);
           // stacklayout.Children.Add(htmlLabel);
            stacklayout.Children.Add(normalLabel);
            stacklayout.Children.Add(nullLabel);
            stacklayout.Children.Add(toggle);

            Content = stacklayout;

        }

    }
}