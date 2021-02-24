<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Costos.aspx.cs" Inherits="RegistroTiemposLaborales.Costos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="width: 100%">
        <center>
            <img alt="" src="images/logo_amesol_horizontal.jpg" />
            <br />
            <a href="Default.aspx">
                <img style="border: 0" alt="" src="images/home.png" /></a>
            <br />
            <asp:UpdatePanel ID="updRecusos" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Repeater ID="repRecursos" runat="server" OnItemCommand="repRecursos_ItemCommand">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: left" colspan="3">
                                        <asp:ValidationSummary ID="sumarioAgregar" runat="server" ValidationGroup="Agregar" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtUsuario" runat="server" ToolTip="Usuario del ActiveDirectory"
                                            Text="">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El usuario es requerido"
                                            ControlToValidate="txtUsuario" ValidationGroup="Agregar" Text="*"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="valUsuarioAgr" runat="server" ErrorMessage="El usuario ya existe"
                                            ControlToValidate="txtUsuario" OnServerValidate="valUsuarioAgr_ServerValidate"
                                            ValidationGroup="Agregar">*</asp:CustomValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCosto" runat="server" ToolTip="Costo por hora" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El costo es requerido"
                                            ControlToValidate="txtCosto" ValidationGroup="Agregar" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="El valor tiene que ser valor numerico mayor que 0"
                                            MaximumValue="10000" MinimumValue="1" Type="Currency" ValidationGroup="Agregar"
                                            ControlToValidate="txtCosto">*</asp:RangeValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CommandName="Agregar" ValidationGroup="Agregar" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        Usuario
                                    </th>
                                    <th>
                                        Costo por hora Anterior
                                    </th>
                                    <th>
                                        Costo por hora Actual
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Label ID="lblUsuario" runat="server" Text='<%#Eval("Usuario")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAnterior" runat="server" Text='<%#Eval("Costo")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNuevo" runat="server" Text='<%#Eval("Costo")%>'></asp:TextBox>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
    </form>
</body>
</html>
