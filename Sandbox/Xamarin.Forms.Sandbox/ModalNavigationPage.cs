using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Sandbox
{
    public class ModalNavigationPage : NavigationPage
    {
        public ModalNavigationPage() : base(new MainPage())
        {
            Shell.SetPresentationMode(this, PresentationMode.Modal);
        }
    }
}
