<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="appIncidencias.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 785px;
        }
    </style>
</head>
<body style="background-image:url('./Imagenes/Fondo Amesol2.jpg'); background-repeat:no-repeat; background-position:bottom; background-color: #107AC6;">
    <form id="form1" runat="server">
    <div>
        <table width="100%">
            <%--<tr>
                <td>
                    
                </td>
            </tr>--%>
            <tr>
                <td align="center" valign="middle" colspan="2" class="style1">
                   <table width="30%" 
                        
                        
                        
                        style="border: thin solid #107AC6; border-collapse: collapse; border-spacing: 0px;">
                        <tr>
                            <td style="background-position: center center; background-image: url('Imagenes/fondoo.gif'); background-repeat: repeat-x; color: #FFFFFF; font-weight: bold;" 
                                colspan="2">
                                
                                <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                
                                <asp:Label ID="Label1" runat="server" Text="Usuario:" Font-Bold="True" 
                                    ForeColor="White"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                
                                <asp:TextBox ID="txtUser" runat="server" TabIndex="1" Width="270px" 
                                    ValidationGroup="login"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtUser" ErrorMessage="*" ValidationGroup="login"></asp:RequiredFieldValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                
                                <asp:Label ID="Label2" runat="server" Text="Password:" Font-Bold="True" 
                                    ForeColor="White"></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                
                                <asp:TextBox ID="txtPassword" runat="server" TabIndex="2" TextMode="Password" 
                                    Width="270px" ValidationGroup="login"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="login"></asp:RequiredFieldValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               
                                <asp:Label ID="lblMensage" runat="server" Font-Bold="True" ForeColor="Red" 
                                    Text="No se pudo encontrar usuario con ese password. Verificar" Visible="False"></asp:Label>
                               
                            </td>
                            
                        </tr>
                        <tr>
                            <td colspan="1">
                                <asp:Button ID="btnEnter" runat="server" Text="Entrar" BackColor="#107AC6" 
                                    Font-Bold="True" Font-Size="Medium" ForeColor="White" 
                                    ValidationGroup="login" />
                            </td>
                            
                   </table> 
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
