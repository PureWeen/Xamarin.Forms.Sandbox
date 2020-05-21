using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using AView = Android.Views.View;
using Android.Views;
using Android.Content;
using Xamarin.Forms.TabView;

using LP = Android.Views.ViewGroup.LayoutParams;

#if __ANDROID_29__
using AndroidX.Fragment.App;
using Xamarin.Forms.Platform.Android;
#else
using Android.Support.V4.App;
#endif

namespace Xamarin.Forms.Sandbox.Droid
{
    public class TabViewShellRenderer : IShellItemRenderer
    {
        TabViewFragmentContainer TabViewFragmentContainer;
        TabView.TabView TabView;
        public TabViewShellRenderer(IShellContext shellContext)
        {
            TabView = new ShellTabView();
            TabViewFragmentContainer = new TabViewFragmentContainer(TabView);
        }

        private ShellItem shellItem;

        public AndroidX.Fragment.App.Fragment Fragment => TabViewFragmentContainer;

        public ShellItem ShellItem
        {
            get => shellItem;
            set
            {
                shellItem = value;
                UpdateTabView();
            }
        }

        private void UpdateTabView()
        {
            TabView.TabItems.Clear();

            foreach (var item in ShellItem.Items)
            {
                View content = null;
                if (item.Items.Count == 1)
                {
                    content = (View)((item.CurrentItem as IShellContentController).GetOrCreateContent() as ContentPage).Content;
                    
                }
                else
                {
                    TabViewContent tabViewContent = new TabViewContent();
                    foreach (var shellContent in item.Items)
                    {
                        tabViewContent.TabItems.Add(new TabViewItem()
                        {
                            Text = shellContent.Title,
                            Content = (View)((shellContent as IShellContentController).GetOrCreateContent() as ContentPage).Content
                        });
                    }

                    content = tabViewContent;
                }

                TabView.TabItems.Add(new TabViewItem()
                {
                    Text = item.Title,
                    Content = content
                });
            }
        }

        public event EventHandler Destroyed;

        public void Dispose()
        {
            Destroyed?.Invoke(this, EventArgs.Empty);

        }
    }

    internal class TabViewFragmentContainer : Fragment
    {
        readonly WeakReference _pageRenderer;

        //Action<ContainerView> _onCreateCallback;
        ContainerView _pageContainer;
        //IVisualElementRenderer _visualElementRenderer;

        public TabViewFragmentContainer()
        {
        }

        public TabViewFragmentContainer(View view) : this()
        {
            _pageRenderer = new WeakReference(view);
        }


        public static Fragment CreateInstance(View view)
        {
            return new TabViewFragmentContainer(view) { Arguments = new Bundle() };
        }

        //public void SetOnCreateCallback(Action<PageContainer> callback)
        //{
        //	_onCreateCallback = callback;
        //}


        protected virtual ContainerView CreatePageContainer(Context context, View child)
        {
            var layoutParams = new LP(LP.MatchParent, LP.MatchParent);
            return new ContainerView(context, child) { MatchHeight = true, MatchWidth = true, LayoutParameters = layoutParams };
        }

        public override AView OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //_visualElementRenderer = Xamarin.Android.Platform.CreateRenderer(Page, ChildFragmentManager, inflater.Context);
            //	Android.Platform.SetRenderer(Page, _visualElementRenderer);

            _pageContainer = CreatePageContainer(inflater.Context, (View)_pageRenderer.Target);

            //_onCreateCallback?.Invoke(_pageContainer);

            return _pageContainer;
        }

        //		public override void OnDestroyView()
        //		{
        //			if (Page != null)
        //			{
        //				if (_visualElementRenderer != null)
        //				{
        //					if (_visualElementRenderer.View.Handle != IntPtr.Zero)
        //					{
        //						_visualElementRenderer.View.RemoveFromParent();
        //					}

        //					_visualElementRenderer.Dispose();
        //				}

        //				// We do *not* eagerly dispose of the _pageContainer here; doing so  causes a memory leak 
        //				// if animated fragment transitions are enabled (it removes some info that the animation's 
        //				// onAnimationEnd handler requires to properly clean things up)
        //				// Instead, we let the garbage collector pick it up later, when we can be sure it's safe

        //				Page?.ClearValue(Android.Platform.RendererProperty);
        //			}

        //			_onCreateCallback = null;
        //			_visualElementRenderer = null;

        //			base.OnDestroyView();
        //		}

        //		public override void OnHiddenChanged(bool hidden)
        //		{
        //			base.OnHiddenChanged(hidden);

        //			if (Page == null)
        //				return;

        //			if (hidden)
        //				PageController?.SendDisappearing();
        //			else
        //				PageController?.SendAppearing();
        //		}

        //		public override void OnPause()
        //		{
        //#if __ANDROID_29__
        //			_isVisible = false;
        //#endif

        //			bool shouldSendEvent = Application.Current.OnThisPlatform().GetSendDisappearingEventOnPause();
        //			if (shouldSendEvent)
        //				SendLifecycleEvent(false);

        //			base.OnPause();
        //		}

        //		public override void OnResume()
        //		{

        //#if __ANDROID_29__
        //			_isVisible = true;
        //#endif

        //			bool shouldSendEvent = Application.Current.OnThisPlatform().GetSendAppearingEventOnResume();
        //			if (shouldSendEvent)
        //				SendLifecycleEvent(true);

        //			base.OnResume();
        //		}

        //		void SendLifecycleEvent(bool isAppearing)
        //		{
        //			var masterDetailPage = Application.Current.MainPage as MasterDetailPage;
        //			var pageContainer = (masterDetailPage != null ? masterDetailPage.Detail : Application.Current.MainPage) as IPageContainer<Page>;
        //			Page currentPage = pageContainer?.CurrentPage;

        //			if (!(currentPage == null || currentPage == PageController))
        //				return;

        //#if __ANDROID_29__
        //			if (isAppearing && _isVisible)
        //#else
        //			if (isAppearing && UserVisibleHint)
        //#endif
        //				PageController?.SendAppearing();
        //			else if (!isAppearing)
        //				PageController?.SendDisappearing();
        //		}
    }
}