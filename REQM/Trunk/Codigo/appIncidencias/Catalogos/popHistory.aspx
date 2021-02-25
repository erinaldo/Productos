<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popHistory.aspx.vb" Inherits="appIncidencias.popHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<base  target="_self" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblTitle" CssClass="Title" runat="server" Text="Historial"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="center">
            <asp:GridView ID="gvHistorial" runat="server">
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
        
        <tr>
            <td align="center">
                <asp:Button ID="btnClose" runat="server" Text="Cerrar" />
            </td>
        </tr>
        
        
    </table>
    
    </div>
    </form>
</body>
</html>
