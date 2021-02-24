<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GraficaTiempoProyecto.aspx.cs"
    Inherits="RegistroTiemposLaborales.GraficaTiempoProyecto" StylesheetTheme="TemaRoute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script language="Javascript" type="text/javascript" src="Graficas/FusionCharts.js"></script>

    <title>Grafica de Tiempos por Proyecto</title>
    <style type="text/css">
        html, body, form
        {
            margin: 0px;
            height: 100%;
        }
    </style>
</head>
<body style="background-image: url('images/amesol_duxtar.jpg'); background-attachment: fixed;
    background-repeat: no-repeat; background-position: bottom right">
    <form id="form1" runat="server">
    <table style="height: 100%; width: 100%">
        <tr>
            <td style="vertical-align: top">
                <div>
                    <asp:ScriptManager ID="Scriptmanager1" runat="server">
                    </asp:ScriptManager>
                    <center>
                        <center>
                            <img alt="" src="images/logo_amesol_horizontal.jpg" />
                            <br />
                            <a href="Default.aspx">
                                <img style="border: 0" alt="" src="images/home.png" /></a>
                            <br />
                        </center>
                        <br />
                        <center style="display: inline">
                            <h2>
                                <asp:Label ID="LabelFecha1" runat="server" Text="Fecha Inicial"></asp:Label>
                                <asp:TextBox ID="TextBoxFecha1" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderFecha1" TargetControlID="TextBoxFecha1"
                                    runat="server" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                &nbsp
                                <asp:Label ID="LabelFecha2" runat="server" Text="Fecha Final"></asp:Label>
                                <asp:TextBox ID="TextBoxFecha2" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderFecha2" TargetControlID="TextBoxFecha2"
                                    runat="server" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </h2>
                            <br />
                            <asp:Button ID="ButtonGenerar" runat="server" Text="Generar" OnClick="ButtonGenerar_Click" />
                        </center>
                        <br />
                        <br />
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <br />
                                <br />
                                <center>
                                    <%=generarGraficaBarras()%>
                                </center>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </center>
            </td>
        </tr>
        
    </table>
    </form>
</body>
</html>
