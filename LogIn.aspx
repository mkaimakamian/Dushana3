<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="Estilo/MyStyle.css" rel="stylesheet" />--%>
    <link href="Estilo/Login.css" rel="stylesheet" />
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/font-awesome/3.2.1/css/font-awesome.min.css" />
    <title></title>
</head>
<body>
    <div class="container">

        <div class="row" id="pwd-container">
            <div class="col-md-4"></div>

            <div class="col-md-4">
                <section class="login-form">
                    <form id="form1" runat="server" role="login" class="login-form">

                        <img src="https://i.imgur.com/5yad3KM.jpg" class="img-responsive" alt="" />

                        <asp:TextBox ID="TxtUser" runat="server" class="form-control input-lg">Usuario</asp:TextBox>

                        <asp:TextBox ID="TxtPassword" runat="server" class="form-control input-lg">Contraseña</asp:TextBox>

                        <asp:Button ID="BtnAccess" runat="server" class="btn btn-lg btn-primary btn-block" Text="Login" />
                        <div class="pwstrength_viewport_progress"></div>

                        <div><a href="#">Crear Cuenta</a> or <a href="#">Cambiar Password</a></div>

                    </form>
                </section>
                <div class="col-md-4"></div>


            </div>


        </div>
</body>
</html>
