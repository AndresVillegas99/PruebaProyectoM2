using System;
using System.Collections.Generic;
using System.Text;

namespace FuncionColas
{
    class EnviarCorreo
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
            </tr>
            <tr>
            <td>00102</td>
            <td>Yoel</td>
            <td>12-12-2021</td>
            <td>Prueba</td>
                <td>2</td>
                <td>F2</td>
                <td>2.000</td>
            </tr>
            </tbody>
            </table>
            <p>Gracias por escogernos.</p>";
        correo.sendMail("yoel.urena@ulatina.net", "Compra de tiquete", body);
    }
}
