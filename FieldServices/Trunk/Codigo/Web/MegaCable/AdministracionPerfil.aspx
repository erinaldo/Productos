<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="AdministracionPerfil.aspx.cs" Inherits="AdministracionPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=chkSelecTodosAct.ClientID%>").click(function () {
                var chekeados = this.checked;
                $("#<%=chlActividades.ClientID%> input:checkbox").each(function () {
                    this.checked = chekeados;
                });
            });
            $("#<%=chkSelecTodosAsign.ClientID%>").click(function () {
                var chekeados = this.checked;
                $("#<%=chlAsignadas.ClientID%> input:checkbox").each(function () {
                    this.checked = chekeados;
                });
            });
        });
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#CrearPerfil"></asp:Label>
            </h1>
        </div>
    </div>
    <div>
        <table class="navegacion">
            <tr>
                <td>
                    <asp:Label ID="lblPefil" runat="server" Text="#Perfil"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPerfil" runat="server" ValidationGroup="ValidarDatosProporcionados"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPerfil"
                        CssClass="failureNotification" ErrorMessage="#MI0001,#Perfil" ValidationGroup="ValidarDatosProporcionados"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:CheckBox ID="chkActivo" runat="server" Text="#Activo" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDescripcion" runat="server" Text="#Descripcion"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" ValidationGroup="ValidarDatosProporcionados"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescripcion"
                        CssClass="failureNotification" ErrorMessage="#MI0001,#Descripcion" 
                        ValidationGroup="ValidarDatosProporcionados"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <table class="navegacion">
            <tr>
                <td>
                    <asp:Label ID="lblActividades" runat="server" Text="#Actividades"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkSelecTodosAct" runat="server" Text="#SeleccionarTodos" />
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblActividadesAsignadas" runat="server" Text="#ActividadesAsign"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkSelecTodosAsign" runat="server" Text="#SeleccionarTodos" />
                </td>
            </tr>
            <tr>
                <td class="navegacion" colspan="2">
                    <div class="listachecks">
                        <asp:UpdatePanel ID="updActividades" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="chlActividades" runat="server" DataTextField="Nombre" DataValueField="ClaveActividad">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td style="text-align: center;">
                    <asp:UpdatePanel ID="updBotones" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/img/FlechaDer.jpg" OnClick="btnAgregar_Click" />
                            <br />
                            <br />
                            <asp:ImageButton ID="btnQuitar" runat="server" ImageUrl="~/img/FlechaIzq.jpg" OnClick="btnQuitar_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="navegacion" colspan="2">
                    <div class="listachecks">
                        <asp:UpdatePanel ID="updAsignadas" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:CheckBoxList ID="chlAsignadas" runat="server" DataTextField="Nombre"
                                    DataValueField="ClaveActividad">
                                </asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
        <div style="text-align: right; padding: 5px 70px 5px 70px;">
            <asp:UpdatePanel ID="updComandos" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                <ContentTemplate>
                    <asp:CustomValidator ID="customValidator" runat="server" ErrorMessage="" 
                        CssClass="failureNotification" 
                        onservervalidate="customValidator_ServerValidate" 
                        ValidationGroup="ValidarDatosProporcionados"></asp:CustomValidator>
                    <asp:ImageButton ID="imgAceptar" runat="server" ImageUrl="~/img/AceptarGrande.jpg"
                        OnClick="imgAceptar_Click" ToolTip="#Aceptar" ValidationGroup="ValidarDatosProporcionados" />
                    &nbsp &nbsp &nbsp
                    <asp:ImageButton ID="imgCancelar" runat="server" 
                        ImageUrl="~/img/CancelarGrande.jpg" ToolTip="#Cancelar" onclick="imgCancelar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
