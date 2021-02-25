<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionHerramientaEquipo.aspx.cs" Inherits="AdministracionHerramientaEquipo" %>

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
                <asp:Label ID="lblTitulo" runat="server" Text="#HerramientaEquipo"></asp:Label>
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
                <asp:LinqDataSource ID="dsActivoFijo" runat="server" OnSelecting="dsActivoFijo_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsUsuarios" EntityTypeName="objCombo" runat="server" OnSelecting="dsUsuarios_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsSucursales" runat="server" EntityTypeName="objCombo" OnSelecting="dsSucursales_Selecting">
                </asp:LinqDataSource>
                <br />
                <asp:ListView ID="dlActivoFijo" runat="server" DataKeyNames="ClaveActivo" DataSourceID="dsActivoFijo"
                    OnItemUpdating="dlActivoFijo_ItemUpdating" OnItemCommand="dlActivoFijo_ItemCommand"
                    OnItemInserting="dlActivoFijo_ItemInserting" OnItemDataBound="dlActivoFijo_ItemDataBound"
                    OnItemCreated="dlActivoFijo_ItemCreated" OnPagePropertiesChanged="dlActivoFijo_PagePropertiesChanged"
                    OnPreRender="dlActivoFijo_PreRender" OnDataBinding ="dlActivoFijo_DataBinding">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titClave" runat="server" Text="#Clave"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titDescripcion" runat="server" Text="#Descripcion"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titUsuario" runat="server" Text="#NumeroEmpleado"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titSucursal" runat="server" Text="#Sucursal"></asp:Label>
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
                                        <asp:TextBox ID="filDescripcion" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filNoEmpleado" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSucursal" runat="server" CssClass="navegacion"></asp:TextBox>
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
                                <tr>
                                    <td colspan="5">
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlActivoFijo"
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
                                <%#  Eval("ClaveActivo") %>
                            </td>
                            <td class="navegacion">
                                <%#  Eval("Descripcion") %>
                            </td>
                            <td class="navegacion">
                                <%#  Eval("Usuario.ClaveUsuario") %>
                            </td>
                                                        <td class="navegacion">
                                <%#  Eval("Usuario.Sucursal.Nombre") %>
                            </td>

                            <td class="navegacion" style="text-align: center">
                                <asp:CheckBox ID="cmbEstado" runat="server" Checked='<%# (bool)Eval("Estado") %>'
                                    Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEdital" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ( (Eval("ClaveActivo")== null) || (Eval("ClaveActivo")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="5">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" runat="server" Text='<%#Bind("ClaveActivo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator OnServerValidate="validaClave" CssClass="failureNotification"
                                                    ControlToValidate="txtClave" ID="CustomValidator3" ValidationGroup="ValidarDatos"
                                                    runat="server" Text="*" ErrorMessage="#MI0008"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" Checked='<%#Bind("Estado")%>' ID="chkEstado" Text="#Activo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbSucursal" runat="server" DataTextField="Nombre" DataValueField="ClaveSucursal"
                                                    DropDownStyle="DropDownList" DataSourceID="dsSucursales" AutoCompleteMode="Suggest"
                                                    ClientIDMode="Static" MaxLength="0"  OnSelectedIndexChanged="cmbSucursal_OnSelected" AutoPostBack = "true">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                            <td rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#Tecnico"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbUsuario" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsUsuarios"
                                                    AutoCompleteMode="Suggest" MaxLength="0">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescripcion" runat="server" Text="#Descripcion"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDescripcion" runat="server" Text='<%#Bind("Descripcion")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#Descripcion"
                                                    ControlToValidate="txtDescripcion" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroSerie" runat="server" Text='<%#Bind("NumeroSerie")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#CodigoBarras"
                                                    ControlToValidate="txtNumeroSerie" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: right;">
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Insert" ImageUrl="~/img/Nuevo.jpg"
                                                    ToolTip="#Insertar" ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancelar" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="5">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" ReadOnly="true" runat="server" Text='<%#Bind("ClaveActivo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" Checked='<%#Bind("Estado")%>' ID="chkEstado" Text="#Activo" />
                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="Registro con dependencias"
                                                    Text="*" CssClass="failureNotification" OnServerValidate="validaEstado" ValidationGroup="ValidarDatos"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbSucursal"
                                                    runat="server" DataTextField="Nombre" DataValueField="ClaveSucursal" DropDownStyle="DropDownList"
                                                    DataSourceID="dsSucursales" AutoCompleteMode="Suggest" OnSelectedIndexChanged="cmbSucursal_OnSelected"
                                                    MaxLength="0" AutoPostBack = "true">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                            <td rowspan="4">
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#Tecnico"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox ID="cmbUsuario" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsUsuarios"
                                                    OnDataBound="cmbUsuario_Bound" AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDescripcion" runat="server" Text="#Descripcion"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDescripcion" runat="server" Text='<%#Bind("Descripcion")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#Descripcion"
                                                    ControlToValidate="txtDescripcion" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#CodigoBarras"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroSerie" runat="server" Text='<%#Bind("NumeroSerie")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#CodigoBarras"
                                                    ControlToValidate="txtNumeroSerie" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: right;">
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Update" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Actualizar" ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancelar" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
