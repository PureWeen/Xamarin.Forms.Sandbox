using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoutingInShell.Views
{
    public partial class Tab1 : ContentPage
    {
        public Tab1()
        {
            InitializeComponent();
            Shell.SetTitleColor(this, Color.Purple);
        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab1/Tab1A");
        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab1/Tab1B");
        }

        void OnButton3Clicked(object sender, EventArgs args)
        {
            Shell.Current.GoToAsync("Tab1/Tab1C");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
