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
            bool useTabPage = false;
            bool useMDP = false;
            bool useMainPage = false;
            bool useNavigationPage = false;

            if(useNavigationPage)
                MainPage = new NavigationPage(new MainPage());
            else if (useMainPage)
                MainPage = new MainPage();
            else if (useMDP)
                MainPage = new MDP();
            else if (useTabPage)
                MainPage = new TabPage();
            else
                MainPage = new ShellPage();
        }
    }
}
