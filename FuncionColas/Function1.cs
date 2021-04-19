using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FuncionColas
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "DefaultEndpointsProtocol=https;AccountName=serviciocinecola;AccountKey=hOX66/XoxGr9EhBeJwc6fcNZSU/m9pgziyl8nDDgAfuRKozdipQDjKMJh5JpKNAYhwwbaUMIGD2GAXS3gqC0KA==;EndpointSuffix=core.windows.net")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
