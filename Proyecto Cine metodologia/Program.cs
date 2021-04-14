
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proyecto_Cine_metodologia
{
    public class Program
    {
        public static void Main(string[] args)
        {
          //  CloudStorageAccount cuentaAlmacenamiento = CloudStorageAccount.Parse(
            //    CloudConfigurationManager.GetSetting("StorageConnectionString"));

            CloudStorageAccount cuentaAlmacenamiento = CloudStorageAccount.Parse("the-value-of-your-storage-connectionstring");
            

            CloudQueueClient ClienteCola = cuentaAlmacenamiento.CreateCloudQueueClient();

            CloudQueue cola = ClienteCola.GetQueueReference("m1-cola-1");

            cola.CreateIfNotExistsAsync();

            CloudQueueMessage mensaje = new CloudQueueMessage("su asiento es el #####");

            cola.AddMessageAsync(mensaje);
            Console.ReadLine();
            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
