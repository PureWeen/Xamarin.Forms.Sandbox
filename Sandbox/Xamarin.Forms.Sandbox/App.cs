﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.StyleSheets;
using System.Reflection;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.Forms.Sandbox
{
	public partial class App : Application
	{
		public App()
		{
			Device.SetFlags(new[] { "Shell_Experimental", "CollectionView_Experimental" });
			InitializeMainPage();
		}

		void AddStyleSheet()
		{
		}

		void InitializeLegacyRenderers()
		{
			var flags = new List<String>(Device.Flags);
			flags.Add("UseLegacyRenderers");
			Device.SetFlags(flags.Select(x => x).Distinct().ToArray());
		}
	}
}
