<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteDetalleSubs.aspx.cs"
    Inherits="RegistroTiemposLaborales.ReporteDetalleSubs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/TemaRoute/MyStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                                    <asp:Panel ID="pnlControlesVisibles" Visible="false" runat="server">
                                    <asp:Label ID="LabelFecha1" runat="server" Text="Fecha Inicial"></asp:Label>
                                    <asp:TextBox ID="txtFechaInicial" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtenderFecha1" TargetControlID="txtFechaInicial"
                                        runat="server" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    &nbsp
                                    <asp:Label ID="LabelFecha2" runat="server" Text="Fecha Final"></asp:Label>
                                    <asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtenderFecha2" TargetControlID="txtFechaFinal"
                                        runat="server" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    </asp:Panel>
                                </h2>
                            </center>
                            <br />
                            <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <center>
                                        <asp:Button ID="ButtonGenerar" runat="server" Text="Generar" Visible ="false" OnClick="Button1_Click" />
                                    </center>
                                    <br />
                                    <br />
                                    <center>
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                            CellSpacing="2" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" />
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                                <asp:BoundField DataField="Area" HeaderText="Area" />
                                                <asp:BoundField DataField="Actividad" HeaderText="Actividad" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                <asp:BoundField DataField="CantHoras" HeaderText="Cant. Horas" />
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
    </div>
    </form>
</body>
</html>
