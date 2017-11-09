<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MyOrders.aspx.vb" Inherits="MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Mis Compras</h1>
    <p>Fecha:
        <asp:DropDownList ID="dropFechas" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p><%=sellTable%></p>
</asp:Content>

