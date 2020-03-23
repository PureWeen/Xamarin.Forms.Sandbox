using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{

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