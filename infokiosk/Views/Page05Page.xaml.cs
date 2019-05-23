using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using infokiosk.Core.Models;
using infokiosk.Core.Services;

using Windows.UI.Xaml.Controls;

namespace infokiosk.Views
{
    public sealed partial class Page05Page : Page, INotifyPropertyChanged
    {
        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on DataGridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public Page05Page()
        {
            InitializeComponent();
        }

        public ObservableCollection<ServOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return ServDataService.GetGridServData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
