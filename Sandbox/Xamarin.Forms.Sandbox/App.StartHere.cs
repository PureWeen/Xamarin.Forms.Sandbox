using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms.StyleSheets;

namespace Xamarin.Forms.Sandbox
{
    public partial class App
    {
        void InitializeMainPage()
        {
           
            //if(useNavigationPage)
            //    MainPage = new NavigationPage(new MainPage());
            //else if (useMainPage)
            //    MainPage = new MainPage();
            //else if (useMDP)
            //    MainPage = new MDP();
            //else if (useTabPage)
            //    MainPage = new TabPage();
            //else if (Device.RuntimePlatform == Device.UWP)
            //    MainPage = new MainPage();
            //else
            //    MainPage = new ShellPage();

            MainPage = new Xamarin.Forms.Sandbox.Views.MainPage();
        }
    }
}
