<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Barra.ascx.vb" Inherits="WebAPLBaseAPP.Barra" %>
<%@ Register Assembly="Janus.Web.GridEX.v3" Namespace="Janus.Web.GridEX" TagPrefix="jwg" %>
<%@ Register Assembly="Janus.Web.UI.v3" Namespace="Janus.Web.UI.CommandBars" TagPrefix="jwucb" %>

<script runat="server">

Protected Sub UiCommandManager1_CommandClick(ByVal sender As Object, ByVal e As Janus.Web.UI.CommandBars.CommandEventArgs)
        Dim x As Integer = 0
End Sub
</script>

<jwucb:UICommandManager ID="UiCommandManager1" runat="server" VisualStyle="Office2003Blue" OnCommandClick="UiCommandManager1_CommandClick">
<ClientEvents   CommandClick="commandManager_CommandClick"></ClientEvents>
<CommandBars>
<jwucb:UICommandBar FormatStyle-Font-Size="Smaller" FormatStyle-Font-Names="Arial" Key="CommandBar1"><Commands>
<jwucb:UICommand Image="~\images\atras.png" Text="Atras" Key="btnBack" Width="60px">
<StateStyles>
<FormatStyle Font-Size="Smaller" Font-Names="Arial"></FormatStyle>
</StateStyles>
</jwucb:UICommand>
<jwucb:UICommand Image="~\images\Actualizar.png" Text="Refrescar" Key="btnRefresh" >
<StateStyles>
<FormatStyle Font-Size="Smaller" Font-Names="Arial"></FormatStyle>
</StateStyles>
</jwucb:UICommand>
<jwucb:UICommand Image="~\images\Salir.png" Text="Salir" Key="btnLogout"  Width="80px">
<StateStyles>
<FormatStyle Font-Size="Smaller" Font-Names="Arial"></FormatStyle>
</StateStyles>
</jwucb:UICommand>
<jwucb:UICommand Image="~\images\AcercaDe.png" Text="Acerca De" Key="btnAcerca" >
<StateStyles>
<FormatStyle Font-Size="Smaller" Font-Names="Arial"></FormatStyle>
</StateStyles>
</jwucb:UICommand>
</Commands>
</jwucb:UICommandBar>
</CommandBars>
</jwucb:UICommandManager>
