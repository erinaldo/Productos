<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionUsuarios.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        function ValidaRequerido(sender, args) {
            args.IsValid = ((args.Value != "0") && (args.Value != "-1"));
        }
        function pageLoad(sender, args) {

            $(".contrasenia").each(function () {
                $password = $(this);
                $clone = $('<input type="password"/>');
                $clone.attr("id", $password.attr("id"));
                $clone.attr("name", $password.attr("name"));
                $clone.attr("class", $password.attr("class"));
                $clone.val($password.val());
                $clone.insertAfter($password);
                $password.remove();
            });
        }
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Usuarios"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                    <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" CommandName=""
                        ImageUrl="~/img/Nuevo.jpg" ToolTip="#NuevoRegistro" Style="width: 16px" />-->
                </div>
                <asp:LinqDataSource ID="dsUsuarios" runat="server" OnSelecting="LinqDataSource1_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsPerfiles" runat="server" EntityTypeName="objCombo" OnSelecting="dsPerfiles_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsTipos" runat="server" EntityTypeName="objCombo" OnSelecting="dsTipos_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsCuadrillas" runat="server" EntityTypeName="objCombo" OnSelecting="dsCuadrillas_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsSucursales" runat="server" EntityTypeName="objCombo" OnSelecting="dsSucursales_Selecting">
                </asp:LinqDataSource>
                <asp:ListView ID="dlUsuarios" runat="server" DataKeyNames="ClaveUsuario" DataSourceID="dsUsuarios"
                    OnItemCommand="dlUsuarios_ItemCommand" OnItemDataBound="dlUsuarios_ItemDataBound"
                    OnItemEditing="dlUsuarios_ItemEditing" OnDataBound="dlUsuarios_DataBound" OnItemInserting="dlUsuarios_ItemInserting"
                    OnPagePropertiesChanged="dlUsuarios_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titClave" runat="server" Text="#NumeroEmpleado"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titNombre" runat="server" Text="#Nombre"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titPerfil" runat="server" Text="#Perfil"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titCuadrilla" runat="server" Text="#Cuadrilla"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titActivo" runat="server" Text="#Activo"></asp:Label>
                                    </th>
                                    <th style="width: 80px;">
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
                                        <asp:TextBox ID="filPerfil" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSucursal" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filCuadrilla" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion" style="text-align: center;">
                                        <asp:ComboBox ID="cmbEstado" runat="server" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
                                            <asp:ListItem Text="#Todos" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="#Activos" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="#Inactivos" Value="I"></asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnFiltrar" runat="server" ImageUrl="~/img/Document Down.jpg"
                                            CommandName="Filtrar" ToolTip="#Filtrar" />
                                        <asp:ImageButton ID="btnQuitarFiltro" runat="server" ImageUrl="~/img/SinFiltro.gif"
                                            CommandName="QuitarFiltro" ToolTip="#BorrarFiltros" />
                                    </td>
                                </tr>
                                <tr runat="server" id="itemPlaceholder" />
                                <tr class="navegacion">
                                    <td colspan="6">
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlUsuarios"
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
                                <%#  Eval("ClaveUsuario") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("NombrePerfil")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("NombreSucursal")%>
                            </td>
                            <td class="navegacion">
                                <%# (String.IsNullOrWhiteSpace((string)Eval("ClaveCuadrilla"))? "": Eval("ClaveCuadrilla").ToString().Substring(Eval("ClaveSucursal").ToString().Length +1))%>
                            </td>
                            <td class="navegacion" style="text-align: center;">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# (bool)Eval("Estado") %>'
                                    Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEdital" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ((Eval("ClaveUsuario")== null) || (Eval("ClaveUsuario")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="6">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:CheckBox ID="chkActivo" runat="server" Checked='<%#Bind("Estado") %>' Text="#Activo"
                                                    TextAlign="Left" />
                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Registro con dependencias"
                                                    Text="*" CssClass="failureNotification" OnServerValidate="ValidarDatos" ValidationGroup="ValidarDatos"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#NumeroEmpleado"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" runat="server" Text='<%#Bind("ClaveUsuario") %>' ReadOnly="True"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NumeroEmpleado"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblContrasenia" runat="server" Text="#Contrasenia"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContrasenia" Style="visibility: hidden;" class="contrasenia"
                                                    runat="server" Text='<%#Bind("Contrasenia") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Contrasenia"
                                                    ControlToValidate="txtContrasenia" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNombre" runat="server" Text="#Nombre"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" runat="server" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Nombre"
                                                    ControlToValidate="txtNombre" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblConfirmarContrasenia" runat="server" Text="#ConfirmarContrasenia"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtConfirmarContrasenia" Style="visibility: hidden;" class="contrasenia"
                                                    runat="server" Text='<%# Eval("Contrasenia") %>'></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="#MI0004"
                                                    ControlToCompare="txtConfirmarContrasenia" ControlToValidate="txtContrasenia"
                                                    CssClass="failureNotification" Text="*" ValidationGroup="ValidarDatos" ValueToCompare="Text"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPerfil" runat="server" Text="#Perfil"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbPerfil" runat="server" DataTextField="Nombre" DataValueField="ClavePerfil"
                                                    DropDownStyle="DropDownList" DataSourceID="dsPerfiles" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="#MI0001,#Perfil"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbPerfil"></asp:CustomValidator>
                                            </td>
                                            <td colspan="2" rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTipo" runat="server" Text="#Tipo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbTipo" runat="server" DataTextField="Descripcion" DataValueField="Valor"
                                                    DropDownStyle="DropDownList" DataSourceID="dsTipos" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" CaseSensitive="False" ItemInsertLocation="Append"
                                                    AutoPostBack="True" OnSelectedIndexChanged="cmbTipo_SelectedIndexChanged">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="#MI0001,#Tipo"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbTipo"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbSucursal" runat="server" DataTextField="Nombre" DataValueField="ClaveSucursal"
                                                    DropDownStyle="DropDownList" DataSourceID="dsSucursales" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="#MI0001,#Sucursal"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbSucursal"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCuadrilla" runat="server" Text="#Cuadrilla"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbCuadrilla" runat="server" DataTextField="Nombre" DataValueField="ClaveCuadrilla"
                                                    DropDownStyle="DropDownList" DataSourceID="dsCuadrillas" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" Visible="True">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="#MI0001,#Cuadrilla"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbCuadrilla"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Guardar" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Actualizar" CommandArgument='<%#  Eval("ClaveUsuario") %>' ValidationGroup="ValidarDatos" />
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
                                            <td colspan="4" style="text-align: right;">
                                                <asp:CheckBox ID="chkActivo" runat="server" Checked="true" Text="#Activo" TextAlign="Left" />
                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Registro con dependencias"
                                                    Text="*" CssClass="failureNotification" OnServerValidate="ValidarDatos" ValidationGroup="ValidarDatos"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#NumeroEmpleado"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" runat="server" Text='<%#Bind("ClaveUsuario") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#NumeroEmpleado"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblContrasenia" runat="server" Text="#Contrasenia"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtContrasenia" runat="server" Style="visibility: hidden;" class="contrasenia"
                                                    Text='<%#Bind("Contrasenia") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Contrasenia"
                                                    ControlToValidate="txtContrasenia" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNombre" runat="server" Text="#Nombre"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNombre" runat="server" Text='<%#Bind("Nombre") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Nombre"
                                                    ControlToValidate="txtNombre" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblConfirmarContrasenia" runat="server" Text="#ConfirmarContrasenia"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtConfirmarContrasenia" runat="server" Style="visibility: hidden;"
                                                    class="contrasenia" Text='<%# Eval("Contrasenia") %>'></asp:TextBox>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="#MI0004"
                                                    ControlToCompare="txtConfirmarContrasenia" ControlToValidate="txtContrasenia"
                                                    CssClass="failureNotification" Text="*" ValidationGroup="ValidarDatos" ValueToCompare="Text"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPerfil" runat="server" Text="#Perfil"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbPerfil" runat="server" DataTextField="Nombre" DataValueField="ClavePerfil"
                                                    DropDownStyle="DropDownList" DataSourceID="dsPerfiles" AutoCompleteMode="Suggest"
                                                    MaxLength="0" SelectedValue='<%#Bind("ClavePerfil")%>' Style="display: inline;">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="#MI0001,#Perfil"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbPerfil"></asp:CustomValidator>
                                            </td>
                                            <td colspan="2" rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTipo" runat="server" Text="#Tipo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbTipo" runat="server" DataTextField="Descripcion" DataValueField="Valor"
                                                    DropDownStyle="DropDown" DataSourceID="dsTipos" AutoCompleteMode="Suggest" MaxLength="0"
                                                    Style="display: inline;" SelectedValue='<%#Bind("Tipo")%>' CaseSensitive="False"
                                                    ItemInsertLocation="Append" AutoPostBack="True" OnSelectedIndexChanged="cmbTipo_SelectedIndexChanged">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="#MI0001,#Tipo"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbTipo"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbSucursal" runat="server" DataTextField="Nombre" DataValueField="ClaveSucursal"
                                                    DropDownStyle="DropDownList" SelectedValue='<%#Bind("ClaveSucursal")%>' DataSourceID="dsSucursales"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;" OnSelectedIndexChanged="cmbSucursal_SelectedIndexChanged"
                                                    AutoPostBack="True">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="#MI0001,#Sucursal"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbSucursal"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCuadrilla" runat="server" Text="#Cuadrilla"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbCuadrilla" runat="server" DataTextField="Nombre" DataValueField="ClaveCuadrilla"
                                                    DropDownStyle="DropDownList" DataSourceID="dsCuadrillas" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" Visible="True">
                                                </asp:ComboBox>
                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="#MI0001,#Cuadrilla"
                                                    Text="*" CssClass="failureNotification" ClientValidationFunction="ValidaRequerido"
                                                    ValidationGroup="ValidarDatos" ControlToValidate="cmbCuadrilla"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnUpdate" runat="server" CommandName="Insert" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Insertar" CommandArgument='<%#  Eval("ClaveUsuario") %>' ValidationGroup="ValidarDatos" />
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
