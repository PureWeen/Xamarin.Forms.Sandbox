using System.ComponentModel;

namespace Xamarin.Forms.Sandbox
{
    [QueryProperty("Id", "Id")]
    public class DeepLinkedPageViewModel : INotifyPropertyChanged
    {
        public string Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string id;

        public event PropertyChangedEventHandler PropertyChanged;

    }
}