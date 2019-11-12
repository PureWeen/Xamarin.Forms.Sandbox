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

//[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(CustomButtonRenderer))]
namespace AbiBreak.Android
{
    public class CustomButtonRendererInterface : AppCompatButton, IVisualElementRenderer
    {
        public CustomButtonRendererInterface(Context context) : base(context)
        {
        }

        public VisualElement Element => throw new NotImplementedException();

        public VisualElementTracker Tracker => throw new NotImplementedException();

        public ViewGroup ViewGroup => throw new NotImplementedException();

        public global::Android.Views.View View => throw new NotImplementedException();

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
        public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;

        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
        {
            throw new NotImplementedException();
        }

        public void SetElement(VisualElement element)
        {
            throw new NotImplementedException();
        }

        public void SetLabelFor(int? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLayout()
        {
            throw new NotImplementedException();
        }
    }
}