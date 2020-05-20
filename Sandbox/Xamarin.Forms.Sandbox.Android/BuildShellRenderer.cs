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
        }

        void OnUpdateLayout()
        {
            if (_titleViewContainer != null)
            {
                _titleViewContainer.LayoutParameters = new AndroidX.AppCompat.Widget.Toolbar.LayoutParams(_appBar.MeasuredWidth, LP.MatchParent);
                Layout.LayoutChildIntoBoundingRegion(appBarView, new Rectangle(0, 0, _appBar.MeasuredWidth, _appBar.MeasuredHeight));
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
               // _titleViewContainer = new ContainerView(shellContext.AndroidContext, appBarView);
                //_titleViewContainer.MatchHeight = _titleViewContainer.MatchWidth = true;
                //_titleViewContainer.LayoutParameters = new Toolbar.LayoutParams(LP.MatchParent, LP.MatchParent);
                Toolbar.AddView(_titleViewContainer);
            }

            appBarView.BackgroundColor = Color.Purple;
        }

        public bool CanNavigateBack { get; set; }
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