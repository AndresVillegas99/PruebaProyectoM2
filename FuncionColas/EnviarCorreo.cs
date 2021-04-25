using System;
using System.Collections.Generic;
using System.Text;
using PruebaCorreo;
using System.Linq;


using System.Threading.Tasks;
namespace FuncionColas
{
    public class EnviarCorreo
    {
        public EnviarCorreo()
        {


        }

        public void DatosCorreo(string factura, string cliente, string fecha,
 string pelicula, string sala, string asiento, string total, string email)
        {
            Correo correo = new Correo();

            string body = @"<p>Información de su compra</p>
            <table border=""1"">
<tr>
<td>Factura</td>
<td>Cliente</td>
<td>Fecha</td>
<td>Pelicula</td>
<td>Sala</td>
<td>Asiento</td>
<td>Total</td>
</tr>";
            body +=
            "<tr>"
            + "< td >" + factura + "</ td >"
            + "< td >" + cliente + "</ td >"
            + "< td >" + fecha + "</ td >"
            + "< td >" + pelicula + "</ td >"
            + "< td >" + sala + "</ td >"
            + "< td >" + asiento + "</ td >"
            + "< td >" + total + "</ td >" +
            "</tr>";
            body += "</tbody>" +
            "</table>" +
            "<p>Gracias por escogernos.</p>";

            correo.sendMail(email, "Compra de tiquete", body);
        }
    }
}
