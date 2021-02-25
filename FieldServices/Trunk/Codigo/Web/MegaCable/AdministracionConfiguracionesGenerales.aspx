<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionConfiguracionesGenerales.aspx.cs" Inherits="AdministracionConfiguracionesGenerales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="eisc" Namespace="MEGACABLE.CONTROLS" Assembly="MEGACABLE.CONTROLS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">

        function ValidaRequerido(sender, args) {
            args.IsValid = (args.Value != "0");
        }

        var launch = false;
        var msj = "";

        function launchModal() {
            launch = true;
            msj = mensaje;
        }

        function pageLoad() {
            if (launch) {
                $find("mpe").show();
            }
        }

    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#ConfGenerales"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="toolbar">
                <asp:LinkButton ID="lnkInsert" runat="server" OnClick="Nuevo_Registro_Click">#NuevoRegistro</asp:LinkButton>
                    <!--<asp:ImageButton OnClick="Nuevo_Registro_Click" ID="btnInsert" runat="server" CommandName=""
                        ImageUrl="~/img/Nuevo.jpg" ToolTip="#NuevoRegistro" style="width: 16px"  />-->
                </div>
                <asp:LinqDataSource ID="dsConfiguracion" runat="server" OnSelecting="dsConfiguracion_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsSucursales" EntityTypeName="objCombo" runat="server" OnSelecting="dsSucursales_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsValorConfiguracion" EntityTypeName="objCombo" runat="server"
                    OnSelecting="dsValorConfiguracion_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsValorReferencia" EntityTypeName="objCombo" runat="server"
                    OnSelecting="dsValorReferencia_Selecting">
                </asp:LinqDataSource>
                <br />
                <asp:ListView ID="dlConfiguracion" runat="server" DataKeyNames="ClaveSucursal,Parametro"
                    DataSourceID="dsConfiguracion" OnItemUpdating="dlConfiguracion_ItemUpdating"
                    OnItemCommand="dlConfiguracion_ItemCommand" OnItemInserting="dlConfiguracion_ItemInserting"
                    OnItemCreated="dlConfiguracion_ItemCreated" OnItemDataBound="dlConfiguracion_ItemDataBound"
                    OnPreRender="dlConfiguracion_PreRender" 
                    onpagepropertieschanged="dlConfiguracion_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titParametro" runat="server" Text="#Parametro"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titValor" runat="server" Text="#Valor"></asp:Label>
                                    </th>
                                    <th style = "width:80px;" >
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSucursal" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filParametro" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filValor" runat="server" CssClass="navegacion"></asp:TextBox>
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
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlConfiguracion"
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
                                <%# Eval("Parametro")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Valor")%>
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEdital" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="3">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveSucursal")%>' ID="cmbSucursal" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsSucursales"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                                <asp:CustomValidator OnServerValidate="validaClave" CssClass="failureNotification"
                                                    ControlToValidate="cmbSucursal" ID="CustomValidator3" ValidationGroup="ValidarDatos"
                                                    runat="server" Text="*" ErrorMessage="#MI0008"></asp:CustomValidator>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                            <td>
                                                <asp:Label ID="lblParametro" runat="server" Text="#Parametro"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("Parametro")%>' AutoPostBack="true" OnSelectedIndexChanged="valorConfiguracion_indexChange"
                                                    ID="cmbParametro" runat="server" DataTextField="Texto" DataValueField="Clave"
                                                    DropDownStyle="DropDownList" DataSourceID="dsValorConfiguracion" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                                <asp:CustomValidator OnServerValidate="validaClave" CssClass="failureNotification"
                                                    ControlToValidate="cmbParametro" ID="CustomValidator1" ValidationGroup="ValidarDatos"
                                                    runat="server" Text="*" ErrorMessage=""></asp:CustomValidator>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Valor"></asp:Label>
                                            </td>
                                            <td>
                                                <eisc:ComboBox2 ID="cmbValor" DataSourceID="dsValorReferencia" runat="server" DataTextField="Texto"
                                                    DataValueField="Clave" DropDownStyle="DropDownList" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" />
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#Valor"
                                                    ControlToValidate="cmbValor" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos">
                                                </asp:RequiredFieldValidator>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                            <td colspan="2" >
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
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
                            <td class="navegacion" colspan="3">
                                <div class="editar">
                                    <table class="editar">
                                        <asp:HiddenField Value='<%#Bind("Valor")%>' ID="HValor" runat="server" />
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox Enabled="false" SelectedValue='<%#Bind("ClaveSucursal")%>' ID="cmbSucursal"
                                                    runat="server" DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList"
                                                    DataSourceID="dsSucursales" AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                            <td>
                                                <asp:Label ID="lblParametro" runat="server" Text="#Parametro"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox Enabled="false" SelectedValue='<%#Bind("Parametro")%>' AutoPostBack="true"
                                                    OnSelectedIndexChanged="valorConfiguracion_indexChange" ID="cmbParametro" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" OnDataBound="cmbValordsda_DataBound"
                                                    DropDownStyle="DropDownList" DataSourceID="dsValorConfiguracion" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Valor"></asp:Label>
                                            </td>
                                            <td>
                                                <eisc:ComboBox2 ID="cmbValor" DataSourceID="dsValorReferencia" runat="server" DataTextField="Texto"
                                                    DataValueField="Clave" DropDownStyle="DropDownList" AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;" />
                                                <%--<asp:ComboBox ID="cmbValor" DataSourceID="dsValorReferencia" runat="server" DataTextField="Texto" DataValueField="Clave"
                                                    DropDownStyle="DropDownList"  AutoCompleteMode="Suggest"
                                                    MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>--%>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="#MI0001,#Valor"
                                                    ControlToValidate="cmbValor" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: right;">
                                                <asp:ImageButton ID="btnInsert" runat="server" CommandName="Update" ImageUrl="~/img/Update.jpg"
                                                    ToolTip="#Actualizar" ValidationGroup="ValidarDatos" />
                                                <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                    ToolTip="#Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </EditItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
