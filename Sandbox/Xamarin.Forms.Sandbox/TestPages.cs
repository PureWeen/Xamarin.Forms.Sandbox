using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Sandbox
{
    [Obsolete]
    public abstract class TestMasterDetailPage : MasterDetailPage
    {
        protected TestMasterDetailPage()
        {
            Init();
        }

        abstract protected void Init();
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }

    public abstract class TestTabbedPage : TabbedPage
    {
        protected TestTabbedPage()
        {
            Init();
        }

        abstract protected void Init();

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }

    public abstract class TestNavigationPage : NavigationPage
    {
        protected TestNavigationPage()
        {
            Init();
        }

        abstract protected void Init();
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
