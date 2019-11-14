using System;
using System.ComponentModel;
using AbiBreak.Android;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;

// [assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace AbiBreak.Android
{
    public class CustomButtonRenderer : Xamarin.Forms.Platform.Android.FastRenderers.ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
    }
}