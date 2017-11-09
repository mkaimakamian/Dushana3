<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Orders.aspx.vb" Inherits="Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Carrito de Compras</h1>
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Agregar" />
    <br />
    <br />
    <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Comprar" />
</asp:Content>

