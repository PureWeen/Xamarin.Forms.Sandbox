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
            if(Device.RuntimePlatform == Device.UWP)
                MainPage = new MainPage();
            else
			    MainPage = new ShellPage();
		}
	}
}
