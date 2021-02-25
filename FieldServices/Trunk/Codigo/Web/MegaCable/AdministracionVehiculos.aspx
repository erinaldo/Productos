<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionVehiculos.aspx.cs" Inherits="AdministracionVehiculos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        function ValidaRequerido(sender, args) {
            args.IsValid = (args.Value != "0");
        }
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Vehiculos"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" ToolTip ="#NuevoRegistro" CommandName=""
                        ImageUrl="~/img/Nuevo.jpg" style="width: 16px" />-->
                </div>
                <asp:LinqDataSource ID="dsVehiculos" runat="server" OnSelecting="dsVehiculos_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsSucursales" runat="server" EntityTypeName="objCombo" OnSelecting="dsSucursales_Selecting">
                </asp:LinqDataSource>
                <asp:ListView ID="dlVehiculos" runat="server" DataKeyNames="NumeroEconomicoVh" DataSourceID="dsVehiculos"
                    OnItemCommand="dlVehiculos_ItemCommand" OnItemInserting="dlVehiculos_ItemInserting"
                    OnItemEditing="dlVehiculos_ItemEditing" 
                    OnItemUpdating="dlVehiculos_ItemUpdating" 
                    ondatabound="dlVehiculos_DataBound" 
                    onitemcanceling="dlVehiculos_ItemCanceling" 
                    onpagepropertieschanged="dlVehiculos_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titNumeroEconomico" runat="server" Text="#NumeroEconomico"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titPlacas" runat="server" Text="#Placas"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titMarca" runat="server" Text="#Marca"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titSubmarca" runat="server" Text="#Submarca"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titModelo" runat="server" Text="#Modelo"></asp:Label>
                                    </th>
                                    <th style = "width:80px;">
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filNumeroEconomico" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filPlacas" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filMarca" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSubmarca" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSucursal" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filModelo" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnFiltrar" runat="server" ToolTip ="#Filtrar" ImageUrl="~/img/Document Down.jpg"
                                            CommandName="Filtrar" />
                                        <asp:ImageButton ID="btnQuitarFiltro" runat="server" ToolTip ="#BorrarFiltros" ImageUrl="~/img/SinFiltro.gif"
                                            CommandName="QuitarFiltro" />
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                                <tr>
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlVehiculos"
                                            PageSize="10">
                                            <Fields>
                                                <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="False"
                                                    ShowPreviousPageButton="False" />
                                                <asp:NumericPagerField />
                                                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                                                    ShowPreviousPageButton="False" />
                                            </Fields>
                                        </asp:DataPager>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion">
                                <%#  Eval("NumeroEconomicoVh") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Placas")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Marca")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("SubMarca")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Sucursal.Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Modelo")%>
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEditar" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ((Eval("NumeroEconomicoVh")== null) || (Eval("NumeroEconomicoVh")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="6">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNumeroEconomico" runat="server" Text="#NumeroEconomico"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroEconomico" runat="server" Text='<%#Bind("NumeroEconomicoVh") %>'
                                                    ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NumeroEconomico"
                                                    ToolTip="#MI0001,#NumeroEconomico" ControlToValidate="txtNumeroEconomico" Text="*"
                                                    CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlacas" runat="server" Text="#Placas"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPlacas" runat="server" Text='<%#Bind("Placas") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Placas"
                                                    ToolTip="#MI0001,#Placas" ControlToValidate="txtPlacas" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMarca" runat="server" Text="#Marca"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMarca" runat="server" Text='<%#Bind("Marca") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Marca"
                                                    ToolTip="#MI0001,#Marca" ControlToValidate="txtMarca" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblModelo" runat="server" Text="#Modelo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtModelo" runat="server" Text='<%#Bind("Modelo") %>' MaxLength="4"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtModelo">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="#MI0001,#Modelo"
                                                    ToolTip="#MI0001,#Modelo" ControlToValidate="txtModelo" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubMarca" runat="server" Text="#Submarca"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSubMarca" runat="server" Text='<%#Bind("SubMarca") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#SubMarca"
                                                    ToolTip="#MI0001,#SubMarca" ControlToValidate="txtSubMarca" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblKmInicial" runat="server" Text="#KmInicial"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKmInicial" runat="server" Text='<%#Bind("KmInicial") %>' MaxLength="17"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtKmInicial">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveSucursal") %>' ID="cmbSucursal" runat="server"
                                                    DataTextField="Nombre" DataValueField="ClaveSucursal" DropDownStyle="DropDownList"
                                                    DataSourceID="dsSucursales" AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="#MI0001,#Sucursal"
                                                    ToolTip="#MI0001,#Sucursal" Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbSucursal"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblKmFinal" runat="server" Text="#KmFinal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKmFinal" runat="server" Text='<%#Bind("KmFinal") %>' MaxLength="17"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtKmFinal">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCodigoBarras" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                            <td style="vertical-align: top">
                                                <asp:TextBox ID="txtCodigoBarras" runat="server" Text='<%#Bind("CodigoBarras") %>'
                                                    Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="#MI0001,#CodigoBarras"
                                                    ToolTip="#MI0001,#CodigoBarras" ControlToValidate="txtCodigoBarras" Text="*"
                                                    CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Actualizar" CommandArgument='<%#  Eval("NumeroEconomicoVh") %>' ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="6">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNumeroEconomico" runat="server" Text="#NumeroEconomico"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroEconomico" runat="server" Text='<%#Bind("NumeroEconomicoVh") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NumeroEconomico"
                                                    ToolTip="#MI0001,#NumeroEconomico" ControlToValidate="txtNumeroEconomico" Text="*"
                                                    CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPlacas" runat="server" Text="#Placas"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPlacas" runat="server" Text='<%#Bind("Placas") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Placas"
                                                    ToolTip="#MI0001,#Placas" ControlToValidate="txtPlacas" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMarca" runat="server" Text="#Marca"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMarca" runat="server" Text='<%#Bind("Marca") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Marca"
                                                    ToolTip="#MI0001,#Marca" ControlToValidate="txtMarca" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblModelo" runat="server" Text="#Modelo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtModelo" runat="server" Text='<%#Bind("Modelo") %>' MaxLength="4"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtModelo">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="#MI0001,#Modelo"
                                                    ToolTip="#MI0001,#Modelo" ControlToValidate="txtModelo" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubMarca" runat="server" Text="#Submarca"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSubMarca" runat="server" Text='<%#Bind("SubMarca") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#SubMarca"
                                                    ToolTip="#MI0001,#SubMarca" ControlToValidate="txtSubMarca" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblKmInicial" runat="server" Text="#KmInicial"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKmInicial" runat="server" Text='<%#Bind("KmInicial") %>' MaxLength="17"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtKmInicial">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveSucursal") %>' ID="cmbSucursal" runat="server"
                                                    DataTextField="Nombre" DataValueField="ClaveSucursal" DropDownStyle="DropDownList"
                                                    DataSourceID="dsSucursales" AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="#MI0001,#Sucursal"
                                                    ToolTip="#MI0001,#Sucursal" Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbSucursal"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblKmFinal" runat="server" Text="#KmFinal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtKmFinal" runat="server" Text='<%#Bind("KmFinal") %>' MaxLength="17"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                                    TargetControlID="txtKmFinal">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCodigoBarras" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                            <td style="vertical-align: top">
                                                <asp:TextBox ID="txtCodigoBarras" runat="server" Text='<%#Bind("CodigoBarras") %>'
                                                    Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="#MI0001,#CodigoBarras"
                                                    ToolTip="#MI0001,#CodigoBarras" ControlToValidate="txtCodigoBarras" Text="*"
                                                    CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Insert" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Insertar" CommandArgument='<%#  Eval("NumeroEconomicoVh") %>' ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </InsertItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
