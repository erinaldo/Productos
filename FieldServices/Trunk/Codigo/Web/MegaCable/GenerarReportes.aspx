<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GenerarReportes.aspx.cs" Inherits="GeneracionReportes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            CargarCalendarios();
            var fecha = new Date();
            $("#<%=txtFecha1.ClientID%>").val(("00" + fecha.getDate().toString()).slice(-2) + "/" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "/" + fecha.getFullYear().toString());
            $("#<%=hidFecha1.ClientID%>").val(fecha.getFullYear().toString() + "-" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "-" + ("00" + fecha.getDate().toString()).slice(-2));

            var fecha = new Date();
            $("#<%=txtFecha2.ClientID%>").val(("00" + fecha.getDate().toString()).slice(-2) + "/" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "/" + fecha.getFullYear().toString());
            $("#<%=hidFecha2.ClientID%>").val(fecha.getFullYear().toString() + "-" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "-" + ("00" + fecha.getDate().toString()).slice(-2));
        });

        function MostrarReporte(pagina, fecha1, fecha2, tipo,id) {

            if (pagina == 1) {
                window.open("GenerarReporte.aspx?tipo=" + tipo + "&f1=" + fecha1 + "&f2=" + fecha2 + "&id=" + id, "_blank", "menubar=0,scrollbars=1,toolbar=0,resizable=1");
            }
            if (pagina == 2) {
                window.open("GenerarMapa.aspx?tipo=" + tipo + "&f1=" + fecha1 + "&f2=" + fecha2 + "&id=" + id, "_blank", "menubar=0,scrollbars=1,toolbar=0,resizable=1");
            }
            CargarCalendarios();
        }

        function CargarCalendarios() {
            var fecha1 = $("#<%=hidFecha1.ClientID%>").val().toString();
            var fecha2 = $("#<%=hidFecha2.ClientID%>").val().toString();
            

            $("#<%=txtFecha1.ClientID%>").datepicker();
            $("#<%=txtFecha1.ClientID%>").datepicker('option', {
                dateFormat: "dd/mm/yy",
                maxDate: 0,
                altField: "#<%=hidFecha1.ClientID%>",
                altFormat: "yy-mm-dd",
                changeMonth: true,
                changeYear: true,
                defaultDate: 0
            });
            $("#<%=txtFecha2.ClientID%>").datepicker();
            $("#<%=txtFecha2.ClientID%>").datepicker('option', {
                dateFormat: "dd/mm/yy",
                maxDate: 0,
                altField: "#<%=hidFecha2.ClientID%>",
                altFormat: "yy-mm-dd",
                changeMonth: true,
                changeYear: true,
                defaultDate: 0
            });


            var fecha1S = fecha1.split("-")
            $("#<%=hidFecha1.ClientID%>").val(fecha1);
            if (fecha1S.length == 3) 
                $("#<%=txtFecha1.ClientID%>").val(("00" + fecha1S[2]).slice(-2) + "/" + ("00" + fecha1S[1]).slice(-2) + "/" + fecha1S[0]);


            var fecha2S = fecha2.split("-")
            $("#<%=hidFecha2.ClientID%>").val(fecha2);
            if (fecha2S.length == 3)
                $("#<%=txtFecha2.ClientID%>").val(("00" + fecha2S[2]).slice(-2) + "/" + ("00" + fecha2S[1]).slice(-2) + "/" + fecha2S[0]);
            
        }
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Reportes"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido" style="padding: 20px;">
        <img alt="" src="img/logo-megacable2.gif" />
        <asp:UpdatePanel ID="updFiltros" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblReporte" runat="server" Text="#Reporte"></asp:Label>
                            <br />
                            <asp:ComboBox ID="cmbReportes" runat="server" Width="300px" AutoCompleteMode="Suggest"
                                DropDownStyle="DropDownList">
                            </asp:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label>
                            <asp:Label ID="lblFormato" runat="server" Text="(dd/mm/aaaa)"></asp:Label>
                            <br />
                            <asp:ComboBox ID="cmbFecha" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="cmbFecha_SelectedIndexChanged">
                            </asp:ComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFecha1" runat="server"></asp:TextBox>
                            <asp:HiddenField ID="hidFecha1" runat="server" />
                            <asp:TextBox ID="txtFecha2" runat="server" Visible="False"></asp:TextBox>
                            <asp:HiddenField ID="hidFecha2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                ErrorMessage="CustomValidator" ValidationGroup="Validacion" 
                                ControlToValidate="txtFecha1" CssClass="failureNotification" 
                                onservervalidate="CustomValidator1_ServerValidate" Text="#MI0040"></asp:CustomValidator>
                            <asp:Button ID="btnGenerar" runat="server" Text="#Consultar" OnClick="btnGenerar_Click"
                                ValidationGroup="Validacion" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
