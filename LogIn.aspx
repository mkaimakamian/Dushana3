<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LogIn.aspx.vb" Inherits="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Por favor, ingrese su nombre de usuario y contraseña.<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtUser" runat="server">Admin</asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtPassword" runat="server">Admin</asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtnAccess" runat="server" Text="Acceder" />
    
    </div>
    </form>
</body>
</html>
