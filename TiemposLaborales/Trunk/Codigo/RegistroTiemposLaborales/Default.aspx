<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegistroTiemposLaborales._Default"
    StylesheetTheme="TemaRoute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro De Tiempos</title>
    <style type="text/css">
        .style1
        {
            width: 140px;
        }
        .style3
        {
            width: 280px;
        }
        .style4
        {
            width: 60px;
        }
        html, body, form
        {
            margin: 0px;
            height: 100%;
        }
    </style>

    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>

    <script src="js/jquery.bubbleup.js" type="text/javascript"></script>

</head>
<body id="Page" style="background-image: url('images/amesol_duxtar.jpg'); background-attachment: fixed;
    background-repeat: no-repeat; background-position: bottom right">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(mostrarProyecto);
        function mostrarProyecto() {
            if (eval($("#hidOcultar").val().toLowerCase())) {
                $('[id^="ocultar"]').hide();
            }
            else {
                $('[id^="ocultar"]').show();
            }
            $("#comboAreas").attr('disabled', 'disabled');
            $("#ocultarlinkEditarArea").click(function() {
                $("#comboAreas").removeAttr('disabled');
            });
        }
        $(document).ready(function() {
            $("table#menu tr td img").bubbleup({ tooltip: true });
            
            mostrarProyecto();
        });
    </script>

    <table style="height: 100%">
        <tr>
            <td style="vertical-align: top; padding-left: 25px">
                <table style="width: 100%; color: #00004f">
                    <tr>
                        <td rowspan="2">
                            <img alt="" src="images/logo_amesol_horizontal.jpg" />
                        </td>
                        <td style="width: 100%; padding: 0px 0px 0px 20px">
                            <table>
                                <tr>
                                    <td>
                                        <h2>
                                            <b>
                                                <asp:Label ID="LabelUsuario" runat="server" Text="Usuario"></asp:Label>
                                            </b>
                                        </h2>
                                    </td>
                                    <td>
                                        &nbsp<asp:LoginStatus ID="LoginStatus1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px 0px 0px 20px">
                            <asp:UpdatePanel ID="UpdateFechaJornada" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <b>
                                        <h3>
                                            <asp:Label ID="LabelFechaHora" runat="server" Text="FechaHora"></asp:Label></h3>
                                    </b>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <center>
                    <table id="menu" style="height: 120px;">
                        <tr>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkReporteTiempo" runat="server" ImageUrl="images/Report.png"
                                    Target="_self" ToolTip="Horas por persona">Horas por persona</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkGrafica" runat="server" ImageUrl="Images/BarChart2.png"
                                    Target="_self" ToolTip="Grafica por proyecto">Grafica por proyecto</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkReporteProyecto" runat="server" ImageUrl="images/ReportFavorites.png"
                                    Target="_self" ToolTip="Detalle de horas por proyecto">Detalle de horas por proyecto</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkReporteDetallePorPersona" runat="server" ImageUrl="images/FileDocuments.png"
                                    Target="_self" ToolTip="Detalle de movimientos por persona" NavigateUrl="ReporteDetalleSubs.aspx">Detalle de movimientos por persona</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkAdministrador" runat="server" ImageUrl="~/images/TableRow.png"
                                    Target="_self" ToolTip="Edita las horas ya guardadas" NavigateUrl="Administrador.aspx">Edición de Horas</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="LinkConfigurador" runat="server" ImageUrl="~/images/DataList.png"
                                    Target="_self" ToolTip="Configuraciones generales" NavigateUrl="Configuracion.aspx">Configuraciones Generales</asp:HyperLink>
                            </td>
                            <td>
                                <asp:HyperLink CssClass="Menu" ID="HyperLink1" runat="server" ImageUrl="~/images/Group.png"
                                    Target="_self" ToolTip="Recursos Humanos" NavigateUrl="Costos.aspx">Recursos Humanos</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </center>
                <div>
                    <table style="border: thin solid #66CCFF">
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="lblTipoReg" runat="server" Text="Tipo de Registro:"></asp:Label>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelProyecto" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:RadioButtonList ID="RadioButtonProyecto" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="comboProyecto_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                        <asp:Label ID="LabelEntrada" Text="ENTRADA" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right">
                                <span id="ocultar1">Proyecto / No. Poliza:</span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelCliente" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="hidOcultar" runat="server" />
                                        <asp:DropDownList ID="comboCliente" runat="server">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <span id="ocultar2">Area: </span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelAreas" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="comboAreas" runat="server" OnSelectedIndexChanged="comboAreas_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                        <a id="ocultarlinkEditarArea" href="#">Editar Area</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right">
                                <span id="ocultar3">Actividad:</span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelActividades" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="comboActividades" runat="server">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                Descripcion:
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelDescripcion" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtDescripcion" Width="275px" runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: right">
                                <span id="ocultar5">Horas:</span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelHoras" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:CustomValidator ID="valHoras" runat="server" ControlToValidate="txtHoras" OnServerValidate="valHoras_ServerValidate"
                                            ValidateEmptyText="True" ValidationGroup="insertar">*</asp:CustomValidator>
                                        <asp:TextBox ID="txtHoras" runat="server" Width="41px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanelBoton" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarHoras" runat="server" Text="Agregar" OnClick="btAgregarHoras_Click"
                                            ValidationGroup="insertar"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:UpdatePanel ID="UpdatePanelValidator" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="insertar" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanelDataList" runat="server" UpdateMode="Conditional"
                        RenderMode="Inline">
                        <ContentTemplate>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                OnItemCreated="Repeater1_ItemCreated">
                                <HeaderTemplate>
                                    <table id="sample">
                                        <tr style="background-image: url('images/fondoo.gif'); background-repeat: repeat-x;
                                            color: White">
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Fecha Hora
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Tipo
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Proyecto
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Area
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Actividad
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Descripcion
                                            </th>
                                            <th style="border-color: #FFFFFF; border-style: solid; border-width: 1px">
                                                Horas
                                            </th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="FILA" runat="server">
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="LabelFechaHora" Text='<%# ((DateTime)Eval("FechaHoraInicial")).ToString("f") %>'
                                                runat="server" Visible='<%# Eval("P") %>'></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px;">
                                            <asp:Label ID="lblProyecto" Text='<%# (Eval("Proyecto")).ToString() %>' runat="server"></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="lblCliente" Text='<%# (Eval("Cliente")).ToString() %>' runat="server"></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="lblArea" Text='<%# (Eval("Area")).ToString() %>' runat="server"></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="lblActividad" Text='<%# (Eval("Actividad")).ToString() %>' runat="server"></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="lblDescripcion" Text='<%# (Eval("Descripcion")).ToString() %>' runat="server"></asp:Label>
                                        </td>
                                        <td style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:Label ID="lblHoras" Text='<%# (Eval("Horas")).ToString() %>' Visible='<%# !(bool)Eval("P") %>'
                                                runat="server"></asp:Label>
                                        </td>
                                        <td style="background-image: none; background-color: White">
                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/button_cancel.png"
                                                Visible='<%#(Container.ItemIndex == 0 && !(bool)Eval("P"))%> ' CommandName="Eliminar"
                                                CommandArgument='<%# ((DateTime)Eval("FechaHoraInicial")).ToString("yyyy-MM-ddTHH:mm:ss.fffffff") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table></FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none;">
                                Quieres iniciar la jornada de Trabajo
                                <br />
                                <br />
                                <asp:Button ID="btnOk" runat="server" Text="SI" />
                                <asp:Button ID="btnClose" runat="server" Text="NO" />
                            </asp:Panel>
                            <asp:Button ID="Button1" Style="visibility: hidden" runat="server" Text="Close Me"
                                OnClick="btnOk_Click" />
                            <asp:Button ID="Button2" Style="visibility: hidden" runat="server" Text="Close Me" />
                            <cc1:ModalPopupExtender OnOkScript="clickBoton()" BackgroundCssClass="modalBackground"
                                DropShadow="true" OkControlID="btnOk" CancelControlID="btnClose" runat="server"
                                PopupControlID="Panel1" ID="ModalPopupExtender1" TargetControlID="Button2">
                            </cc1:ModalPopupExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
