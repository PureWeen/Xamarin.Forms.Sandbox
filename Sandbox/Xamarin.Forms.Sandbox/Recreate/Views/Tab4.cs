using System;

using Xamarin.Forms;

namespace RoutingInShell.Views
{
    public class Tab4 : ContentPage
    {
        public Tab4()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "      Hello ContentPage" }
                }
            };
        }
    }
}

