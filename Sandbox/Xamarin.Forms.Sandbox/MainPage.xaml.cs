using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace App144
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ViewModel();
        }

        [AddINotifyPropertyChangedInterface]
        class ViewModel
        {
            public ObservableCollection<Model> ItemsSource { get; set; }

            public ViewModel()
            {
                var itemsSource = new ObservableCollection<Model>();

                itemsSource.Add(new Model { Url = "https://www.gstatic.com/webp/gallery/1.jpg", Text = "1.jpg" });
                itemsSource.Add(new Model { Url = "https://www.gstatic.com/webp/gallery/2.jpg", Text = "2.jpg" });
                itemsSource.Add(new Model { Url = "https://www.gstatic.com/webp/gallery/4.jpg", Text = "4.jpg"});
                itemsSource.Add(new Model { Url = "https://www.gstatic.com/webp/gallery/3.jpg", Text = "3.jpg" });
                itemsSource.Add(new Model { Url = "https://www.gstatic.com/webp/gallery/5.jpg", Text = "5.jpg" });

                ItemsSource = itemsSource;
            }
        }

        [AddINotifyPropertyChangedInterface]
        class Model
        {
            public string Url { get; set; }

            public string Text { get; set; }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var label = sender as Label;

            var model = (Model)label.BindingContext;

            model.Text = DateTime.UtcNow.Millisecond.ToString();
        }
    }
}
