<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ViewerLog.aspx.vb" Inherits="ViewerLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Bitacora</h1>
    <p>Filtros: </p>
    <p>&nbsp;<asp:DropDownList ID="CmbLevel" runat="server" Visible="False">
            <asp:ListItem Value="4">Info</asp:ListItem>
            <asp:ListItem Value="3">Critico</asp:ListItem>
            <asp:ListItem Value="2">Aviso</asp:ListItem>
            <asp:ListItem Value="1">Debug</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp; </p>
    <p>Desde<asp:Calendar ID="SinceCalendar" runat="server"></asp:Calendar>
    </p>
    <p>Hasta<asp:Calendar ID="UntilCalendar" runat="server"></asp:Calendar>
    </p>
    <p>
        <asp:Button ID="BtnAccept" runat="server" Text="Listar" Visible="False" />
    </p>
    <p>
        <asp:GridView ID="LogGridView" runat="server">
        </asp:GridView>
    </p>
</asp:Content>

