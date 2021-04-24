using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PruebaCorreo
{
    class Correo
    {
        public string sendMail(string to, string asunto, string body)
        {
            string msge = "";
            string from = "pmcine@outlook.com";
            string displayName = "Cine de Proyecto";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.office365.com", 587);
                client.Credentials = new NetworkCredential(from, " ProyectoMCine1");
                client.EnableSsl = true;
                client.Send(mail);

            }
            catch (Exception ex)
            { msge = ex.Message; }
            return msge;
        }
    }
}