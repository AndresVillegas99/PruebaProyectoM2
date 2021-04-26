using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using FuncionColas;
using System;

namespace Funcion_HTTP
{
    public class FuncionHTTP
    {

        [FunctionName("FuncionHTTPMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Compras/PaginaGracias")] HttpRequest req,
            [Queue("compras")] ICollector<pedidoCompra> colaCompras,
            ILogger log)
        {

            try
            {
                log.LogInformation("Se ha recibido un pedido de compra");
                //EnviarCorreo correo = new EnviarCorreo();
                //correo.Enviar("12", "prueba", "prueba", "prueba", "prueba", "prueba", "prueba", "villegasa25@gmail.com");


                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var orden = JsonConvert.DeserializeObject<pedidoCompra>(requestBody);
                 colaCompras.Add(orden);
                log.LogInformation($"Pedido {orden.OrderID} recibido, precio seria {orden.Precio} " +
                    $"para la pelicula {orden.PeliculaID} en la sala {orden.Sala} en el asiento {orden.Asiento}." +
                    $" Se enviara al correo {orden.Email}");

                string responseMessage =
                     "Gracias por su compra"
                    ;

                return new OkObjectResult(responseMessage);
            }
            catch (Exception)
            {
                object a = 1;
                throw;
            }

        
    }
    }

    public class pedidoCompra
    {
        public string OrderID { get; set; }

        public string Precio { get; set; }

        public string PeliculaID { get; set; }
        public string Email { get; set; }



        public string Sala { get; set; }

        public string Asiento { get; set; }

    }

    /*
     * -Uri  http://localhost:7071/api/FuncionHTTPMessage `
-Body '{ "OrderID" : "1", "Precio" : "23", "PeliculaID" : "32" }' `
 -Headers @{ "Content-Type" = "application/json"}
    */
}

