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
            Shell.Current.Navigating += Current_Navigating;
        }

        private void Current_Navigating(object sender, ShellNavigatingEventArgs e)
        {
            if (!(entryCustomer?.Text?.Length > 0))
                e.Cancel();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Shell.Current.Navigating -= Current_Navigating;
        }

        private void entryCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoBack.ChangeCanExecute();
        }
    }
}