using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using 

namespace FuncionColas
{
    public  class FuncionColas
    {
        [FunctionName("FuncionColaMensajes")]
        public  void Run([QueueTrigger("Compras", Connection = "DefaultEndpointsProtocol=https;AccountName=serviciocinecola;AccountKey=hOX66/XoxGr9EhBeJwc6fcNZSU/m9pgziyl8nDDgAfuRKozdipQDjKMJh5JpKNAYhwwbaUMIGD2GAXS3gqC0KA==;EndpointSuffix=core.windows.net")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            EnviarCorreo.Enviar();
        }
    }
}
