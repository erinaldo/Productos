<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/incidMaster.Master" CodeBehind="wfrProductoVsVersion.aspx.vb" Inherits="appIncidencias.wfrProductoVsVersion" %>
<%@ Register assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
    <table width="80%">
        <tr>
            <td align="center">
                <asp:Label CssClass="Title" ID="lblTitle" runat="server" Text="Producto VS Version"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" >
                <table width="50%">
                    <tr>
                        <td>
                            
                            <asp:Label  ID="Label1" runat="server" 
                                Text="Seleccione un producto de la lista: "></asp:Label>
                            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                         <asp:GridView ID="gvProdVersion" runat="server" AutoGenerateColumns="False">
                             <Columns>
                                 <asp:TemplateField HeaderText="ID" Visible="False">
                                     <EditItemTemplate>
                                         <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox>
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="Version" HeaderText="Version" />
                                 <asp:TemplateField HeaderText="Asignado">
                                     <EditItemTemplate>
                                         <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Asignado") %>' />
                                     </EditItemTemplate>
                                     <ItemTemplate>
                                         <asp:CheckBox ID="chkAsignado" runat="server" AutoPostBack="True" 
                                             Checked='<%# Bind("Asignado") %>' 
                                             oncheckedchanged="chkAsignado_CheckedChanged" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>
                        </asp:GridView>
                        </td>
                    </tr>
                </table>
               
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
