<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionSucursales.aspx.cs" Inherits="AdministracionSucursales" %>

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
                <asp:Label ID="lblTitulo" runat="server" Text="#Sucursales"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" CommandName=""
                        ImageUrl="~/img/Nuevo.jpg" ToolTip="#NuevoRegistro" style="width: 16px" />-->
                </div>
                <asp:LinqDataSource ID="LinqDataSource1" runat="server" OnSelecting="LinqDataSource1_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsCiudades" EntityTypeName="objCombo" runat="server" OnSelecting="dsCiudades_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsRegiones" EntityTypeName="objCombo" runat="server" OnSelecting="dsRegiones_Selecting">
                </asp:LinqDataSource>
                <br />
                <asp:ListView ID="dlSucursales" runat="server" DataKeyNames="ClaveSucursal" DataSourceID="LinqDataSource1"
                    OnItemUpdating="dlSucursales_ItemUpdating" OnItemCommand="dlSucursales_ItemCommand"
                    OnItemInserting="dlSucursales_ItemInserting" OnItemCreated="dlSucursales_ItemCreated"
                    OnDataBound="dlSucursales_DataBound" 
                    onpagepropertieschanged="dlSucursales_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titClave" runat="server" Text="#Clave"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titNombre" runat="server" Text="#NombreBase"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titCiudad" runat="server" Text="#Ciudad"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titRegion" runat="server" Text="#Region"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titActivo" runat="server" Text="#Activo"></asp:Label>
                                    </th>
                                    <th style = "width:80px;">
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filClave" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filNombre" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filCiudad" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filRegion" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion" style="text-align: center;">
                                        <asp:ComboBox ID="cmbEstado" runat="server" Width="70" AutoCompleteMode="Suggest"
                                            DropDownStyle="DropDownList">
                                            <asp:ListItem Text="#Todos" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="#Activos" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="#Inactivos" Value="I"></asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton CommandName="Filtrar" ID="btnFiltrar" ToolTip="#Filtrar"  runat="server" ImageUrl="~/img/Document Down.jpg" />
                                        <asp:ImageButton CommandName="QuitarFiltro" ID="btnQuitarFiltro" ToolTip="#BorrarFiltros" runat="server" ImageUrl="~/img/SinFiltro.gif" />
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                                <tr>
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlSucursales"
                                            PageSize="12">
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
                                <%#  Eval("ClaveSucursal") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Ciudad.Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Region.Nombre")%>
                            </td>
                            <td class="navegacion" style="text-align: center;">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# (bool)Eval("Estado") %>'
                                    Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEdital" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ((Eval("ClaveSucursal")== null) || (Eval("ClaveSucursal")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="5">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%#Bind("Estado")%>' Text="#Activo"
                                                    TextAlign="Left" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" runat="server" Text='<%#Bind("ClaveSucursal")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator OnServerValidate="validaClave" CssClass="failureNotification"
                                                    ControlToValidate="txtClave" ID="CustomValidator3" ValidationGroup="ValidarDatos"
                                                    runat="server" Text="*" ErrorMessage="#MI0008"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNombre" runat="server" Text="#NombreBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" runat="server" Text='<%#Bind("Nombre")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NombreBase"
                                                    ControlToValidate="txtNombre" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Ciudad"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveCiudad")%>' ID="cmbCiudad" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsCiudades"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="#MI0001,#Ciudad"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbCiudad"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="#Region"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveRegion")%>' ID="cmbRegion" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsRegiones"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="#MI0001,#Region"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbRegion"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="Label3" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#SalidaBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCodigoBarrasSalida" runat="server" Text='<%#Bind("CodigoBarrasSalida")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#SalidaBase"
                                                    ControlToValidate="txtCodigoBarrasSalida" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2" rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="#LlegadaBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCodigoBarrasLlegada" runat="server" Text='<%#Bind("CodigoBarrasLlegada")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="#MI0001,#LlegadaBase"
                                                    ControlToValidate="txtCodigoBarrasLlegada" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ImageUrl="~/img/Nuevo.jpg"
                                                    ToolTip="#Insertar" ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="5">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:CheckBox  ID="chkActivo" runat="server" Checked='<%#Bind("Estado")%>' Text="#Activo"
                                                    TextAlign="Left" />

                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="#ME0025"
                                                    Text="*" CssClass="failureNotification" OnServerValidate="validaEstadoSucursal"
                                                    ValidationGroup="ValidarDatos"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" ReadOnly="true" runat="server" Text='<%#Bind("ClaveSucursal")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNombre" runat="server" Text="#NombreBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" runat="server" Text='<%#Bind("Nombre")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NombreBase"
                                                    ControlToValidate="txtNombre" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Ciudad"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveCiudad")%>' ID="cmbCiudad" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsCiudades"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="#MI0001,#Ciudad"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbCiudad"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="#Region"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveRegion")%>' ID="cmbRegion" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsRegiones"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="#MI0001,#Region"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbRegion"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="Label3" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#SalidaBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCodigoBarrasSalida" runat="server" Text='<%#Bind("CodigoBarrasSalida")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#SalidaBase"
                                                    ControlToValidate="txtCodigoBarrasSalida" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2" rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="#LlegadaBase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCodigoBarrasLlegada" runat="server" Text='<%#Bind("CodigoBarrasLlegada")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="#MI0001,#LlegadaBase"
                                                    ControlToValidate="txtCodigoBarrasLlegada" Text="*" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Update" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Actualizar" CommandArgument='<%#  Eval("ClaveSucursal") %>' ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
