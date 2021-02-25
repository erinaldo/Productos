<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PopUpMapas.aspx.vb" Inherits="PopUpMapas" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head id="Head1" runat="server">
    <style type="text/css">
v\:* { behavior:url(#default#VML); }
</style>
    <title>Untitled Page</title>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <table style="padding-right: 0px; padding-left: 0px; font-size: xx-small; padding-bottom: 0px;
                margin: 0px; vertical-align: top; border-top-style: none; padding-top: 0px; border-right-style: none;
                border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                <tr>
                    <td rowspan="4">
                        <cc1:GMap ID="GMap1" runat="server" Height="700px" Width="700px" />
                    </td>
                    <td style="vertical-align: top; text-align: center; background-image: url(images/Barra1.GIF);
                        color: white; background-color: transparent;" colspan="2">
                        <asp:Label ID="lbCapas" runat="server" Text="Capas" Font-Bold="True" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; background-image: url(images/Barra2.GIF); color: black;
                        background-color: transparent;">
                        <asp:Label ID="LbClientes" runat="server" Text="Clientes" Font-Size="Small"></asp:Label></td>
                    <td style="background-image: url(images/Barra2.GIF); color: black; background-color: transparent;">
                        <asp:Label ID="LbTrayectorias" runat="server" Text="Trayectorias" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">
                        <asp:Panel ID="pnlCli" runat="server" Height="600px">
                            <asp:DataList ID="DataList1" runat="server" Width="8px">
                                <ItemTemplate>
                                <table>
                                <tr>
                                <td><asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# eval("Seleccionado") %>' visible='<%# eval("CheckVisible") %>'/></td>
                                <td> <asp:Panel
                                        ID="Panel1" runat="server" BorderWidth="1px" BorderColor="black" BackColor='<%# eval("Color") %>' Height="5px" Width="5px">
                                    </asp:Panel></td>
                                <td> <asp:Label ID="Label1" runat="server" Text='<%# eval("nombre") %>'></asp:Label></td>
                                </tr>
                                   
                                   
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></asp:Panel>
                    </td>
                    <td style="vertical-align: top;">
                        <asp:Panel ID="pnlTra" runat="server" Height="600px">
                            <asp:DataList ID="DataList2" runat="server" Width="8px">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# eval("Seleccionado") %>' visible='<%# eval("CheckVisible") %>' /></td>
                                            <td>
                                                <asp:Panel
                                        ID="Panel1" runat="server" BorderWidth="1px" BorderColor="black" BackColor='<%# eval("Color") %>' Height="5px" Width="5px">
                                                </asp:Panel>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%# eval("nombre") %>'></asp:Label></td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList></asp:Panel>
                    </td>
                </tr>
                 <tr>
                
                  <td style="text-align:right;" colspan="2">
                     <asp:Button ID="BtnFiltrarCapas" runat="server" Text="Filtrar Capas" />
                  </td>
                 </tr>
            </table>
        </div>
    </form>
</body>
</html>
