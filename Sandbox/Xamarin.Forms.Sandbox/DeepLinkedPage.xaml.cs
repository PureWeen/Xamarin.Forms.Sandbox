using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
    [QueryProperty("Id", "Id")]
    public class DeepLinkedPageViewModel : INotifyPropertyChanged
    {
        private string id;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeepLinkedPage : ContentPage
    {
        public DeepLinkedPage()
        {
            InitializeComponent();
            BindingContext = new DeepLinkedPageViewModel();
        }

        async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Shell.Current.GoToAsync("//HomePage");

        }
    }
}