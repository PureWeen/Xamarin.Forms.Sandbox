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
                if (GoBack.CanExecute(null))
                    await Shell.Current.GoToAsync("..");
            }, canExecute: ()=>
            {
                return entryCustomer?.Text?.Length > 0;
            });

            BindingContext = this;
        }

        private void entryCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            GoBack.ChangeCanExecute();
        }
    }
}