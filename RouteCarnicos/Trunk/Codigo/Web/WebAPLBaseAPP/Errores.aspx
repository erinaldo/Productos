<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Errores.aspx.vb" Inherits="Errores" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amesol Web</title>

    <script type="text/javascript">
        function MosOc(valor)
        {
            var ob = document.getElementById(valor);
            if(ob.style.display== "none")
                ob.style.display = "block";
            else
                ob.style.display = "none";                
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="images/RouteLogo.jpg" />
            <br />
            <br />
            <asp:Label ID="lbError" runat="server" Text="Error" Font-Bold="True"></asp:Label>
            <b onclick="MosOc('divDesc')">...</b>
            <div id="divDesc" style="display: none">
                <div id="lbErrorDesc" runat="server">
                </div>
            </div>
             <br />
            <br />
            <a href="Login.aspx" target="_top">
                <asp:Label ID="lblRegresar" runat="server" Text="Menu"></asp:Label></a>
            <br />
            <br />
            <b id="errorError" runat="server"></b>
        </div>
    </form>
</body>
</html>
