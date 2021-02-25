<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccesoSistema.aspx.cs" Inherits="AccesoSistema" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>#NombreAplicacion</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <!--<script src="js/gradientz.js" type="text/javascript"></script>-->
</head>
<body>
    <form id="form1" runat="server">
    <div class="page">
        <div class="header">
            <div id="barra" class="title">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server" Text="#NombreAplicacion"></asp:Label>
                </h1>
            </div>
        </div>
        <center>
            <img alt="" src="img/logo-megacable2.gif" />
            <h2 style="padding: 0px 50px 0px 50px;">
                <asp:Label ID="lblSubTituloTabla" runat="server" Text="#Login"></asp:Label>
            </h2>
        </center>
        <center>
            <table style="margin: 20px 0px 30px 30px; text-align: left;">
                <tr>
                    <td>
                        <asp:Label ID="lblUsuario" runat="server" Text="#Usuario"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="textEntry" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="#MI0001,#Usuario"
                            ForeColor="Red" ControlToValidate="txtUsuario" ValidationGroup="ValidarDatosProporcionados">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblContrasenia" runat="server" Text="#Contrasenia"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password" CssClass="passwordEntry"
                            TabIndex="2"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvContrasenia" runat="server" ErrorMessage="#MI0001,#Contrasenia"
                            ForeColor="Red" ControlToValidate="txtContrasenia" ValidationGroup="ValidarDatosProporcionados">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <center>
                            <asp:Button ID="btnAceptar" runat="server" Text="#Aceptar" ValidationGroup="ValidarDatosProporcionados"
                                OnClick="btnAceptar_Click" CssClass="submitButton" TabIndex="3" />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span class="failureNotification">
                            <asp:Literal ID="fldError" runat="server"></asp:Literal></span>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidarDatosProporcionados"
                            CssClass="failureNotification" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
