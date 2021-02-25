<%@ Page Language="vb" AutoEventWireup="false" Codebehind="splash.aspx.vb" Inherits="WebAPLBaseAPP.WebForm1" %>

<%@ Register Src="~\UserControls\Barra.ascx" TagName="Barra" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
       
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="height: 640px; width: 100%; vertical-align: middle; text-align: center">
            <tr>
                <td>
                    <img alt="" src="images/RouteDegradado.png" />
                </td>
            </tr>
        </table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </form>
</body>
</html>
