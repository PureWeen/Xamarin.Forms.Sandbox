using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace Xamarin.Forms.Sandbox.Droid
{
    [Activity(Label = "Xamarin.Forms.Sandbox", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { global::Android.Content.Intent.ActionView },
                       AutoVerify = true,
                       Categories = new[]
                       {
                            global::Android.Content.Intent.CategoryDefault,
                            global::Android.Content.Intent.CategoryBrowsable
                       },
                       DataScheme = "https",
                       DataHost = "dotnetconf.net")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            LoadApplication(App.GetApplication());
            (Shell.Current as ShellPage).ProcessInitialNavigation(Intent?.Data?.ToString());
        }

        protected override void OnResume()
        {
            base.OnResume(); 
        }
    }
}