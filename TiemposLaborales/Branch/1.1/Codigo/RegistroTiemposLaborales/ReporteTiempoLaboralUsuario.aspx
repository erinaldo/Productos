<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteTiempoLaboralUsuario.aspx.cs"
    Inherits="RegistroTiemposLaborales.ReporteTiempoLaboralUsuario" StylesheetTheme="TemaRoute" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title>Tiempo Laboral Por Usuario</title>
    <style type="text/css">
        .style1
        {
            width: 140px;
        }
        .style3
        {
            width: 280px;
        }
        .style4
        {
            width: 60px;
        }
        html, body, form
        {
            margin: 0px;
            height: 100%;
        }
    </style>
</head>
<body style="background-image: url('images/amesol_duxtar.jpg'); background-attachment: fixed;
    background-repeat: no-repeat; background-position: bottom right">
    <form id="form1" runat="server">
    <table style="width:100%">
        <tr>
            <td style="vertical-align: top">
                <div>
                    <asp:ScriptManager ID="Scriptmanager1" runat="server">
                    </asp:ScriptManager>
                    <center>
                        <center>
                            <img alt="" src="images/logo_amesol_horizontal.jpg" />
                            <br />
                            <asp:HyperLink ID="LinkAtras" runat="server" ImageUrl="Images/ReporteM.png" Target="_self"
                    ToolTip="Atras">Atras</asp:HyperLink>
                <asp:HyperLink ID="LinkHome" runat="server" ImageUrl="Images/home.png" Target="_self"
                    ToolTip="Home">Home</asp:HyperLink>
                    <br />
                        </center>
                        <br />
                        <center style="display: inline">
                            <h2>
                                <asp:Label ID="LabelUsuario" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:Label ID="LabelFechas" runat="server" Text=""></asp:Label>
                            </h2>
                        </center>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelGrid" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <br />
                                <br />
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                        CellSpacing="2" AutoGenerateColumns="false" OnRowCreated="GridView1_RowCreated">
                                        <Columns>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                            <asp:BoundField DataField="Horas" HeaderText="Horas" />
                                            <asp:BoundField DataField="HorasRegistradas" HeaderText="Horas Registradas" />
                                        </Columns>
                                        <RowStyle CssClass="FilaGrid" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle CssClass="CabezeraGrid" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <AlternatingRowStyle CssClass="FilaGrid2" />
                                    </asp:GridView>
                                </center>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </center>
                </div>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>
