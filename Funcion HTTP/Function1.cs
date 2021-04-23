using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Funcion_HTTP
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, 
            [Queue ("compras")] IAsyncCollector<pedidoCompra> colaCompras,
            ILogger log)
        
        {
            log.LogInformation("Se ha recibido un pedido de compra");

            

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var orden = JsonConvert.DeserializeObject<pedidoCompra>(requestBody);
            await colaCompras.AddAsync(orden);
            log.LogInformation($"Pedido {orden.OrderID} recibido, precio seria {orden.Precio} " +
                $"para la pelicula {orden.PeliculaID}");

            string responseMessage = 
                 "Gracias por su compra"
                ;

            return new OkObjectResult(responseMessage);
        }
    }

    public class pedidoCompra
    {
        public string OrderID { get; set; }

        public string Precio { get; set; }

        public string PeliculaID { get; set; }
    }
}

