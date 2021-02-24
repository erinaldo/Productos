<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteTiempoLaboral.aspx.cs"
    Inherits="RegistroTiemposLaborales.ReporteTiempoLaboral" StylesheetTheme="TemaRoute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tiempo Laboral</title>
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
                            </h2>
                            <cc1:CalendarExtender ID="CalendarExtenderFecha2" TargetControlID="TextBoxFecha2"
                                runat="server" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </center>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <center>
                                    <asp:Button ID="ButtonGenerar" runat="server" Text="Generar" OnClick="Button1_Click" />
                                </center>
                                <br />
                                <br />
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                        CellSpacing="2" AutoGenerateColumns="false" BorderColor=" #6a8ccb" OnRowCreated="GridView1_RowCreated">
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="link" DataTextField="Usuario" HeaderText="Usuario" />
                                            <asp:BoundField DataField="Horas" HeaderText="Horas" />
                                            <asp:BoundField DataField="HorasRegistradas" HeaderText="Horas Registradas" />
                                            <asp:BoundField DataField="Coherencia" HeaderText="Porcentaje de Coherencia" />
                                            <asp:BoundField DataField="RealVsEstimado" HeaderText="Procentaje de Real vs Estimado" />
                                        </Columns>
                                        <RowStyle CssClass="FilaGrid" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="CabezeraGrid" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle CssClass="FilaGrid2" />
                                    </asp:GridView>
                                </center>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </center>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
