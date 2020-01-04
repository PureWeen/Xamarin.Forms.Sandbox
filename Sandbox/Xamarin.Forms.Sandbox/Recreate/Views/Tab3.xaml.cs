using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoutingInShell.Views
{
    public partial class Tab3 : ContentPage
    {
        public Tab3()
        {
            InitializeComponent();
        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab3/Tab3A");
        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab3/Tab3B");
        }

        void OnButton3Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab3/Tab3C");
        }
    }
}
