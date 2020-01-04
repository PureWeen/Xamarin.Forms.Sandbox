using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RoutingInShell.Views
{
    public partial class Tab1A : ContentPage
    {
        public Tab1A()
        {
            InitializeComponent();
            Shell.SetTitleColor(this, Color.Blue);
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
