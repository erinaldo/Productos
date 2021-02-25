<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AuditoriaRecepcionInformacion.aspx.cs" Inherits="AuditoriaRecepcionInformacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#AudRecepInfo"></asp:Label>
            </h1>
        </div>
    </div>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtFecha.ClientID%>").datepicker();
            $("#<%=txtFecha.ClientID%>").datepicker('option', {
                dateFormat: "dd/mm/yy",
                maxDate: 0,
                altField: "#<%=hidFecha.ClientID%>",
                altFormat: "yy-mm-dd",
                changeMonth: true,
                changeYear: true,
                defaultDate: 0
            });
            var fecha = new Date();
            $("#<%=txtFecha.ClientID%>").val(("00" + fecha.getDate().toString()).slice(-2) + "/" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "/" + fecha.getFullYear().toString());
            $("#<%=hidFecha.ClientID%>").val(fecha.getFullYear().toString() + "-" + ("00" + (fecha.getMonth() + 1).toString()).slice(-2) + "-" + ("00" + fecha.getDate().toString()).slice(-2));

        });
    </script>
    <asp:UpdatePanel ID="updNacional" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="border: 1px solid gray; margin: 10px;">
                <h6>
                    <asp:Label ID="lblTotalNacional" runat="server" Text="#TotalNacional"></asp:Label></h6>
                <table class="navegacion">
                    <tr>
                        <td>
                            <asp:Label ID="lblTNNoCuadrillas" runat="server" Text="#NoCuadrillas"></asp:Label>:
                        </td>
                        <td>
                            <b>
                                <asp:TextBox ID="fldTNNoCuadrillas" runat="server" Text="" CssClass="navegacion" ReadOnly="True"
                                ></asp:TextBox></b>
                        </td>
                        <td>
                            <asp:Label ID="lblTNSalieron" runat="server" Text="#SalieronDeBase"></asp:Label>:
                        </td>
                        <td>
                            <b>
                                <asp:TextBox ID="fldTNSalieron" runat="server" Text="" CssClass="navegacion" ReadOnly="True"
                                ></asp:TextBox></b>
                        </td>
                        <td>
                                <asp:Label ID="lblTNRegresaron" runat="server" Text="#RegresaronABase"></asp:Label>:
                        </td>
                        <td>
                            <b>
                                <asp:TextBox ID="fldTNRegresaron" runat="server" Text="" CssClass="navegacion" ReadOnly="True"
                                ></asp:TextBox></b>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="updControles" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="navegacion">
                <tr>
                    <td>
                        <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                        &nbsp;
                        <asp:ComboBox ID="cmbSucursal" runat="server" BorderColor="#B3B3FF" BorderStyle="Solid"
                            BorderWidth="1px" Width="200px" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
                        </asp:ComboBox>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label>
                        &nbsp;
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="navegacion" ReadOnly="True" Width="200px"
                            BorderColor="#B3B3FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                        <asp:HiddenField ID="hidFecha" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: right">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"
                            ControlToValidate="cmbSucursal" ValidationGroup="ValidaDatos"></asp:RequiredFieldValidator>
                        <asp:Button ID="btnGenerar" runat="server" Text="#Generar" ValidationGroup="ValidaDatos"
                            OnClick="btnGenerar_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="contenidoauditoria">
        <asp:UpdatePanel ID="updAuditoria" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
            <ContentTemplate>
                <table class="navegacion">
                    <tr>
                        <td>
                            <asp:Label ID="lblNoCuadrillas" runat="server" Text="#NoCuadrillas"></asp:Label>:
                        </td>
                        <td>
                            <b><asp:TextBox ID="txtNoCuadrillas" runat="server" CssClass="navegacion" BorderStyle="None"
                                ReadOnly="True"></asp:TextBox></b>
                        </td>
                        <td>
                            <asp:Label ID="lblSalieron" runat="server" Text="#SalieronDeBase"></asp:Label>:
                        </td>
                        <td>
                            <b><asp:TextBox ID="txtSalieron" runat="server" CssClass="navegacion" ReadOnly="True"
                                ></asp:TextBox></b>
                        </td>
                        <td>
                            <asp:Label ID="lblRegresaron" runat="server" Text="#RegresaronABase"></asp:Label>:
                        </td>
                        <td>
                            <b><asp:TextBox ID="txtRefresaron" runat="server" CssClass="navegacion" ReadOnly="True"
                                ></asp:TextBox></b>
                        </td>
                    </tr>
                </table>
                  <asp:ListView ID="dlAuditoria" runat="server" 
                    ondatabound="dlAuditoria_DataBound" onitemcommand="dlAuditoria_ItemCommand">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titEstado" runat="server" Text="#Estado"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titCuadrilla" runat="server" Text="#Cuadrilla"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titHoraAgenda" runat="server" Text="#HoraAgenda"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titHoraSincronizacion" runat="server" Text="#HoraSincronizacion"></asp:Label>
                                    </th>
                                    <th  "width:80px;"></th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filEstado" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filCuadrilla" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <!--<asp:TextBox ID="filHoraAgenda" runat="server" CssClass="navegacion"></asp:TextBox>-->
                                    </td>
                                    <td class="navegacion">
                                        <!--<asp:TextBox ID="filHoraSincronizacion" runat="server" CssClass="navegacion"></asp:TextBox>-->
                                    </td>
                                    <td>
                                        <asp:ImageButton CommandName="Filtrar" ID="btnFiltrar" runat="server" ImageUrl="~/img/Document Down.jpg"
                                            />                                                                    
                                        <asp:ImageButton CommandName="QuitarFiltro" ID="btnQuitarFiltro" runat="server" ImageUrl="~/img/SinFiltro.gif"
                                             />                                       
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                               
                            </table>
                        </asp:Panel>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion">
                                <%#  Eval("Estado") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("ClaveCuadrilla")%>
                            </td>
                            <td class="navegacion">
                                <%#  Eval("HoraAgenda")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("HoraSincronizacion")%>
                            </td>
                            <td></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
