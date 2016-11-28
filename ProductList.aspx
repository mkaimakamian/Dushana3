<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProductList.aspx.vb" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Lista de Productos</h1>
    <p>
        <asp:GridView ID="ProductGridView" runat="server">
        </asp:GridView>
    </p>
</asp:Content>

