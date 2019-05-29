using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace infokiosk.Classes
{
    public class Shared_Class
    {
        public bool ConnectionAvailable(string strServer)   //проверка доступа к узлу
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(strServer);
                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // Доступ к сайту в сети Интернет имеется 
                    rspFP.Close();
                    return true;
                }
                else
                {
                    // Сервер вернул отрицательный ответ, доступ к сайту отсутствует
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                // Ошибка, доступ к сайту отсутствует
                return false;
            }
        }

        public string ErrorMessage = "Невозможно получить данные. Отсутствует доступ к сети Интернет.";
        private readonly string f_name_txt;

        public async Task<HtmlDocument> HtmlLoad(string weblink)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.OptionReadEncoding = false;
            var request = (HttpWebRequest)WebRequest.Create(weblink);
            request.Method = "GET";
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    htmlDoc.Load(stream, Encoding.UTF8);
                }
            }
            return htmlDoc;
        }

        //TODO WTS: Add string with download address 
        public readonly string download_link_file = "";

        //TODO WTS: void 2 Task<StorageFile>
        public async void DownloadFile (string weblink)
        {
            try
            {
                Uri uri = new Uri(weblink);
                StorageFolder folder = KnownFolders.PicturesLibrary;
                //TODO WTS: private string f_name_txt 2 function that determines name of downloaded file
                StorageFile file = await folder.CreateFileAsync(f_name_txt, CreationCollisionOption.ReplaceExisting);
                BackgroundDownloader downloader = new BackgroundDownloader();
                DownloadOperation download = downloader.CreateDownload(uri, file);
                //TODO WTS: Need to add info about downloading progress or add an Awaiter
                await download.StartAsync();
            }
            catch
            {

            }
            finally
            {

            }
        }

    }
}
