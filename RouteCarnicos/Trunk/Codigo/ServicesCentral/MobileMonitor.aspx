<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MobileMonitor.aspx.vb" Inherits="MobileMonitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Mobile Monitor</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="dlCarpetas" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" RepeatColumns="5">
            <ItemTemplate>
                <asp:HyperLink ID="hypCarpeta" runat="server" Text='<%# Eval("Name") %>' NavigateUrl='<%# "MobileMonitorV.aspx?c=" + Eval("Name").ToString()  %>' Target="_self"></asp:HyperLink>
            </ItemTemplate>
            <FooterStyle BackColor="#CCCCCC" />
            <ItemStyle BackColor="White" BorderWidth="10px" />
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </div>
    </form>
</body>
</html>
