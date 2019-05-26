using infokiosk.Classes;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;

namespace infokiosk.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            Update();
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

        /*private async void Software_Updater()
        {
            string version_xpath = "/html/body/div[2]/div[7]/div[1]/div[2]";
            string updatelink_xpath = "/html/body/div[1]/div[2]/a[3]";
            Shared_Class shared_Class = new Shared_Class();
            if (shared_Class.ConnectionAvailable("https://floorup4.ru") == true)
            {
                try
                {
                    HtmlDocument html = await shared_Class.HtmlLoad("https://floorup4.ru/update_kiosk");
                    Parsing_Class parsing_Class = new Parsing_Class();
                    string software_version_website = parsing_Class.TextParser(html, version_xpath);
                    string update_link = parsing_Class.Href_link(html, updatelink_xpath);
                    if (software_version_website != shared_Class.GetAppVersion())
                    {
                        Update_Class update_Class = new Update_Class();
                        update_Class.Update_Package(update_link);
                    }
                }
                catch
                {
                    //CoreApplication.Exit();
                }
                finally
                {
 
                }
            }
        }*/

        private async void Update()
        {
            Update_Class update_Class = new Update_Class();
            bool up = await update_Class.Search();
            if (up == true)
            {
                ContentDialog dialog = new ContentDialog();
                {
                    dialog.Title = "Обнаружено обновление. Установить?";
                    dialog.PrimaryButtonText = "Да";
                    dialog.SecondaryButtonText = "Нет";
                }

                ContentDialogResult result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    update_Class.Update_Package();
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
