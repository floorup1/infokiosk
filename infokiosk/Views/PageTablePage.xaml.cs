using HtmlAgilityPack;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using infokiosk.Classes;
using Windows.UI.Xaml.Controls;

namespace infokiosk.Views
{
    public sealed partial class PageTablePage : Page, INotifyPropertyChanged
    {
        public PageTablePage()
        {
            InitializeComponent();
            TableParser();
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

        private async void TableParser()
        {
            Parsing_Class PC = new Parsing_Class();
            Shared_Class SC = new Shared_Class();
            if (SC.ConnectionAvailable("http://mfc.ulgov.ru") == true)
            {
                HtmlDocument HD = await SC.HtmlLoad("http://mfc.ulgov.ru/index1.php?t=zagrujennost");
                TZavKol.Text = PC.TextParser(HD, 3, 2);
                TZavTime.Text = PC.TextParser(HD, 3, 3);
                TZasKol.Text = PC.TextParser(HD, 4, 2);
                TZasTime.Text = PC.TextParser(HD, 4, 3);
                TLenKol.Text = PC.TextParser(HD, 5, 2);
                TLenTime.Text = PC.TextParser(HD, 5, 3);
                TZheKol.Text = PC.TextParser(HD, 6, 2);
                TZheTime.Text = PC.TextParser(HD, 6, 3);
            }
            else
            {
                TZavKol.Text = SC.ErrorMessage;
                TZavTime.Text = SC.ErrorMessage;
                TZasKol.Text = SC.ErrorMessage;
                TZasTime.Text = SC.ErrorMessage;
                TLenKol.Text = SC.ErrorMessage;
                TLenTime.Text = SC.ErrorMessage;
                TZheKol.Text = SC.ErrorMessage;
                TZheTime.Text = SC.ErrorMessage;
            }
        }
    }
}
