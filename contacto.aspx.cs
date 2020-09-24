using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contacto : System.Web.UI.Page
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
        if (this.txtName.Value == "")
        {
            this.Lblmensaje.Text = "Es necesario ingresar un nombre.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.txtEmail.Value == "" || !validateEmail(this.txtEmail.Value))
        {
            this.Lblmensaje.Text = "Email vacio o en formato incorrecto.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.txtTelefono.Value == "")
        {
            this.Lblmensaje.Text = "Es necesario ingresar un teléfono.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.txtTelefono.Value.Length != 10)
        {
            this.Lblmensaje.Text = "Ingrese un teléfono válido.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (this.txtmessage.Value == "")
        {
            this.Lblmensaje.Text = "Es necesario ingresar un comentario.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
        }
        else if (!Page.IsValid)
        {
            this.Lblmensaje.Text = "Captcha inválido, intenta de nuevo.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Red;
            this.captcha1.DataBind();
        }
        else
        {
            this.captcha1.Visible = false;
            this.btnEnviar.Visible = false;
            sendMail(this.txtName.Value, this.txtEmail.Value, this.txtmessage.Value);
            this.Lblmensaje.Text = "Tu mensaje ha sido enviado.";
            this.Lblmensaje.ForeColor = System.Drawing.Color.Green;
            this.Lblmensaje.Visible = true;
        }



    }

    public static void sendMail(string nombre, string email, string mensaje)
    {
        try
        {
            var fromAddress = new MailAddress(ConfigurationManager.AppSettings["userEmail"].ToString(), "iGo4IT");
            var toAddress = new MailAddress(ConfigurationManager.AppSettings["toEmail"].ToString());
            string fromPassword = ConfigurationManager.AppSettings["passwordEmail"].ToString();
            string subject = "Correo desde plataforma iGo4IT";
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