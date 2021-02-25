<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="header">
        <div class="title">
            <h1>
                <asp:Label ID="lblTitulo" runat="server" Text="#AcercaDe"></asp:Label>
            </h1>
        </div>
    </div>
    <div class="contenido" style="margin: 50px;">
        <table>
            <tr>
                <td style="padding: 0px 20px 0px 0px">
                    <img alt="" src="img/logo-megacable2.gif" />
                </td>
                <td>
                    <b>Field Services Versión 1.1.1.3</b>
                    <br />
                    Amesol México<br />
                    José María Vigil 2706-2 Col. Lomas de Guevara<br />
                    C.P. 44657 Guadalajara, Jal.<br />
                    <br />
                    Tel. +52 (33) 3648 6070 <br />
                    Fax. +52 (33) 3648 6071 <br />
                    <br />
                    Este programa está protegido por leyes de copyright y tratados internacionales.
                    La reproducción o distribución no autorizada de este programa o de parte del mismo
                    dará lugar a graves penalizaciones tanto civiles como penales y será objeto de cuantas
                    acciones judiciales correspondan en derecho.
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
