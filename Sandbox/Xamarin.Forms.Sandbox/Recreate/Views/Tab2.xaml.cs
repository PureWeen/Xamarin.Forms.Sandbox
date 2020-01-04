using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoutingInShell.Views
{
    public partial class Tab2 : ContentPage
    {
        public Tab2()
        {
            InitializeComponent();
        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab2/Tab2A");
        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab2/Tab2B");
        }

        void OnButton3Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab2/Tab2C");
        }
    }
}
