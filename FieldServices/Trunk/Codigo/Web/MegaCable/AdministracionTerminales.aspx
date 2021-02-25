<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionTerminales.aspx.cs" Inherits="AdministracionTerminales" %>

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
                <asp:Label ID="lblTitulo" runat="server" Text="#Terminales"></asp:Label>
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
                <asp:LinqDataSource ID="dsSucursales" EntityTypeName="objCombo" runat="server" OnSelecting="dsSucursales_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsValorReferencia" EntityTypeName="objCombo" runat="server"
                    OnSelecting="dsValorReferencia_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsFaseFilter" EntityTypeName="objCombo" runat="server" OnSelecting="dsFaseFilter_Selecting">
                </asp:LinqDataSource>
                <br />
                <asp:ListView ID="dlTerminales" runat="server" DataKeyNames="ClaveTerminal" DataSourceID="LinqDataSource1"
                    OnItemUpdating="dlTerminales_ItemUpdating" OnItemCommand="dlTerminales_ItemCommand"
                    OnItemInserting="dlTerminales_ItemInserting" OnItemCreated="dlTerminales_ItemCreated"
                    OnItemDataBound="dlTerminales_ItemDataBound" OnPagePropertiesChanged="dlTerminales_PagePropertiesChanged">
                    <LayoutTemplate>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFiltrar">
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <th class="navegacion">
                                        <asp:Label ID="titClave" runat="server" Text="#Clave"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titModelo" runat="server" Text="#Modelo"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titNoSerie" runat="server" Text="#NumeroSerie"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titSucursal" runat="server" Text="#Sucursal"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titComentario" runat="server" Text="#Comentario"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titFase" runat="server" Text="#Fase"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titGPS" runat="server" Text="#GPS"></asp:Label>
                                    </th>
                                    <th style="width: 80px;">
                                    </th>
                                </tr>
                                <tr class="navegacion">
                                    <td class="navegacion">
                                        <asp:TextBox ID="filClave" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filModelo" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filNoSerie" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filSucursal" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:TextBox ID="filComentario" runat="server" CssClass="navegacion"></asp:TextBox>
                                    </td>
                                    <td class="navegacion">
                                        <asp:ComboBox ID="filFase" runat="server" Width="70" DataSourceID="dsFaseFilter" DataTextField="Texto"
                                            DataValueField="Clave" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
                                        </asp:ComboBox>
                                    </td>
                                    <td class="navegacion" style="text-align: center;">
                                        <asp:ComboBox ID="cmbGPS" runat="server" Width="70" AutoCompleteMode="Suggest" DropDownStyle="DropDownList">
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
                                    <td>
                                        <asp:DataPager runat="server" ID="ContactsDataPager" PagedControlID="dlTerminales"
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
                                <%#  Eval("ClaveTerminal") %>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Modelo")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("NumeroSerie")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Sucursal.Nombre")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("Comentario")%>
                            </td>
                            <td class="navegacion">
                                <%# Eval("ValorReferencia.Descripcion")%>
                            </td>
                            <td class="navegacion">
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# (bool)Eval("GPS") %>' Enabled="False" />
                            </td>
                            <td>
                                <asp:ImageButton ID="btnEdital" runat="server" CommandName="Edit" ImageUrl="~/img/Editar.jpg"
                                    ToolTip="#Editar" Visible='<%#  ((Eval("ClaveTerminal")== null) || (Eval("ClaveTerminal")=="")? false:true) %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <InsertItemTemplate>
                        <tr class="navegacion">
                            <td class="navegacion" colspan="7">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" runat="server" Text='<%#Bind("ClaveTerminal")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                                <asp:CustomValidator OnServerValidate="validaClave" CssClass="failureNotification"
                                                    ControlToValidate="txtClave" ID="CustomValidator3" ValidationGroup="ValidarDatos"
                                                    runat="server" Text="*" ErrorMessage="#MI0008"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFase" runat="server" Text="#Fase"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("Fase")%>' ID="cmbFase" runat="server" DataTextField="Texto"
                                                    DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsValorReferencia"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                                &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Modelo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtModelo" runat="server" Text='<%#Bind("Modelo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Modelo"
                                                    ControlToValidate="txtModelo" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" Checked='<%#Bind("GPS")%>' ID="chkGPS" Text="#Gps" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="#NumeroSerie"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroSerie" runat="server" Text='<%#Bind("NumeroSerie")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="#MI0001,#NumeroSerie"
                                                    ControlToValidate="txtNumeroSerie" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2" rowspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveSucursal")%>' ID="cmbSucursal" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsSucursales"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="#Comentario"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComentarios" runat="server" Text='<%#Bind("Comentario")%>' TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#Comentario"
                                                    ControlToValidate="txtComentarios" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
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
                            <td class="navegacion" colspan="7">
                                <div class="editar">
                                    <table class="editar">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClave" ReadOnly="true" runat="server" Text='<%#Bind("ClaveTerminal")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="#MI0001,#Clave"
                                                    ControlToValidate="txtClave" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFase" runat="server" Text="#Fase"></asp:Label>
                                            </td>
                                            <td>
                                                <span>
                                                    <asp:ComboBox SelectedValue='<%#Bind("Fase")%>' ID="cmbFase" runat="server" DataTextField="Texto"
                                                        DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsValorReferencia"
                                                        AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                    </asp:ComboBox>
                                                    &nbsp<!--Este espacio es a proposito si se quita la etiqueta salta-->
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="#Modelo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtModelo" runat="server" Text='<%#Bind("Modelo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Modelo"
                                                    ControlToValidate="txtModelo" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:CheckBox runat="server" Checked='<%#Bind("GPS")%>' ID="chkGPS" Text="#Gps" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="#NumeroSerie"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNumeroSerie" runat="server" Text='<%#Bind("NumeroSerie")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="#MI0001,#NumeroSerie"
                                                    ControlToValidate="txtNumeroSerie" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
                                            </td>
                                            <td colspan="2" rowspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification"
                                                    ValidationGroup="ValidarDatos" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="#Sucursal"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:ComboBox SelectedValue='<%#Bind("ClaveSucursal")%>' ID="cmbSucursal" runat="server"
                                                    DataTextField="Texto" DataValueField="Clave" DropDownStyle="DropDownList" DataSourceID="dsSucursales"
                                                    AutoCompleteMode="Suggest" MaxLength="0" Style="display: inline;">
                                                </asp:ComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="#Comentario"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComentarios" runat="server" Text='<%#Bind("Comentario")%>' TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="#MI0001,#Comentario"
                                                    ControlToValidate="txtComentarios" Text="*" CssClass="failureNotification" ValidationGroup="ValidarDatos"></asp:RequiredFieldValidator>
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
