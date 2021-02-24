<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RegistroTiemposLaborales.Login"
    Theme="TemaRoute" %>

<%@ Register Src="Controles/Login.ascx" TagName="Login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
</head>
<body>
    <center>
        <form id="form1" runat="server" defaultfocus="form1">
        <div>
            <table id="Table1" align="center" style="z-index: 101; left: 8px; position: absolute;
                top: 8px" width="100%">
                <tr style="text-align: center">
                    <td style="font-size: 9pt; font-family: tahoma; height: 16px" valign="top">
                        <p id="P1" runat="server">
                            <img alt="" src="images/logo_amesol_horizontal.jpg" />&nbsp;&nbsp;</p>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td height="189" style="font-size: 9pt; font-family: tahoma; vertical-align: top">
                        <center>
                            <p id="P2" runat="server">
                                <uc1:Login ID="Login2" runat="server" />
                                &nbsp;<br />
                                &nbsp;</p>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td height="*" style="width: 565px" valign="top">
                    </td>
                </tr>
            </table>
            &nbsp;
        </div>
        </form>
    </center>
</body>
</html>
