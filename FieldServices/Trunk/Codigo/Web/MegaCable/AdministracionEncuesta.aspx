<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionEncuesta.aspx.cs" Inherits="AdministracionEncuesta" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Cotroles/cPreguntaOpcion.ascx" TagName="cPreguntaOpcion" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
        });
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#CrearEncuesta"></asp:Label>
            </h1>
        </div>
    </div>
    <div>
        <table class="navegacion">
            <tr>
                <td>
                    <asp:Label ID="lblClave" runat="server" Text="#Clave"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtClave" runat="server" ValidationGroup="ValidarDatosProporcionados"
                        MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClave"
                        CssClass="failureNotification" ErrorMessage="#MI0001,#Clave" ToolTip="#MI0001,#Clave"
                        ValidationGroup="ValidarDatosProporcionados" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblTipo" runat="server" Text="#Tipo"></asp:Label>
                </td>
                <td>
                    <asp:ComboBox ID="cmbTipo" runat="server" DropDownStyle="DropDownList" BorderColor="#B3B3FF"
                        BorderStyle="Solid" BorderWidth="1px" Width="200px" AutoCompleteMode="Suggest">
                    </asp:ComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNombre" runat="server" Text="#Nombre"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="ValidarDatosProporcionados"
                        Width="400px" MaxLength="150"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                        CssClass="failureNotification" ErrorMessage="#MI0001,#Nombre" ToolTip="#MI0001,#Nombre"
                        ValidationGroup="ValidarDatosProporcionados" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:CheckBox ID="chkActivo" runat="server" Text="#Activo" Checked="true" />
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="upContenido" runat="server">
            <ContentTemplate>
                <asp:LinqDataSource ID="dsPreguntas" runat="server" OnSelecting="dsPreguntas_Selecting">
                </asp:LinqDataSource>
                <asp:LinqDataSource ID="dsTiposPregunta" runat="server" OnSelecting="dsTiposPregunta_Selecting">
                </asp:LinqDataSource>
                <div style="overflow: auto; height: 330px">
                    <asp:ListView ID="dlPreguntas" runat="server" OnItemCommand="dlPreguntas_ItemCommand"
                        DataKeyNames="IdPregunta" OnItemInserting="dlPreguntas_ItemInserting" DataSourceID="dsPreguntas"
                        OnItemDataBound="dlPreguntas_ItemDataBound" OnItemUpdating="dlPreguntas_ItemUpdating"
                        OnItemEditing="dlPreguntas_ItemEditing" OnDataBound="dlPreguntas_DataBound">
                        <LayoutTemplate>
                            <asp:Panel ID="Panel1" runat="server">
                                <table class="navegacion">
                                    <tr class="navegacion">
                                        <td>
                                            <asp:ImageButton CommandName="NuevaPregunta" ID="btnInsert" runat="server" ToolTip="#NuevoRegistro"
                                                ImageUrl="~/img/Nuevo.jpg" Style="width: 16px" />
                                        </td>
                                        <th class="navegacion">
                                            <asp:Label ID="titPregunta" runat="server" Text="#Pregunta"></asp:Label>
                                        </th>
                                        <th class="navegacion">
                                            <asp:Label ID="titTipo" runat="server" Text="#Tipo"></asp:Label>
                                        </th>
                                        <th style = "width:80px;">
                                            <asp:ImageButton ID="btnSubir" runat="server" CommandName="Subir" ImageUrl="~/img/up.png" />
                                            <asp:ImageButton ID="btnBajar" runat="server" CommandName="Bajar" ImageUrl="~/img/down.png" />
                                        </th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder" />
                                </table>
                            </asp:Panel>
                        </LayoutTemplate>
                        <EmptyDataTemplate>
                            <table class="navegacion">
                                <tr class="navegacion">
                                    <td>
                                        <asp:ImageButton CommandName="NuevaPregunta" ID="btnInsert" runat="server" ToolTip="#NuevoRegistro"
                                            ImageUrl="~/img/Nuevo.jpg" Style="width: 16px" />
                                    </td>
                                    <th class="navegacion">
                                        <asp:Label ID="titPregunta" runat="server" Text="#Pregunta"></asp:Label>
                                    </th>
                                    <th class="navegacion">
                                        <asp:Label ID="titTipo" runat="server" Text="#Tipo"></asp:Label>
                                    </th>
                                    <th style="width: 40px;">
                                    </th>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <ItemTemplate>
                            <tr class="navegacion">
                                <td style="width: 20px;">
                                </td>
                                <td class="navegacion">
                                    <%# Eval("Descripcion") %>
                                </td>
                                <td class="navegacion">
                                    <%# Eval("ValorReferencia.Descripcion")%>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandName="Edit" CommandArgument='<%#Eval("idPregunta") %>'
                                        ImageUrl="~/img/Editar.jpg" ToolTip="#Editar" Visible='<%#  ((Guid)Eval("idPregunta")==Guid.Empty? false:true) %>' />
                                    <asp:ImageButton ID="btnSeleccionar" runat="server" CommandName="Select" CommandArgument='<%#Eval("idPregunta") %>'
                                        ImageUrl="~/img/select.png" ToolTip="#Seleccionar" Visible='<%#  ((Guid)Eval("idPregunta")==Guid.Empty? false:true) %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <SelectedItemTemplate>
                            <tr class="navegacionSel">
                                <td style="width: 20px;">
                                </td>
                                <td class="navegacion">
                                    <%# Eval("Descripcion") %>
                                </td>
                                <td class="navegacion">
                                    <%# Eval("ValorReferencia.Descripcion")%>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandName="Edit" CommandArgument='<%#Eval("idPregunta") %>'
                                        ImageUrl="~/img/Editar.jpg" ToolTip="#Editar" Visible='<%#  ((Guid)Eval("idPregunta")==Guid.Empty? false:true) %>' />
                                </td>
                            </tr>
                        </SelectedItemTemplate>
                        <EditItemTemplate>
                            <tr class="navegacion">
                                <td style="width: 20px;">
                                </td>
                                <td class="navegacion" colspan="2">
                                    <asp:Panel ID="pnlEditarPregunta" runat="server" DefaultButton="btnActualizar">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPregunta" runat="server" Text="#Pregunta"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPregunta" Text='<%#Bind("Descripcion") %>' MaxLength="250" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Pregunta"
                                                        ToolTip="#MI0001,#Pregunta" ControlToValidate="txtPregunta" ValidationGroup="ValidarDatos"
                                                        CssClass="failureNotification" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTipo" runat="server" Text="#Tipo"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ComboBox ID="cmbTipoPreg" runat="server" DropDownStyle="DropDownList" DataSourceID="dsTiposPregunta"
                                                        BorderColor="#B3B3FF" BorderStyle="Solid" BorderWidth="1px" Width="200px" AutoCompleteMode="Suggest"
                                                        DataValueField="Valor" DataTextField="Descripcion" SelectedValue='<%#Bind("TipoPregunta") %>'
                                                        OnSelectedIndexChanged="cmbTipoPreg_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:ComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                    <uc1:cPreguntaOpcion ID="PreguntaOpcion1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right">
                                                    <asp:ImageButton ID="btnActualizar" runat="server" CommandName="Update" ImageUrl="~/img/Update.jpg"
                                                        ToolTip="#Actualizar" ValidationGroup="ValidarDatos" />
                                                    <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                        ToolTip="#Cancelar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr class="navegacion">
                                <td style="width: 20px;">
                                </td>
                                <td class="navegacion" colspan="2">
                                    <asp:Panel ID="pnlInsertarPregunta" runat="server" DefaultButton="btnActualizar">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblPregunta" runat="server" Text="#Pregunta"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPregunta" Text='<%#Bind("Descripcion") %>' MaxLength="250" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="#MI0001,#Pregunta"
                                                        ToolTip="#MI0001,#Pregunta" ControlToValidate="txtPregunta" ValidationGroup="ValidarDatos"
                                                        CssClass="failureNotification" Text="*"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTipo" runat="server" Text="#Tipo"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ComboBox ID="cmbTipoPreg" runat="server" DropDownStyle="DropDownList" DataSourceID="dsTiposPregunta"
                                                        BorderColor="#B3B3FF" BorderStyle="Solid" BorderWidth="1px" Width="200px" AutoCompleteMode="Suggest"
                                                        DataValueField="Valor" DataTextField="Descripcion" SelectedValue='<%#Bind("TipoPregunta") %>'
                                                        OnSelectedIndexChanged="cmbTipoPreg_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:ComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td colspan="3">
                                                    <uc1:cPreguntaOpcion ID="PreguntaOpcion1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: right">
                                                    <asp:ImageButton ID="btnActualizar" runat="server" CommandName="Insert" ImageUrl="~/img/Update.jpg"
                                                        ToolTip="#Insertar" ValidationGroup="ValidarDatos" />
                                                    <asp:ImageButton ID="btnCancelar" runat="server" CommandName="Cancel" ImageUrl="~/img/Delete.jpg"
                                                        ToolTip="#Cancelar" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </InsertItemTemplate>
                    </asp:ListView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: right; padding: 5px 70px 5px 70px;">
            <asp:UpdatePanel ID="updComandos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                <ContentTemplate>
                    <asp:ImageButton ID="imgAceptar" runat="server" ImageUrl="~/img/AceptarGrande.jpg"
                        OnClick="imgAceptar_Click" ValidationGroup="ValidarDatosProporcionados" ToolTip="#Aceptar" />
                    &nbsp &nbsp &nbsp
                    <asp:ImageButton ID="imgCancelar" runat="server" ImageUrl="~/img/CancelarGrande.jpg"
                        OnClick="imgCancelar_Click" ToolTip="#Cancelar" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
