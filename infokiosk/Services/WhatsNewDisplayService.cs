using System;
using System.Threading.Tasks;

using infokiosk.Views;

using Microsoft.Toolkit.Uwp.Helpers;

namespace infokiosk.Services
{
    public static class WhatsNewDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsAppUpdated && !shown)
            {
                shown = true;
                var dialog = new WhatsNewDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
