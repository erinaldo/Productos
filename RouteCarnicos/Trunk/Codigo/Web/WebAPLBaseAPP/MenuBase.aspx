<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MenuBase.aspx.vb" Inherits="TEST" %>
<%@ Register Assembly="Janus.Web.UI.v3" Namespace="Janus.Web.UI.Dock" TagPrefix="jwu" %>

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
<script type="text/javascript" src="./resize.js" language="javascript"></script>
<title>AMESOL WEBApl base</title>
<link href="./janus.css" rel="stylesheet" type="text/css" />
<a href="AcercaDe.aspx">
<script language="javascript">

function commandManager_CommandClick(command)
{
if (command.Key=="btnLogout")
{

window.location="Login.aspx";
}

if (command.Key=="btnAcerca")
{
window.open("AcercaDe.aspx","min","width=480 height=240");
}

if (command.Key=="btnRefresh")
{

var vCurrentPage;
var manager = getObjectManager("UiPanelManager1");
var panel = manager.GetPanelFromKey("uiPanelContenido");
var element = document.getElementById(panel.ID);
vCurrentPage=document.getElementById("CurrentPage");
panel.ShowInnerFrame(null, vCurrentPage.value);

}

if (command.Key=="btnBack")
{
    wback();
        
}

}

function ShowActivity(Nombre, Pagina)
{
var manager = getObjectManager("UiPanelManager1");
var panel = manager.GetPanelFromKey("uiPanelContenido");
var element = document.getElementById(panel.ID);

panel.SetCaption(Nombre);
panel.ShowInnerFrame(null, Pagina);

var vCurrentPage;
vCurrentPage=document.getElementById("CurrentPage");
vCurrentPage.value=Pagina;

}

function wback()
{
var manager = getObjectManager("UiPanelManager1");
var panel = manager.GetPanelFromKey("uiPanelContenido");
var element = panel.GetInnerContainerElement();
var xwnd = element.contentWindow;

if(xwnd != null)
{
if(xwnd.window != null)
xwnd = xwnd.window;
xwnd.history.back();

}
}
</script>
</a>
</head>
<body bgcolor="#ffffff">
<form id="form1" runat="server">
<table class="janusAreaTable" id="TABLE1">
<tr id="xr" class="janusAreaTable">
<td class="janusAreaTable" style="width: 100%">
<div class="janusControlDiv">
<jwu:uiPanelManager id="UiPanelManager1" style="Z-INDEX: 101; LEFT: 0px; POSITION: relative; TOP: 0px" runat="server" Width="100%" Height="100%" Font-Size="9pt" Font-Names="Tahoma">
<DefaultPanelSettings BorderCaptionColor="0, 45, 150" CaptionStyle="Dark" BorderPanelColor="0, 45, 150" CaptionDisplayMode="Text">
<TabStateStyles>
<FormatStyle FontBold="True"></FormatStyle>
</TabStateStyles>
<DarkCaptionFormatStyle Font-Size="11pt" Font-Names="Arial"></DarkCaptionFormatStyle>
</DefaultPanelSettings>
</jwu:uiPanelManager>
</div>
</td>
</tr>
</table>
<input type=hidden  id=CurrentPage name=CurrentPage value="splash.aspx"/>
</form>
</body>
</html> 