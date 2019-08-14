using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPMaster : ContentPage
    {
        public ListView ListView;

        public MDPMaster()
        {
            InitializeComponent();

            BindingContext = new MDPMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPMasterMenuItem> MenuItems { get; set; }

            public MDPMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPMasterMenuItem>(new[]
                {
                    new MDPMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MDPMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MDPMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MDPMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MDPMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}