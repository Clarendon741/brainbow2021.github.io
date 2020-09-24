using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Net;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public bool validateEmail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        Int64 n;
        if (this.name.Value == "")
        {
            this.Lblmensaje.Text = "Es necesario ingresar un nombre.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.email.Value == "" || !validateEmail(this.email.Value))
        {
            this.Lblmensaje.Text = "Email vacio o en formato incorrecto.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.message.Value == "")
        {
            this.Lblmensaje.Text = "Es necesario ingresar un comentario.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            this.btnEnviar.Visible = false;
            sendMail(this.name.Value, this.email.Value, this.message.Value);
            this.Lblmensaje.Text = "Tu mensaje ha sido enviado.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Green;
            this.Lblmensaje.Visible = true;
        }



    }

    public static void sendMail(string nombre, string email, string mensaje)
    {
        try
        {
            var fromAddress = new MailAddress(ConfigurationManager.AppSettings["userEmail"].ToString(), "iBrainBow");
            var toAddress = new MailAddress(ConfigurationManager.AppSettings["toEmail"].ToString());
            string fromPassword = ConfigurationManager.AppSettings["passwordEmail"].ToString();
            string subject = "Correo desde plataforma iBrainBow";
            string message = "Nombre: " + nombre + "\nEmail: " + email + "\nMensaje: " + mensaje;

            bool ssl;
            if (ConfigurationManager.AppSettings["sslEmail"].ToString() == "1")
                ssl = true;
            else
                ssl = false;

            NetworkCredential basicCredential;
            if (ConfigurationManager.AppSettings["dominioEmail"].ToString() == "")
                basicCredential = new NetworkCredential(fromAddress.Address, fromPassword);
            else if (ConfigurationManager.AppSettings["dominioEmail"].ToString() == "SIMPLE")
                basicCredential = new NetworkCredential(ConfigurationManager.AppSettings["userEmail"].ToString(), fromPassword);
            else
                basicCredential = new NetworkCredential(ConfigurationManager.AppSettings["userEmail"].ToString(), fromPassword, ConfigurationManager.AppSettings["dominioEmail"].ToString());

            var smtp = new SmtpClient
            {
                Host = ConfigurationManager.AppSettings["HostEmail"].ToString(),
                Port = Convert.ToInt32(ConfigurationManager.AppSettings["PortEmail"].ToString()),
                EnableSsl = ssl,
                Timeout = 100000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = basicCredential
            };
            using (var msj = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = false
            })
            {
                smtp.Send(msj);

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
