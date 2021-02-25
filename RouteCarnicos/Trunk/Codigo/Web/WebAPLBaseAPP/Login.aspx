<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Assembly="Janus.Web.UI.v3" Namespace="Janus.Web.UI.Dock" TagPrefix="jwu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AMESOL Login</title>
</head>
<body>
      <form id="form1" runat="server">
      
    <div>
        <table id="Table1" border="0" cellpadding="1" cellspacing="0" style="z-index: 101;left: 8px; position: absolute; top: 8px; height:100%" width="100%">
            <tr>
                <td style="font-size: 9pt; width: 565px; font-family: tahoma; height: 16px" valign="top">
                    <p id="P1" runat="server">
                        <img alt="" height="0" src="images\Route.jpg" width="0" /><img alt="" height="0"
                            src="images\route.jpg" width="0" /><img alt="" src="images/RouteLogo.jpg" />&nbsp;</p>
                </td>
            </tr>
            <tr>
                <td style="font-size: 9pt; width: 565px; font-family: tahoma; height: 189px"
                    valign="top">
                    <p id="P2" runat="server">
                        <br />
                        <jwu:UIPanelManager ID="UiPanelManager1" runat="server" Width="380px">
<GroupPanel Key="uiPanel0" Text="AMESOL ROUTE" Width="100%" Height="100%" SelectedPanelIndex="0" GroupStyle="VerticalTiles"><Panels>
<jwu:UIPanel InnerContainerUserControlUrl="~\UserControls\Login.ascx" InnerContainerType="UseUserControlUrl" Text="Login" CaptionStyle="Dark" Key="uiPanel1"></jwu:UIPanel>
</Panels>
</GroupPanel>

<DefaultPanelSettings BorderCaptionColor="0, 45, 150" BorderPanelColor="0, 45, 150"></DefaultPanelSettings>
</jwu:UIPanelManager>&nbsp;</p>
                </td>
            </tr>
            <tr>
                <td style="width: 565px; height:100%" valign="top">
                </td>
            </tr>
        </table>
        &nbsp;
    
    </div>
    </form>

</body>
</html>
