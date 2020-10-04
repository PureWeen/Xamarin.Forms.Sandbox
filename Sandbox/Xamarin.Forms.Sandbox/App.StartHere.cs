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
            Routing.RegisterRoute(nameof(SandboxNavigationPage), typeof(SandboxNavigationPage));
            Routing.RegisterRoute(nameof(ModalNavigationPage), typeof(ModalNavigationPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

            bool useTabPage = false;
            bool useMDP = false;
            bool useMainPage = false;
            bool useNavigationPage = false;

            if (useNavigationPage)
                MainPage = new NavigationPage(new MainPage());
            else if (useMainPage)
                MainPage = new MainPage();
            else if (useMDP)
#pragma warning disable CS0612 // Type or member is obsolete
                MainPage = new MDP();
#pragma warning restore CS0612 // Type or member is obsolete
            else if (useTabPage)
                MainPage = new TabPage();
            else
                MainPage = new ShellPage();
        }

        public static Application GetApplication()
        {
            Forms.Device.SetFlags(new List<string> {
                "Shell_UWP_Experimental",
                "StateTriggers_Experimental",
                "IndicatorView_Experimental",
                "CarouselView_Experimental",
                "SwipeView_Experimental",
                "AppTheme_Experimental",
                "MediaElement_Experimental",
                "RadioButton_Experimental",
                "DragAndDrop_Experimental",
                "Shapes_Experimental",
                "Brush_Experimental"});

            return new App();
        }
    }
}
