<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ClientRegistration.aspx.vb" Inherits="ClientRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Registrarse</h1>
    <p>Para acceder al sistema deberá iniciar sesión ingresando sus credenciales:</p>
    <p>Nombre de usuario:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtUser" runat="server"></asp:TextBox>
    </p>
    <p>Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="BtnAccess" runat="server" Text="Acceder" />
    </p>
</asp:Content>

