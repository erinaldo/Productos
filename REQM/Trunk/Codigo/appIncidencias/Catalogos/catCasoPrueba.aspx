<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/incidMaster.Master" CodeBehind="catCasoPrueba.aspx.vb" Inherits="appIncidencias.catCasoPrueba" %>
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
            <td>
                <asp:Label CssClass="Title" ID="lblTitle" runat="server" Text="Casos de Prueba"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvCasoPrueba" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="iCasoPruebaID" ShowFooter="True">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <EditItemTemplate>
                                <asp:ImageButton ID="ibUpdate" runat="server" CausesValidation="True" 
                                    CommandName="Update" ImageUrl="~/Imagenes/button_ok.png" Text="Actualizar" 
                                    ValidationGroup="Edit" />
                                &nbsp;<asp:ImageButton ID="ibCancel" runat="server" CausesValidation="False" 
                                    CommandName="Cancel" ImageUrl="~/Imagenes/Cancel Icon.jpg" Text="Cancelar" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="ibAdd" runat="server" CommandName="New" 
                                    ImageUrl="~/Imagenes/add-icon.jpg" onclick="ImageButton2_Click" Text="Nuevo" 
                                    ValidationGroup="Footer" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server" CausesValidation="False" 
                                    CommandName="Edit" ImageUrl="~/Imagenes/edit icon.png" Text="Editar" />
                                <asp:ImageButton ID="ibDelete" runat="server" CausesValidation="False" 
                                    CommandName="Delete" ImageUrl="~/Imagenes/Borrar.gif" Text="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID" InsertVisible="False" 
                            SortExpression="iCasoPruebaID">
                            <EditItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("iCasoPruebaID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%# Bind("iCasoPruebaID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre" SortExpression="vchNombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("vchNombre") %>' 
                                    ValidationGroup="Edit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNombre" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("vchNombre") %>' 
                                    ValidationGroup="Footer"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtNombre" ErrorMessage="*" ValidationGroup="Footer"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("vchNombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                
            </td>
        </tr>
    </table>
     </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
