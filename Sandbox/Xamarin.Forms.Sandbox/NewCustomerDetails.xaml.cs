using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCustomerDetails : ContentPage
    {
        public Command GoBack { get;  }
        public NewCustomerDetails()
        {
            InitializeComponent();
            GoBack = new Command(async () =>
            {
                if (entryCustomer?.Text?.Length > 0)
                    await Shell.Current.GoToAsync("..");
                else
                    await DisplayAlert("ERROR", "Please fill out the form. Maybe try the back button?", "Ok");
            });

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.Current.Navigating += ShellNavigating;
        }

        private async void ShellNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // No Back Button For You!!!
            if (!(entryCustomer?.Text?.Length > 0))
            {
                e.Cancel();
                await DisplayAlert("ERROR", "Nope!! You better just fill out the form.", "FINE");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Shell.Current.Navigating -= ShellNavigating;
        }

        private void entryCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoBack.ChangeCanExecute();
        }
    }
}