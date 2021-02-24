<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs"
    Inherits="RegistroTiemposLaborales.Configuracion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONFIGURACION</title>
    <style type="text/css">
        html, body, form
        {
            margin: 0px;
            height: 100%;
        }
    </style>

    <script src="js/jquery-1.4.4.min.js" type="text/javascript"></script>

</head>
<body style="background-image: url('images/amesol_duxtar.jpg'); background-attachment: fixed;
    background-repeat: no-repeat; background-position: bottom right">
    <form id="form1" runat="server">
    <center>
        <img alt="" src="images/logo_amesol_horizontal.jpg" />
        <br />
        <a href="Default.aspx">
            <img style="border: 0" alt="" src="images/home.png" /></a>
        <br />
    </center>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <script language="javascript" type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(RegistrarChecks);

        function RegistrarChecks() {
            $("#chkActividades tbody tr td input").click(function() {
                $("#lblModificado").show();
            });
        }
        $(document).ready(function() {
        RegistrarChecks();
            
        });
    </script>

    <table style="width: 100%">
        <tr>
            <th>
                Proyectos
            </th>
            <th>
                Areas
            </th>
            <th>
                Actividades
            </th>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:UpdatePanel ID="updError" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                    <ContentTemplate>
                        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanelRepetidor" runat="server" UpdateMode="Conditional"
                    RenderMode="Inline">
                    <ContentTemplate>
                        <center>
                            <asp:Button ID="BtGuardar" runat="server" Text="Guardar cambios de proyectos" OnClick="BtGuardar_Click" />
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand"
                                OnItemCreated="Repeater1_ItemCreated">
                                <HeaderTemplate>
                                    <table id="sample">
                                        <tr>
                                            <td id="Celda" style="border: 1px solid #FFCC00;">
                                                <asp:HiddenField ID="hidClave" runat="server" Value='' />
                                                <asp:TextBox ID="txtAgregar" OnTextChanged="TextBoxDescripcion_TextChanged" runat="server"
                                                    BorderStyle="None" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td id="Celda2" style="background-image: none; background-color: White">
                                                <asp:ImageButton ID="btnAgregar" ToolTip="Agregar Proyecto" runat="server" ImageUrl="~/images/button_ok.png"
                                                    CommandName="Agregar" />
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="FILA" runat="server">
                                        <td id="Celda" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:HiddenField ID="hidClave" runat="server" Value='<%#(Eval("Clave")).ToString()%>' />
                                            <asp:TextBox ID="TextBoxDescripcion" Text='<%# (Eval("Descripcion")).ToString() %>'
                                                runat="server" ReadOnly='<%# (Eval("Clave")).ToString().ToUpper()==System.Configuration.ConfigurationManager.AppSettings["ClienteAmesol"].ToUpper() %>'
                                                BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td id="Celda2" style="background-image: none; background-color: White">
                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/button_cancel.png"
                                                CommandName="Eliminar" Visible='<%#!((Eval("Clave")).ToString().ToUpper()==System.Configuration.ConfigurationManager.AppSettings["ClienteAmesol"].ToUpper()) %>'
                                                CommandArgument='<%#Eval("Clave")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </center>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="vertical-align: top;">
                <center>
                    <asp:UpdatePanel ID="updErrorAreas" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Label ID="lblErrorAreas" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="updRepeterAreas" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnGuardarAre" runat="server" Text="Guardar cambios de actividades"
                                OnClick="btnGuardarAre_Click" />
                            <asp:Repeater ID="repAreas" runat="server" OnItemCommand="repAreas_ItemCommand" OnItemCreated="Repeater1_ItemCreated">
                                <HeaderTemplate>
                                    <table id="sample">
                                        <tr>
                                            <td>
                                            </td>
                                            <td id="Celda" style="border: 1px solid #FFCC00;">
                                                <asp:HiddenField ID="hidClave" runat="server" Value='' />
                                                <asp:TextBox ID="txtAgregar" OnTextChanged="TextBoxAre_TextChanged" runat="server"
                                                    BorderStyle="None" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td id="Celda2" style="background-image: none; background-color: White">
                                                <asp:ImageButton ID="btnAgregar" ToolTip="Agregar Proyecto" runat="server" ImageUrl="~/images/button_ok.png"
                                                    CommandName="Agregar" />
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="FILA" runat="server">
                                        <td>
                                            <asp:ImageButton ID="btnElementos" runat="server" ImageUrl="images/Edit16.png" CommandName="EditarDetalle"
                                                CommandArgument='<%#(Eval("Clave")).ToString()%>' />
                                        </td>
                                        <td id="Celda" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:HiddenField ID="hidClave" runat="server" Value='<%#(Eval("Clave")).ToString()%>' />
                                            <asp:TextBox ID="TextBoxDescripcion" Text='<%# (Eval("Descripcion")).ToString() %>'
                                                runat="server" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td id="Celda2" style="background-image: none; background-color: White">
                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/button_cancel.png"
                                                CommandName="Eliminar" CommandArgument='<%#Eval("Clave")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="updActArea" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                        <ContentTemplate>
                            <br />
                            <br />
                            <table>
                                <tr>
                                    <th>
                                        <asp:HiddenField ID="hidClaveArea" runat="server" />
                                        <asp:Label ID="lblTituloAarea" runat="server" Text="Label"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td style="text-align: left;">
                                        <asp:CheckBoxList ID="chkActividades" runat="server" RepeatColumns="3">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="btnGuardarRelaciones" runat="server" Text="Guardar Cambios de Relacion Area-Actividad"
                                Visible="False" OnClick="btnGuardarRelaciones_Click" />
                            <asp:Label ID="lblModificado" runat="server" Text="Modificado" ForeColor="#FF9900"
                                Style="display: none"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </center>
            </td>
            <td style="vertical-align: top;">
                <center>
                    <asp:UpdatePanel ID="updErrorAct" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <asp:Label ID="lblErrorAct" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="updActivades" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btnGuardarAct" runat="server" Text="Guardar cambios de actividades"
                                OnClick="btnGuardarAct_Click" />
                            <asp:Repeater ID="repActividad" runat="server" OnItemCommand="repActividad_ItemCommand"
                                OnItemCreated="Repeater1_ItemCreated">
                                <HeaderTemplate>
                                    <table id="sample">
                                        <tr>
                                            <td id="Celda" style="border: 1px solid #FFCC00;">
                                                <asp:HiddenField ID="hidClave" runat="server" Value='' />
                                                <asp:TextBox ID="txtAgregar" OnTextChanged="TextBoxAct_TextChanged" runat="server"
                                                    BorderStyle="None" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td id="Celda2" style="background-image: none; background-color: White">
                                                <asp:ImageButton ID="btnAgregar" ToolTip="Agregar Proyecto" runat="server" ImageUrl="~/images/button_ok.png"
                                                    CommandName="Agregar" />
                                            </td>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="FILA" runat="server">
                                        <td id="Celda" style="border-color: #6a8ccb; border-style: solid; border-width: 1px">
                                            <asp:HiddenField ID="hidClave" runat="server" Value='<%#(Eval("Clave")).ToString()%>' />
                                            <asp:TextBox ID="TextBoxDescripcion" Text='<%# (Eval("Descripcion")).ToString() %>'
                                                runat="server" BorderStyle="None"></asp:TextBox>
                                        </td>
                                        <td id="Celda2" style="background-image: none; background-color: White">
                                            <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/images/button_cancel.png"
                                                CommandName="Eliminar" CommandArgument='<%#Eval("Clave")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </center>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
