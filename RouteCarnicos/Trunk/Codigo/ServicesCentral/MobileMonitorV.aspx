<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MobileMonitorV.aspx.vb"
    Inherits="MobileMonitorV" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mobile Monitor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <%= Request("c")%>
            </h3>
            <a href="MobileMonitor.aspx">Regresar</a>
            <br />
            <br />
            <asp:LinkButton ID="LinkButton1" runat="server">Actualizar</asp:LinkButton>
            <br />
            <br />
            <asp:DataList ID="dlErrores" runat="server" CellPadding="4" ForeColor="#333333">
                <ItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandArgument='<%# Eval("Name")%>'
                        CommandName="Detalles">Detalles</asp:LinkButton>
                    <asp:LinkButton ID="lnkEjecutar" runat="server" CommandArgument='<%# Eval("Name")%>'
                        CommandName="Ejecutar">Ejecutar</asp:LinkButton>
                </ItemTemplate>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderTemplate>
                    Fallidos
                </HeaderTemplate>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandName="Cerrar">Cerrar</asp:LinkButton>
                    &nbsp
                    <asp:DataList ID="dlDetalle" runat="server" CellPadding="4" ForeColor="#333333">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>:
                            <asp:Label ID="fldFecha" runat="server" Text='<%# Eval("FechaHora") %>'></asp:Label>
                            <asp:Label ID="lblMensaje" runat="server" Text="Descripcion"></asp:Label>:
                            <asp:Label ID="fldMensaje" runat="server" Text='<%# Eval("Mensaje") %>'></asp:Label>
                            <asp:Label ID="lblPar1" runat="server" Text="Parametro FechaInicio"></asp:Label>:
                            <asp:Label ID="fldPar1" runat="server" Text='<%# Eval("FechaInicio") %>'></asp:Label>
                            <asp:Label ID="lblPar2" runat="server" Text="Parametro FechaPrimerDia"></asp:Label>:
                            <asp:Label ID="fldPar2" runat="server" Text='<%# Eval("FechaPrimerDia") %>'></asp:Label>
                            <br />
                            <asp:Label ID="lblNotas" runat="server" Text="Notas"></asp:Label>:
                            <asp:Label ID="fldNotas" runat="server" Text='<%# Eval("Notas") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                </SelectedItemTemplate>
            </asp:DataList><br />
            <asp:DataList ID="dlProcesando" runat="server" CellPadding="4" ForeColor="#333333">
                <ItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandArgument='<%# Eval("Name")%>'
                        CommandName="Detalles">Detalles</asp:LinkButton>
                </ItemTemplate>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderTemplate>
                    En Proceso
                </HeaderTemplate>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandName="Cerrar">Cerrar</asp:LinkButton>
                    &nbsp
                    <asp:DataList ID="dlDetalle" runat="server" CellPadding="4" ForeColor="#333333">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>:
                            <asp:Label ID="fldFecha" runat="server" Text='<%# Eval("FechaHora") %>'></asp:Label>
                            <asp:Label ID="lblMensaje" runat="server" Text="Descripcion"></asp:Label>:
                            <asp:Label ID="fldMensaje" runat="server" Text='<%# Eval("Mensaje") %>'></asp:Label>
                            <asp:Label ID="lblPar1" runat="server" Text="Parametro FechaInicio"></asp:Label>:
                            <asp:Label ID="fldPar1" runat="server" Text='<%# Eval("FechaInicio") %>'></asp:Label>
                            <asp:Label ID="lblPar2" runat="server" Text="Parametro FechaPrimerDia"></asp:Label>:
                            <asp:Label ID="fldPar2" runat="server" Text='<%# Eval("FechaPrimerDia") %>'></asp:Label>
                            <br />
                            <asp:Label ID="lblNotas" runat="server" Text="Notas"></asp:Label>:
                            <asp:Label ID="fldNotas" runat="server" Text='<%# Eval("Notas") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                </SelectedItemTemplate>
            </asp:DataList>
            <br />
            <asp:DataList ID="dlTerminados" runat="server" CellPadding="4" ForeColor="#333333"
                DataKeyField="Name">
                <ItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandArgument='<%# Eval("Name")%>'
                        CommandName="Detalles">Detalles</asp:LinkButton>
                </ItemTemplate>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderTemplate>
                    Terminados
                </HeaderTemplate>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedItemTemplate>
                    <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>:
                    <asp:Label ID="flbClave" runat="server" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Name").ToString())%>'></asp:Label>
                    <asp:LinkButton ID="lnkDetalles" runat="server" CommandName="Cerrar">Cerrar</asp:LinkButton>
                    &nbsp
                    <asp:DataList ID="dlDetalle" runat="server" CellPadding="4" ForeColor="#333333">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>:
                            <asp:Label ID="fldFecha" runat="server" Text='<%# Eval("FechaHora") %>'></asp:Label>
                            <asp:Label ID="lblMensaje" runat="server" Text="Descripcion"></asp:Label>:
                            <asp:Label ID="fldMensaje" runat="server" Text='<%# Eval("Mensaje") %>'></asp:Label>
                            <asp:Label ID="lblPar1" runat="server" Text="Parametro FechaInicio"></asp:Label>:
                            <asp:Label ID="fldPar1" runat="server" Text='<%# Eval("FechaInicio") %>'></asp:Label>
                            <asp:Label ID="lblPar2" runat="server" Text="Parametro FechaPrimerDia"></asp:Label>:
                            <asp:Label ID="fldPar2" runat="server" Text='<%# Eval("FechaPrimerDia") %>'></asp:Label>
                            <br />
                            <asp:Label ID="lblNotas" runat="server" Text="Notas"></asp:Label>:
                            <asp:Label ID="fldNotas" runat="server" Text='<%# Eval("Notas") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataList>
                </SelectedItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
