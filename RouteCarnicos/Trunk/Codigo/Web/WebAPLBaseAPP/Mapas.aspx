<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mapas.aspx.vb" Inherits="Mapas" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head runat="server">
    <style type="text/css">
v\:* { behavior:url(#default#VML); }
</style>
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 200px; background-image: url(images/FondoDegradado.gif);
            background-position-y: top; background-repeat: repeat-x;">
            <table>
                <tr>
                    <td>
                        <img alt="" src="images/MapasWeb.png" />
                    </td>
                    <td>
                        <asp:Label ID="lbMapasW" runat="server" Text="Mapas Web" Font-Names="Arial" Font-Size="24pt"
                            Font-Bold="true" ForeColor="#191c1f"></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="padding-left: 20px;">
                <asp:Literal ID="litPopUp" runat="server"></asp:Literal>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                         <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            &nbsp;<table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                vertical-align: top; border-top-style: none; padding-top: 0px; border-right-style: none;
                                border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbMapa" runat="server" Text="Mapa" Font-Bold="True" Font-Names="Arial"
                                            Font-Overline="False" Font-Strikeout="False" Font-Size="10pt" Width="200px"></asp:Label></td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCentroD" runat="server" Text="Centro Distribucion" Width="200px"
                                            Font-Bold="True" Font-Names="Arial" Font-Overline="False" Font-Size="10pt" Font-Strikeout="False"></asp:Label></td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlMapa" runat="server" Width="100%">
                                        </asp:DropDownList></td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCentroD" runat="server" Width="100%" >
                                        </asp:DropDownList></td>
                                        <td style="width: 20px">
                                    </td>
                                        <td>
                                        &nbsp;
                                       </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbRuta" runat="server" Text="Ruta" Font-Bold="True" Font-Names="Arial"
                                            Font-Size="10pt" Font-Overline="False" Font-Strikeout="False" Width="200px"></asp:Label></td>
                                    <td style="width: 20px">
                                    </td>
                                    <td>
                                        <table style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
                                            vertical-align: top; border-top-style: none; padding-top: 0px; border-right-style: none;
                                            border-left-style: none; border-collapse: collapse; border-bottom-style: none">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbFecha" runat="server" Text="Fecha" Font-Bold="True" Font-Names="Arial"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Size="10pt" Width="200px"></asp:Label></td>
                                                <tr>
                                        </table>
                                    </td>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DDlRutas" runat="server" >
                                            </asp:DropDownList></td>
                                        <td style="width: 20px">
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFInicio" runat="server" Font-Names="Arial" Font-Size="10pt" Width="100px" ></asp:TextBox>
                                            <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="8pt" Text="dd/mm/aaaa"
                                                ForeColor="Gray"></asp:Label></td>
                                    </tr>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="A1" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtFInicio" OnClientDateSelectionChanged=" hideCalendar">
                            </cc1:CalendarExtender>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                                        <asp:Button ID="Button1" runat="server" Text="Ver Mapa" OnClick="Button1_Click" />
            </div>
        </div>
              <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
            <progresstemplate>
                <div id="Update">
            <div style="position: fixed; top: 0px; left: 0px; width: 100%; height: 100%; background-color: #FFFFFF">
            </div>
            <div style="position: fixed; top: 35%; left: 45%">
                <img alt="" src="images/loader2.gif" /></div>
        </div>
            </progresstemplate>
        </asp:UpdateProgress>
        &nbsp;
       
        
         
    </form>
</body>
</html>
