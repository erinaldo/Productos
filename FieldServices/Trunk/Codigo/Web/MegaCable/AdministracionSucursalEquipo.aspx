<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionSucursalEquipo.aspx.cs" Inherits="AdministracionSucursalEquipo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        var temp = false;
        $(document).ready(function () {
            CargarAutocompletar();
        });
        function CargarAutocompletar() {
            temp = false;
            $("#<%=txtMaterial.ClientID%>").val("");
            $("#<%=hidValor.ClientID%>").val("")
            $("#<%=btnAgregar.ClientID%>").submit(function () {
                var regreso = ($("#<%=hidValor.ClientID%>").val() == "");
                return !regreso;

            });
            $("#<%=txtMaterial.ClientID%>").keydown(function (event) {
                //$("#MainContent_lblTitulo").append(event.which);
                if (event.which != 13) {
                    $("#<%=hidValor.ClientID%>").val("");
                    $("#<%=txtMaterial.ClientID%>").val("");
                }
            });
            $("#<%=txtMaterial.ClientID%>").autocomplete({
                source: function (request, response) {
                    PageMethods.GetMateriales(request.term, $("#<%=hidSucursal.ClientID%>").val(),
                    function (data) {
                        var materiales = (typeof data) == 'string' ? eval('(' + data + ')') : data;
                        response(materiales);
                    },
                    fnllamadaError);
                },
                minLenght: 4,
                select: function (event, ui) {
                    selecciona(ui.item.id, ui.item.value);
                }
            });
            $("#<%=txtMaterial.ClientID%>").focus();
        }
        function fnllamadaError(exception) {
            alert("Error interno: " + exception.get_message());
        }
        function selecciona(clave, valor) {

            $("#<%=hidValor.ClientID%>").val(clave);
        }
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#ModSucursalEquipo"></asp:Label>
            </h1>
        </div>
    </div>
    <div>
        <table class="navegacion">
            <tr>
                <td>
                    <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="updSucursal" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ComboBox ID="cmbSucursal" runat="server" BorderColor="#B3B3FF" BorderStyle="Solid"
                                BorderWidth="1px" Width="200px" AutoCompleteMode="Suggest" DropDownStyle="DropDownList"
                                AutoPostBack="True" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged">
                            </asp:ComboBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMaterial" runat="server" Text="#Material"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="updMaterial" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <script language="javascript" type="text/javascript">
                                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(CargarAutocompletar);
                            </script>
                            <asp:Panel ID="pnlAgregar" runat="server" DefaultButton="btnAgregar" Width="500px">
                                <asp:TextBox ID="txtMaterial" runat="server" Width="400px"></asp:TextBox>
                                <asp:Button ID="btnAgregar" runat="server" Text="#Insertar" OnClick="btnAgregar_Click"
                                    Width="74px" />
                                <asp:HiddenField ID="hidValor" runat="server" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="overflow: auto; height: 450px; width: 800px">
                        <asp:UpdatePanel ID="updMateriales" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:HiddenField ID="hidSucursal" runat="server" />
                                <asp:ListView ID="dlMaterial" runat="server" DataKeyNames="ClaveMaterial" OnItemCommand="dlMaterial_ItemCommand">
                                    <LayoutTemplate>
                                        <table id="tablaMaterial" class="navegacion">
                                            <tr class="navegacion">
                                                <th class="navegacion">
                                                    <asp:Label ID="titClave" runat="server" Text="#Clave"></asp:Label>
                                                </th>
                                                <th class="navegacion">
                                                    <asp:Label ID="titMaterial" runat="server" Text="#Material"></asp:Label>
                                                </th>
                                                <th style="width: 80px;">
                                                </th>
                                            </tr>
                                            <tr runat="server" id="itemPlaceholder" />
                                        </table>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <tr id="filaElemento" class="navegacion">
                                            <td id="Td1" class="navegacion">
                                                <%#  Eval("ClaveMaterial") %>
                                            </td>
                                            <td id="valor" class="navegacion">
                                                <%#  Eval("Descripcion") %>
                                            </td>
                                            <td id="boton">
                                                <asp:ImageButton ID="btnEliminar" runat="server" CommandName="Borrar" CommandArgument='<%#Eval("ClaveMaterial") %>'
                                                    ImageUrl="~/img/Document 2 Delete.jpg" ToolTip="#Eliminar" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
