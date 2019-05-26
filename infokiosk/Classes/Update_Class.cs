using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Management.Deployment;

namespace infokiosk.Classes
{
    public class Update_Class
    {
        //обновление
        public async void Update_Package()
        {
            PackageManager packageManager = new PackageManager();
            string link = await GetLink(link2);
            try
            {
                await packageManager.UpdatePackageAsync(new Uri(link), null, DeploymentOptions.ForceApplicationShutdown);
            }
            catch
            {

            }
            finally
            {

            }
        }

        //адрес проверки соединения
        private readonly string link1 = "https://floorup4.ru";

        //адрес репозитория 
        private readonly string link2 = "https://floorup4.ru/update_kiosk";

        //xpath-путь ссылки на обновление  
        private readonly string link_xpath = "/html/body/div[1]/div[2]/a[3]";

        //xpath-путь версии обновления
        private readonly string version_xpath = "/html/body/div[2]/div[7]/div[1]/div[2]";

        //Получение текущей версии пакета
        private string GetVersion()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;
            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
        }

        //Получение версии пакета обновления
        private async Task<string> GetVersion(string link)
        {
            Shared_Class shared_Class = new Shared_Class();
            Parsing_Class parsing_Class = new Parsing_Class();
            HtmlDocument html = await shared_Class.HtmlLoad(link);
            return parsing_Class.TextParser(html, version_xpath);
        }

        //Получение ссылки на обновление
        private async Task<string> GetLink(string link)
        {
            Shared_Class shared_Class = new Shared_Class();
            Parsing_Class parsing_Class = new Parsing_Class();
            HtmlDocument html = await shared_Class.HtmlLoad(link);
            return parsing_Class.Href_link(html, link_xpath);
        }

        // Проверка наличия обновления 
        public async Task<bool> Search()
        {
            Shared_Class shared_Class = new Shared_Class();
            if (shared_Class.ConnectionAvailable(link1) == true)
            {
                if (GetVersion() != (await GetVersion(link2)))
                {
                    return true; // Обнаружено обновление
                }
                else
                {
                    return false; // Обновление отсутствует
                }
            }
            else
            {
                return false; // Отсутствует подключение к сети
            }
        }

    }
}
