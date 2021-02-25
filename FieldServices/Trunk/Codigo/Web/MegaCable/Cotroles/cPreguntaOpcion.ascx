<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cPreguntaOpcion.ascx.cs"
    Inherits="cPreguntaOpcion" %>
<asp:LinqDataSource ID="dsOpciones" runat="server"
    OnSelecting="dsOpciones_Selecting">
</asp:LinqDataSource>
<asp:Panel ID="Panel1" runat="server" DefaultButton="imgAgregar">
    <asp:ImageButton ID="imgAgregar" CommandName="Agregar" runat="server" 
        ImageUrl="~/img/Nuevo.jpg" onclick="imgAgregar_Click" 
        ValidationGroup="ValidarOpciones" />
    <asp:Label ID="lblTitulo" CssClass="PreguntaOpcionTitulo" runat="server" Text="#Opciones"></asp:Label>
    <br />
    <asp:TextBox ID="txtAgregar" CssClass="PreguntaOpcion" runat="server" 
        MaxLength="150" ValidationGroup="ValidarOpciones"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="#MI0001,#Clave" ControlToValidate="txtAgregar" 
        CssClass="failureNotification" ToolTip="#MI0001,#Clave" 
        ValidationGroup="ValidarOpciones">*</asp:RequiredFieldValidator>
</asp:Panel>
<asp:ListView ID="dlOpciones" runat="server" DataKeyNames="IdPreguntaOpcion" 
    DataSourceID="dsOpciones" onitemcommand="dlOpciones_ItemCommand" >
    <ItemTemplate>
        <asp:Panel ID="pnlElemento" runat="server" DefaultButton="imgEditar">
            <asp:TextBox ID="txtElemento" CssClass="PreguntaOpcion" runat="server" Text='<%#Eval("Descripcion")%>'
                ReadOnly="True" BorderStyle="None"></asp:TextBox>
            <asp:ImageButton ID="imgEditar" CommandName="Edit" runat="server" ImageUrl="../img/Editar.jpg" />
            <asp:ImageButton ID="imgEliminar" CommandName="Eliminar" runat="server" ImageUrl="~/img/Delete.jpg" />
        </asp:Panel>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:Panel ID="pnlElemento" runat="server" DefaultButton="imgAceptar">
            <asp:TextBox ID="txtElemento" CssClass="PreguntaOpcion" runat="server" Text='<%#Eval("Descripcion")%>'></asp:TextBox>
            <asp:ImageButton ID="imgAceptar" CommandName="Actualizar" runat="server" ImageUrl="~/img/Update.jpg" />
            <asp:ImageButton ID="imgEliminar" CommandName="Cancel" runat="server" ImageUrl="~/img/Delete.jpg" />
        </asp:Panel>
    </EditItemTemplate>
</asp:ListView>
