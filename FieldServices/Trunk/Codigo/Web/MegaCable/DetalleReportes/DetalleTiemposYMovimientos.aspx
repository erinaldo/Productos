<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetalleTiemposYMovimientos.aspx.cs"
    Inherits="DetalleReportes_DetalleTiemposYMovimientos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: White; background-image: none;">
    <form id="form1" runat="server">
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Detalle"></asp:Label>
            </h1>
        </div>
    </div>
    <img alt="" src="../img/logo-megacable2.gif" />
    <br />
    <asp:Panel ID="pnlAtendido" runat="server">
        <div style="padding:20px">
            <p>
                <asp:Label ID="lblSuscriptor" runat="server" Text="#Suscriptor"></asp:Label>
                : <b>
                    <asp:Label ID="fldSuscriptor" runat="server"></asp:Label>
                    |
                    <asp:Label ID="fldNombreSuscriptor" runat="server"></asp:Label></b>
            </p>
            <p>
                <asp:Label ID="lblInicio" runat="server" Text="#Inicio"></asp:Label>
                : <b>
                    <asp:Label ID="fldInicio" runat="server"></asp:Label></b>
            </p>
            <p>
                <asp:Label ID="lblFin" runat="server" Text="#Fin"></asp:Label>
                : <b>
                    <asp:Label ID="fldFin" runat="server"></asp:Label></b>
            </p>
        </div>
        <asp:Panel ID="pnlDetalle" runat="server">
        </asp:Panel>
    </asp:Panel>
    </form>
    <br />
    <br />
    <center>
        <input type="button" onclick="javascript:print()" value='<%=UtilMensaje.ObtenerMensaje("#Imprimir")%>' />
    </center>
</body>
</html>
