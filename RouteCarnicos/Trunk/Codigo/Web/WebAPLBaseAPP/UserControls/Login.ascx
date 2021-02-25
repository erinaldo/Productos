<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login.ascx.vb" Inherits="UserControls_Login" %>
<table id="Table1" border="0" cellpadding="0" cellspacing="0" style="width: 360px;
    height: 109px" width="360">
    <tr>
        <td style="width: 65px">
            <p align="right">
                <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="X-Small">Usuario</asp:Label></p>
        </td>
        <td style="width: 13px">
        </td>
        <td>
            <asp:TextBox ID="ebLogin" runat="server" Width="152px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 65px; height: 28px">
            <p align="right">
                <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="X-Small">Password</asp:Label></p>
        </td>
        <td style="width: 13px; height: 28px">
        </td>
        <td style="height: 28px">
            <asp:TextBox ID="ebPassword" runat="server" TextMode="Password" Width="152px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 65px">
        </td>
        <td style="width: 13px">
        </td>
        <td>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Aceptar" /><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ebLogin"
                    ErrorMessage="Favor de Capturar los campos" Font-Names="Verdana" Font-Size="X-Small"></asp:RequiredFieldValidator><br />
                <asp:Label ID="lblError" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    ForeColor="Red"></asp:Label>&nbsp;</p>
        </td>
    </tr>
</table>
