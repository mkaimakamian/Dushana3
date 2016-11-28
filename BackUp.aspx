<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BackUp.aspx.vb" Inherits="BackUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Copia de Seguridad</h1>
    <p>
        <asp:Button ID="btnBackup" runat="server" Text="Backup" />
    </p>
</asp:Content>

