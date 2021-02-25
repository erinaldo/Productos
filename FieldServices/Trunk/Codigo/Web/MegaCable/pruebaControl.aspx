<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="pruebaControl.aspx.cs" Inherits="pruebaControl" %>

<%@ Register src="Cotroles/txtAuto.ascx" tagname="txtAuto" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:txtAuto  ID="txtAuto1" runat="server" MetodoConsulta="Perfiles" CampoTexto="Label" CampoValor="Value" Retraso="300" />
    <asp:ComboBox ID="ComboBox1" runat="server" AutoCompleteMode="Suggest">
    </asp:ComboBox>
    </asp:Content>

