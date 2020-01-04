using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using RoutingInShell.Views;
using Xamarin.Forms;

namespace RoutingInShell
{
    public partial class AppShell : Shell
    {
        Random rand = new Random();
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
            this.Navigating += AppShell_Navigating;

            Routing.RegisterRoute("Tab1/Tab1A", typeof(Tab1A));
            Routing.RegisterRoute("Tab1/Tab1B", typeof(Tab1B));
            Routing.RegisterRoute("Tab1/Tab1C", typeof(Tab1C));

            Routing.RegisterRoute("Tab2/Tab2A", typeof(Tab2A));
            Routing.RegisterRoute("Tab2/Tab2B", typeof(Tab2B));
            Routing.RegisterRoute("Tab2/Tab2C", typeof(Tab2C));

            Routing.RegisterRoute("Tab3/Tab3A", typeof(Tab3A));
            Routing.RegisterRoute("Tab3/Tab3B", typeof(Tab3B));
            Routing.RegisterRoute("Tab3/Tab3C", typeof(Tab3C));
        }

        private void AppShell_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            Debug.WriteLine("Target:-\n" + e.Target.Location.OriginalString + "\n");
        }
    }
}
