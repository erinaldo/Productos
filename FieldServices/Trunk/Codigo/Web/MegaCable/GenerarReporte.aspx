<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerarReporte.aspx.cs" Inherits="GenerarReporte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
    <link href="css/ui-lightness/jquery-ui-1.8.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.treeTable.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery.treeTable.js" type="text/javascript"></script>
    <script src="js/jquery.treeTable.min.js" type="text/javascript"></script>
</head>
<body style="background-color: White; background-image: none;" onunload="Cerrar()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#tablaReporte").treeTable();

            $(window).resize(function () {
                // dimensiones de la ventana del explorer 
                var wscr = $(window).width();
                var hscr = $(window).height();

                // estableciendo dimensiones de fondo
                $('#bgtransparent').css("width", wscr);
                $('#bgtransparent').css("height", hscr);

                // estableciendo tamaño de la ventana modal
                $('#bgmodal').css("width", '600px');
                $('#bgmodal').css("height", '500px');

                // obtiendo tamaño de la ventana modal
                var wcnt = $('#bgmodal').width();
                var hcnt = $('#bgmodal').height();

                // obtener posicion central
                var mleft = (wscr - wcnt) / 2;
                var mtop = (hscr - hcnt) / 2;

                // estableciendo ventana modal en el centro
                $('#bgmodal').css("left", mleft + 'px');
                $('#bgmodal').css("top", mtop + 'px');
            });
        });
        function Cerrar() {
            PageMethods.DescargarReportes('<%=Request["id"]%>');
        }

        function AbrirDetale(ruta) {
            // fondo transparente
                // creamos un div nuevo, con dos atributos
                var bgdiv = $('<div>').attr({
                                        className: 'bgtransparent',
                                        id: 'bgtransparent'
                                        });
                
                // agregamos nuevo div a la pagina
                $('body').append(bgdiv);
                
                // obtenemos ancho y alto de la ventana del explorer
                var wscr = $(window).width();
                var hscr = $(window).height();
                
                //establecemos las dimensiones del fondo
                $('#bgtransparent').css("width", wscr);
                $('#bgtransparent').css("height", hscr);
                
                
                // ventana modal
                // creamos otro div para la ventana modal y dos atributos
                var moddiv = $('<div>').attr({
                                        className: 'bgmodal',
                                        id: 'bgmodal'
                                        });     
                
                // agregamos div a la pagina
                $('body').append(moddiv);

                // agregamos contenido HTML a la ventana modal
                $('#bgmodal').append('<center><iframe width = "600px" height="480px" src="'+ruta+'"></iframe><br/><button onclick="closeModal()">Cerrar</button></center>');
                
                // redimensionamos para que se ajuste al centro y mas
                $(window).resize();

        }
        /*$(document).ready(function(){
            
        }*/
        function closeModal(){
        // removemos divs creados
        $('#bgmodal').remove();
        $('#bgtransparent').remove();
}
    </script>
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#Reportes"></asp:Label>
            </h1>
        </div>
    </div>
    <img alt="" src="img/logo-megacable2.gif" />
    <br />
    <table style="width: 100%; padding: 20px;">
        <tr>
            <td>
                <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label>:
                <asp:Label ID="lblFiltro" runat="server"></asp:Label>
            </td>
            <td style="text-align: right">
                <asp:UpdatePanel ID="updCheck" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:CheckBox ID="chkImagenes" runat="server" Text="#Fotografias" Visible="False"
                            AutoPostBack="True" OnCheckedChanged="chkImagenes_CheckedChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updReporte" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlReporte" runat="server">
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <br />
    <asp:UpdatePanel ID="updDetalle" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>
            <center>
                <asp:GridView ID="grdDetalle" runat="server" AllowPaging="True" OnPageIndexChanging="grdDetalle_PageIndexChanging"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:Panel ID="pnlDetalle" runat="server">
                </asp:Panel>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    <center>
        <asp:UpdatePanel ID="updImagenesAudCableado" runat="server" ChildrenAsTriggers="False"
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataList ID="dlAudCableado" runat="server" CellPadding="4" ForeColor="#333333"
                    Visible="False">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSerieInicial" runat="server" Text="#SerieInicial"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSerieFinal" runat="server" Text="#SerieFinal"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="imgSerieInicial" runat="server" ImageUrl='<%#RutaImagen(Eval("_ClaveSucursal"),Eval("_RutaImagenIni"))%>' />
                                </td>
                                <td>
                                    <asp:Image ID="imgSerieFinal" runat="server" ImageUrl='<%#RutaImagen(Eval("_ClaveSucursal"),Eval("_RutaImagenFin"))%>' />
                                </td>
                                <td style="text-align: left; vertical-align: top;">
                                    <b>
                                        <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label></b>:
                                    <asp:Label ID="fldFecha" runat="server" Text='<%#Eval("?Fecha") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblTecnico" runat="server" Text="#Tecnico"></asp:Label></b>:
                                    <asp:Label ID="fldTecnico" runat="server" Text='<%#Eval("?Tecnico") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblNoContrato" runat="server" Text="#NoContrato"></asp:Label></b>:
                                    <asp:Label ID="fldNoContrato" runat="server" Text='<%#Eval("?NoContrato") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblTrabajo" runat="server" Text="#Trabajo"></asp:Label></b>:
                                    <asp:Label ID="fldTrabajo" runat="server" Text='<%#Eval("?Trabajo") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblDiferencia" runat="server" Text="#DiferenciaMts"></asp:Label></b>:
                                    <asp:Label ID="fldDiferencia" runat="server" Text='<%#Eval("?DiferenciaMts") %>'></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updImagenesAudVisita" runat="server" ChildrenAsTriggers="False"
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DataList ID="dlAudVisita" runat="server" CellPadding="4" ForeColor="#333333"
                    Visible="False">
                    <AlternatingItemStyle BackColor="White" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#EFF3FB" />
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFachadaDomicilio" runat="server" Text="#FachadaDomicilio"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="imgFachadaDomicilio" runat="server" ImageUrl='<%#RutaImagen(Eval("_ClaveSucursal"),Eval("_RutaImagen"))%>' />
                                </td>
                                <td style="text-align: left; vertical-align: top;">
                                    <b>
                                        <asp:Label ID="lblFecha" runat="server" Text="#Fecha"></asp:Label></b>:
                                    <asp:Label ID="fldFecha" runat="server" Text='<%#Eval("?Fecha") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblTecnico" runat="server" Text="#Tecnico"></asp:Label></b>:
                                    <asp:Label ID="fldTecnico" runat="server" Text='<%#Eval("?Tecnico") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblNoContrato" runat="server" Text="#NoContrato"></asp:Label></b>:
                                    <asp:Label ID="fldNoContrato" runat="server" Text='<%#Eval("?NoContrato") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblHora" runat="server" Text="#Hora"></asp:Label></b>:
                                    <asp:Label ID="fldHora" runat="server" Text='<%#Eval("?Hora") %>'></asp:Label>
                                    <br />
                                    <b>
                                        <asp:Label ID="lblEstatus" runat="server" Text="#Estatus"></asp:Label></b>:
                                    <asp:Label ID="fldEstatus" runat="server" Text='<%#Eval("?Estatus") %>'></asp:Label>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                </asp:DataList>
            </ContentTemplate>
        </asp:UpdatePanel>
    </center>
    <br />
    <br />
    <center>
        <input type="button" onclick="javascript:print()" value='<%=UtilMensaje.ObtenerMensaje("#Imprimir")%>' />
    </center>
    </form>
</body>
</html>
