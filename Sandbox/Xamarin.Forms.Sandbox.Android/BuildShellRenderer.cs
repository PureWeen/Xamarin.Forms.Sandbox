using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.AppBar;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Sandbox.Droid;
using LP = Android.Views.ViewGroup.LayoutParams;

[assembly: ExportRenderer(typeof(Shell), typeof(BuildShellRenderer))]
namespace Xamarin.Forms.Sandbox.Droid
{
    public class BuildShellRenderer : ShellRenderer
    {
        public BuildShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellToolbarTracker CreateTrackerForToolbar(AndroidX.AppCompat.Widget.Toolbar toolbar)
        {
            return new AppBarToolbarTracker(this, toolbar, ((IShellContext)this).CurrentDrawerLayout);
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new TabViewShellRenderer(this);
        }
    }

    public class AppBarToolbarTracker : IShellToolbarTracker
    {
        AppBarLayout _appBar;
        private Page _page;
        private AppBar appBarView;
        private global::Android.Views.View _titleViewContainer;
        private readonly Context context;
        private readonly IShellContext shellContext;
        public AndroidX.AppCompat.Widget.Toolbar Toolbar { get; }
        public DrawerLayout DrawerLayout { get; }
        GenericGlobalLayoutListener _globalLayoutListener;

        public AppBarToolbarTracker(IShellContext shellContext, AndroidX.AppCompat.Widget.Toolbar toolbar, DrawerLayout drawerLayout)
        {
            context = shellContext.AndroidContext;
            this.shellContext = shellContext;
            Toolbar = toolbar;
            DrawerLayout = drawerLayout;
            _appBar = Toolbar.Parent.GetParentOfType<AppBarLayout>();
            _globalLayoutListener = new GenericGlobalLayoutListener(OnUpdateLayout);
            _appBar.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);

            Toolbar.SetContentInsetsAbsolute(0, 0);
            Toolbar.SetContentInsetsRelative(0, 0);
        }

        int width;
        private bool canNavigateBack;

        void OnUpdateLayout()
        {
            if (_titleViewContainer != null && width != _appBar.MeasuredWidth)
            {
                width = _appBar.MeasuredWidth;
                _titleViewContainer.LayoutParameters = new AndroidX.AppCompat.Widget.Toolbar.LayoutParams(_appBar.MeasuredWidth, LP.MatchParent);
                Layout.LayoutChildIntoBoundingRegion(appBarView, new Rectangle(0, 0, context.FromPixels(_appBar.MeasuredWidth), context.FromPixels(_appBar.MeasuredHeight)));
            }
        }

        public Page Page
        {
            get { return _page; }
            set
            {
                if (_page == value)
                    return;
                var oldPage = _page;
                _page = value;
                OnPageChanged(oldPage, _page);
            }
        }

        private void OnPageChanged(Page oldPage, Page page)
        {
            if (appBarView == null)
            {
                appBarView = new Xamarin.Forms.AppBar();
                var renderer = Platform.Android.Platform.CreateRendererWithContext(appBarView, context);
                _titleViewContainer = renderer.View;
                Toolbar.AddView(_titleViewContainer);

                UpdateBackButtonText();

                appBarView.BackCommand = new Command(OnBackButtonClicked);
            }
        }

        private async void OnBackButtonClicked(object obj)
        {
            if (CanNavigateBack)
                await Page.Navigation.PopAsync();
            else
                shellContext.Shell.FlyoutIsPresented = true;            
        }

        public bool CanNavigateBack
        {
            get => canNavigateBack; 
            set
            {
                canNavigateBack = value;
                UpdateBackButtonText();
            }
        }

        void UpdateBackButtonText()
        {
            if (appBarView != null)
            {
                if (!canNavigateBack)
                {
                    appBarView.BackButtonTitle = "Burger";
                    appBarView.BarTextColor = Color.White;
                }                
                else
                    appBarView.BackButtonTitle = null;
            }

        }

        public Color TintColor { get; set; }

        public void Dispose()
        {
        }
    }

    internal class GenericGlobalLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
    {
        Action _callback;

        public GenericGlobalLayoutListener(Action callback)
        {
            _callback = callback;
        }

        public void OnGlobalLayout()
        {
            _callback?.Invoke();
        }

        protected override void Dispose(bool disposing)
        {
            Invalidate();
            base.Dispose(disposing);
        }

        // I don't want our code to dispose of this class I'd rather just let the natural
        // process manage the life cycle so we don't dispose of this too early
        internal void Invalidate()
        {
            _callback = null;
        }
    }
}
