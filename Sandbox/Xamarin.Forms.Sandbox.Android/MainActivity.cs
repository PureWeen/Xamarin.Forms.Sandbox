﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Xamarin.Forms.Sandbox.Droid
{
    [Activity(Label = "Xamarin.Forms.Sandbox", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
#if DUALSCREEN
            global::Xamarin.Forms.DualScreen.DualScreenService.Init(this);
#endif
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
#if VISUAL
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
#endif
            LoadApplication(App.GetApplication());
        }
    }
}