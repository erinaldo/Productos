<%@ Control Language="C#" AutoEventWireup="true" CodeFile="txtAuto.ascx.cs" Inherits="Cotroles_txtAuto" %>

<script type="text/javascript">
        $(function () {            
            $("#<%=TextBox1.ClientID%>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "Servicios/servicio1.aspx/<%=MetodoConsulta%>",
                        data: "{'valor':'" + $("#<%=TextBox1.ClientID%>").val() + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                          response($.map(data.d, function (item) {
                                return {
                                    label: item.<%=CampoTexto%>,
                                    value: item.<%=CampoValor%>
                                }
                          }))
                        },                
                        error: function (msg) {
                          alert(msg);
                        }
                    })
                },
                minLength: 2, 
                delay:<%=Retraso%>,
                focus: function(event, ui) {
		    		$("#<%=TextBox1.ClientID%>").val(ui.item.label);
                    $("#<%=hValor.ClientID%>").val(ui.item.value);
                    $("#<%=hTexto.ClientID%>").val(ui.item.label);


	    			return false;
    			},                                              
                select: function(event, ui) {				                        
                    $("#<%=TextBox1.ClientID%>").val(ui.item.label);
                    $("#<%=hValor.ClientID%>").val(ui.item.value);
                    $("#<%=hTexto.ClientID%>").val(ui.item.label);
                    return false;

			    }, 
            });
        });

</script>        


<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:HiddenField ID="hValor" runat="server" />
<asp:HiddenField ID="hTexto" runat="server" />


