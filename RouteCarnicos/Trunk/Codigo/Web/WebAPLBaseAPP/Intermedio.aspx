<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Intermedio.aspx.vb" Inherits="Intermedio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
</head>
 <script type="text/javascript" >
    window.focus();
     </script>
<body style="background-color:#4A7BBD">
    <form id="form1" runat="server">
    <div id="divAlgo"  style="color:White">Espere a que se genere el reporte<a style="color:White"  href='solicitudes.aspx?id=<%= Request("ID").ToString().Trim() %>'>...</a></div>
    <input id="Hidden1" type="hidden" value='<%= Request("ID").ToString().Trim() %>'/><br />
        <br />
         
    <script type="text/javascript">
    var ele = document.getElementById("Hidden1");
    window.open("Solicitudes.aspx?id="+ ele.value.toString(),"_self");
    </script>

        &nbsp;

    </form>
</body>
</html>
