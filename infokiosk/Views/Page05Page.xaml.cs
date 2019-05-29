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
        public Page05Page()
        {
            InitializeComponent();
        }

        public ObservableCollection<ServOrder> Source
        {
            get
            {
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
