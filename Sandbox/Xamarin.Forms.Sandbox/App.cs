using System;
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
		public static Application GetApplication()
		{
			Forms.Device.SetFlags(new List<string> {
				"Shell_UWP_Experimental",
				"StateTriggers_Experimental",
				"IndicatorView_Experimental",
				"CarouselView_Experimental",
				"SwipeView_Experimental",
				"MediaElement_Experimental"});

			return new App();
		}

		void AddStyleSheet()
		{
			this.Resources.Add(StyleSheet.FromResource(
				"Styles.css",
				IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly));
		}

		void InitializeLegacyRenderers()
		{
			var flags = new List<String>(Device.Flags);
			flags.Add("UseLegacyRenderers");
			Device.SetFlags(flags.Select(x => x).Distinct().ToArray());
		}
	}
}
