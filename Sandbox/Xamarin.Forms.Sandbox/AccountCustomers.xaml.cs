using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountCustomers : ContentPage
    {
        public List<string> Customers { get; }
        public AccountCustomers()
        {
            InitializeComponent();

            Customers = new List<string>
            {
                "Tom",
                "Mr Mom",
                "Rabbit",
                "Blue",
                "Mr Aba Dee",
                "Mr Aba Die"
            };
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (Shell.GetSearchHandler(this) as CustomerSearchHandler)
                .AccountPage = this;
        }

        internal void SetSearchResult(string query)
        {
            lblCustomer.Text = query;
        }
    }

    public class CustomerSearchHandler : SearchHandler
    {
        public AccountCustomers AccountPage { get; internal set; }

        protected override void OnItemSelected(object item)
        {
            base.OnItemSelected(item);
            AccountPage.SetSearchResult(item.ToString());
        }

    }
}