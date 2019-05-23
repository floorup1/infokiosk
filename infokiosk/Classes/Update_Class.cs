using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Management.Deployment;

namespace infokiosk.Classes
{
    public class Update_Class
    {
        public async void Update_Package(string link)
        {
            PackageManager packageManager = new PackageManager();
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
    }
}
