<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contacto.aspx.cs" Inherits="contacto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/style.css">
<script src="js/bootstrap.min.js"></script>
<script src="js/funciones.js"></script>
<link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet"> 
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
<meta charset="UTF-8"> 
<meta name="Title" content="BrainBow by Go4IT Modelos de Inteligencia Artificial AI"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta name="description" content="Nuestro modelo de valuación automática de Go4IT (AVM) recomienda valores inmobiliarios mediante la incorporación de modelos de inteligencia artificial." />
<meta name="keywords" content="Brainbow,Go4IT,AI,Inteligencia Artificial,AVM,Valuacion Automatica,Valuacion,IA,Inteligencia,Valores de Mercado,Hipotecario,Casas,Departamentos,Obtener Valor Inmueble,Conacyt,PEI,Innovacion" />
<meta name="author" content="Go4IT" />
<meta name="robots" content="index,follow,all"/>
<meta name="distribution" content="Global"/>
<meta name="Language" content="Spanish"/>
<title>BrainBow by Go4IT Modelos de Inteligencia Artificial AI</title>

<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-63016708-3"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-63016708-3');
</script>
<link rel="shortcut icon" type="png" href="images/Brainbow.png">
<!-- Social -->
<link rel="stylesheet" href="css/socialNetworks.css" />

</head>
<body>
    <div class="container">
	  <div class="row">
		<div class="col-sm-12">
			<nav class="navbar navbar-expand-lg navbar-go4it">
			  <a class="navbar-brand" href="#"><img src="images/Brainbow_logo.svg" alt="logo Brainbow" width="150vh"/></a>
			  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"></span>
			  </button>
			
			  <div class="collapse navbar-collapse mr-auto" id="navbarSupportedContent">
				<ul class="navbar-nav ml-auto">
				  <li class="nav-item active">
					<a class="nav-link" href="index.html#ventajas" >Ventajas <span class="sr-only">(current)</span></a>
				  </li>
				  <li class="nav-item">
					<a class="nav-link" href="index.html#comoFunciona" >¿Cómo funciona?</a>
				  </li>
				  <li class="nav-item">
					<a class="nav-link" href="index.html#aplicaciones" >Aplicaciones</a>
				  </li>
				  <li class="nav-item">
					<a class="nav-link" href="#" >
                        <button class="btnContacto">Contacto</button>
                    </a>
				  </li>
                </ul>
			  </div>
			</nav>
		</div>
	</div>
  </div>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager2" />
            <telerik:RadSkinManager ID="RadSkinManager2" runat="server" />
            <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="btnEnviar">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="captcha1"></telerik:AjaxUpdatedControl>
                            <telerik:AjaxUpdatedControl ControlID="btnEnviar"></telerik:AjaxUpdatedControl>
                            <telerik:AjaxUpdatedControl ControlID="Lblmensaje" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <div class="container">
                <div class="row finSeccion">
                    <div class="col-lg-6 col-xl-6 col-md-12 col-sm-12 col-12" id="contacto">
                        <div class="row">
                            <div class=" col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <h2 class="tituloSeccion2">¡Hablemos!</h2>
                                <p class="textoContacto">Estamos felices de responder todas tus preguntas.</p>
                            </div>
                            <div class=" d-lg-none d-xl-none offset-md-4 col-md-4 offset-sm-2 col-sm-8 offset-2 col-8">
                                 <img src="images/contacto.svg" alt="Contacto" width="100%" class="img-responsive" />
                            </div>
                            <div class=" col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                                <div class="row">
                                    <input runat="server" placeholder="Nombre" class="formulario" id="txtName" />
                                </div><br/>
                                <div class="row">
                                    <input runat="server" placeholder="Email" class="formulario" id="txtEmail" />
                                </div><br/>
                                <div class="row">
                                    <input runat="server" placeholder="Teléfono" class="formulario" id="txtTelefono" />
                                </div><br/>
                                <div class="row">
                                    <textarea runat="server" placeholder="¿Cómo podemos ayudarte?" class="formulario" id="txtmessage"></textarea>
                                </div>
                                <br />
                                <telerik:RadCaptcha ID="captcha1" runat="server" CaptchaTextBoxLabel=""
                                    ValidationGroup="Group" TextBoxDecoration-ForeColor="Black">
                                    <CaptchaImage ImageCssClass="imageClass" ImageAlternativeText="Go4IT" />
                                </telerik:RadCaptcha>
                                <telerik:RadLabel runat="server" ID="Lblmensaje" Text="Ingresa el texto de la imágen" EnableEmbeddedSkins="false"></telerik:RadLabel>
                                <br />
                                <div class="row">
                                    <div class="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-4">
                                        <asp:Button runat="server" ID="btnEnviar" ValidationGroup="Group" CssClass="btn-submit botonContacto" Text="CONTACTAR" OnClick="btnEnviar_Click" Width="100%" />
                                    </div>
                                    <div class="col-6 col-sm-6 col-md-8 col-lg-8 col-xl-8">
                                    </div>
                                </div>
                            </div>
                        </div>
<%--                        <form id="main-contact-form" name="contact-form">
                            
                        </form>--%>
                    </div>
                    <div class="d-none d-sm-none d-md-none d-lg-block col-lg-6 col-xl-6">
                        <img src="images/contacto.svg" alt="Contacto" width="100%" class="img-responsive" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
