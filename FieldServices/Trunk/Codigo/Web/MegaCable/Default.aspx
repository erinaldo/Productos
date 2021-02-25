<%@ Page Title="#NombreAplicacion" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Actividad"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
            <img alt="" src="img/logo-megacable2.gif" style="position:relative; left:220px; top:200px;" />
    </div>
</asp:Content>
