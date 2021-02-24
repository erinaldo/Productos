<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteProyectoUsuario.aspx.cs"
    Inherits="RegistroTiemposLaborales.ReporteProyectoUsuario" StylesheetTheme="TemaRoute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tiempo Proyecto Usuario</title>
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
                                    <asp:Repeater ID="Repeater1" runat="server" OnItemCreated="Repeater1_ItemCreated">
                                        <HeaderTemplate>
                                            <table id="sample">
                                                <tr style="background-image: url('images/fondoo.gif'); background-repeat: repeat-x;
                                                    color: White">
                                                    <th>
                                                        PROYECTO
                                                    </th>
                                                    <th>
                                                        USUARIO
                                                    </th>
                                                    <th>
                                                        DESCRIPCION
                                                    </th>
                                                    <th>
                                                        HORAS
                                                    </th>
                                                    <th>
                                                        HORAS POR PROYECTO
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr id="FILA" runat="server">
                                                <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px; empty-cells: hide">
                                                    <asp:Label ID="lblProyecto" Text='<%# (Eval("Proyecto")).ToString() %>' Visible='<%# mostrarProyecto( Repeater1.DataSource,Container.ItemIndex,Container) %>'
                                                        runat="server"></asp:Label>
                                                </td>
                                                <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:Label ID="lblUsuario" Text='<%# (Eval("Usuario")).ToString() %>' runat="server"></asp:Label>
                                                </td>
                                                <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:Label ID="lblDescripcion" Text='<%# (Eval("Descripcion")).ToString() %>' runat="server"></asp:Label>
                                                </td>
                                                <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                                    <asp:Label ID="lblHoras" Text='<%# (Eval("Horas")).ToString() %>' runat="server"></asp:Label>
                                                </td>
                                                <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px" visible='<%# mostrarTotal( Repeater1.DataSource,Container.ItemIndex) %>'>
                                                    <asp:Label ID="Label1" Text='<%# (Eval("TotalHoras")).ToString() %>' runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table></FooterTemplate>
                                    </asp:Repeater>
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
