using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms.StyleSheets;

namespace Xamarin.Forms.Sandbox
{
    public partial class App : Application
    {
        public App()
        {
            Routing.RegisterRoute("ModalPage", typeof(ModalPage));

            MainPage = new ShellPage();
        }
    }
}
