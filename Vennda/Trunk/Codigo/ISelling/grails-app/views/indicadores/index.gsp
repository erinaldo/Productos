<%--
  Created by IntelliJ IDEA.
  User: elephantworkss.adec.v
  Date: 01/05/17
  Time: 5:13 PM
--%>
<%@ page contentType="text/html;charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <meta name="layout" content="main">
    <g:set var="entityName" value="${message(code: 'indicadores.label', default: 'Indicadores')}" />
    <title><g:message code="default.list.label" args="[entityName]" /></title>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script>

        var dataLine;
        var chartLine;
        var dataBar;
        var chartBar;
        // Load the Visualization API and the piechart package.
        google.charts.load('current', {'packages':['corechart']});
        google.charts.load('current1', {'packages':['bar']});
        google.charts.load('current2', {'packages':['line']});
        // Set a callback to run when the Google Visualization API is loaded.
        google.charts.setOnLoadCallback(defaultChart);
        google.charts.setOnLoadCallback(drawChart);

        // Callback that creates and populates a data table,
        // instantiates the pie chart, passes in the data and
        // draws it.
        function drawChart() {
            $("#btnBuscar").click(function(){
                //Entra solo si se da clic izquierdo en botón Buscar

                var fechaInicio = "";
                var fechaFin = "";
                //Otiene el valor del punto de Venta seleccionado
                var id = $("#selectGrafica").val();
                fechaInicio = $("#fechaInicio").val();
                fechaFin = $("#fechaFin").val();

                //TOTAL DE VENTA DIARIA_______INICIO
                /**************** TOTAL DE VENTA DIARIA**********************************
                 Esta grafica se genera con tres lineas una linea represetna la sumatoria
                 del total de ventas si importar si fueron credito o contado,
                 otra linea representa unicamente la sumatoria del total de ventas a
                 credito y otra linea uniamente la sumatoria del total de las ventas
                 de contado.
                 */
                var url_TotalDeVentaDiaria = "${createLink(controller:'indicadores',action:'TotalVentaDiaria')}";

                var jsonData_TotalDeVentaDiaria = $.ajax({
                    url: url_TotalDeVentaDiaria,
                    data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                    dataType: "json",
                    async: false
                }).responseText;

                var options_TotalDeVentaDiaria = {
                    width: 400,
                    height: 200
                };


                // Create our data table.
                var dataTable_TotalDeVentaDiaria = new google.visualization.DataTable(jsonData_TotalDeVentaDiaria);
                var chartVentaDiaria_div = new google.visualization.LineChart(document.getElementById('chartVentaDiaria_div'));
                chartVentaDiaria_div.draw(dataTable_TotalDeVentaDiaria, google.charts.Line.convertOptions(options_TotalDeVentaDiaria));
                //TOTAL DE VENTA DIARIA_______FIN

                //VENTAS POR VENDEDOR_______INICIO
                /**************** VENTAS POR VENDEDOR **********************************
                /**Grafica de Pie, donde cada color representa a un
                 * vendedor y el porcentaje de venta que realizo respecto
                 * al total de ventas en el periodo seleccionado
                 */
                var url_VentaPorVendedor = "${createLink(controller:'indicadores',action:'VentasPorVendedor')}";

                var jsonData_VentaPorVendedor = $.ajax({
                    url: url_VentaPorVendedor,
                    data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                    dataType: "json",
                    async: false
                }).responseText;

                // Create our data table.
                var dataTable_VentaPorVendedor = new google.visualization.DataTable(jsonData_VentaPorVendedor);
                var chartVentasPorVendedor_div = new google.visualization.PieChart(document.getElementById('chartVentasPorVendedor_div'));
                chartVentasPorVendedor_div.draw(dataTable_VentaPorVendedor);
                //VENTAS POR VENDEDOR_______FIN

                //VENTAS POR POS__________INICIO
                /********* VENTAS POR POS *************/
                /*
                 Grafica de Dona donde cada color representa un punto de venta
                 y el porcentaje de venta que realizo respecto al total
                 de ventas del periodo seleccionado
                 */
                var urlVentaPorPOS = "${createLink(controller:'indicadores',action:'VentasPorPOS')}";

                var jsonData_VentaPorPOS = $.ajax({
                    url: urlVentaPorPOS,
                    data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                    dataType: "json",
                    async: false
                }).responseText;

                var options_VentaPorPOS = {
                    pieHole: 0.4,
                };


                // Create our data table.
                var dataTable_VentaPorPOS = new google.visualization.DataTable(jsonData_VentaPorPOS);
                var chartVentaPorPOS_div = new google.visualization.PieChart(document.getElementById('chartVentaPorPOS_div'));
                chartVentaPorPOS_div.draw(dataTable_VentaPorPOS, options_VentaPorPOS);
                //VENTAS POR POS____________FIN

                //TOP 5_________INICIO
                /*************************** TOP 5 ***************************/
                /*
                 Grafica de Barras que muestra los 5 productos mas vendidos del periodo
                 seleccionado y cada barra representa la cantidad de unidades vendidas.
                 */
                 var urlBar= "${createLink(controller:'indicadores',action:'productosMasVendidos')}";
                 var jsonDataBar = $.ajax({
                    url: urlBar,
                    data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                    dataType: "json",
                    async: false
                }).responseText;

                 // Create our data table.
                 dataBar = new google.visualization.DataTable(jsonDataBar);
                 var optionsBar = {
                    curveType: 'function',
                    legend: { position: 'bottom' }
                };

                 // Instantiate and draw our chart, passing in some options.
                 chartBar = new google.visualization.BarChart(document.getElementById('chartTop5_div'));
                 chartBar.draw(dataBar, {width: 400, height: 240});

                 google.visualization.events.addListener(chartBar, 'select', selectHandler);
                 chartBar.draw(dataBar, optionsBar);
                //TOP 5_________FIN

                //Total de Cobranza Diaria por Tipo de Pago___________INICIO
                /***********************Total de Cobranza Diaria por Tipo de Pago*********************/
                /*
                 Grafica de Combo, donde la linea representa la suma de todos los abonos
                 sin importar si fueron efectivo o tarjeta y Por cada dia mostraran dos
                 barras una la sumatoria de todos los pagos  que se realizaron en Efectivo
                 y otra  mostrara la suma de todos los pagos que se realizaron con Tarjeta.
                 */
                var url_TotalDeCobranzaDiariaPorTipoDePago = "${createLink(controller:'indicadores',action:'TotalDeCobranzaDiariaPorTipoDePago')}";

                var jsonData_TotalDeCobranzaDiariaPorTipoDePago = $.ajax({
                    url: url_TotalDeCobranzaDiariaPorTipoDePago,
                    data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                    dataType: "json",
                    async: false
                }).responseText;

                // Create our data table.
                var dataTable_options_TotalDeCobranzaDiariaPorTipoDePago = new google.visualization.DataTable(jsonData_TotalDeCobranzaDiariaPorTipoDePago);

                var options_TotalDeCobranzaDiariaPorTipoDePago = {
                    vAxis: {title: 'Monto'},
                    hAxis: {title: 'Fechas de abono'},
                    seriesType: 'bars',
                    series: {2: {type: 'line'}}
                };

                var chart_TotalDeCobranzaDiariaPorTipoDePago = new google.visualization.ComboChart(document.getElementById('chart_TotalDeCobranzaDiariaPorTipoDePago'));
                chart_TotalDeCobranzaDiariaPorTipoDePago.draw(dataTable_options_TotalDeCobranzaDiariaPorTipoDePago, options_TotalDeCobranzaDiariaPorTipoDePago);
                //Total de Cobranza Diaria por Tipo de Pago___________FIN
            });

        }
        function defaultChart() {
            //Se muestran estos datos al cargar la pagina sin filtrar nada
           /* var today = new Date();
            var dd = today.getDate();
           */

            var today = new Date();
            var primerDia = new Date(today.getFullYear(), today.getMonth(), 1);
            var dd = primerDia.getDate();

            var ddFin = today.getDate();
            var mm = today.getMonth()+1; //January is 0!

            var yyyy = today.getFullYear();
            if(dd<10){
                dd='0'+dd;
            }
            /*
             if(dd<10){
             dd='0'+dd;
             ddFin='0'+ddFin;
             }
            */
            if(mm<10){
                mm='0'+mm;
            }
            var todayInicio = dd+'-'+mm+'-'+yyyy;
            var todayFin = ddFin+'-'+mm+'-'+yyyy;

            $("#fechaInicio").val(todayInicio);
            $("#fechaFin").val(todayFin);
            $('#selectGrafica > option[value="1"]').attr('selected', 'selected');

            var fechaInicio = "";
            var fechaFin = "";

            //Aqui mandamos cero, como referencia de que no se ha elegido un punto de venta
            //pero dentro de la consulta en el controller si viene 0 el id, se hace la consulta
            //por el primer punto de venta ejemplo:
            //PuntoVenta puntoVenta = PuntoVenta.findAllByEmpresa(empresaInstance).first()
            var id = 0;


            fechaInicio = todayInicio;
            fechaFin = todayFin;

            //TOTAL DE VENTA DIARIA_______INICIO
            /**************** TOTAL DE VENTA DIARIA**********************************
             Esta grafica se genera con tres lineas una linea represetna la sumatoria
             del total de ventas si importar si fueron credito o contado,
             otra linea representa unicamente la sumatoria del total de ventas a
             credito y otra linea uniamente la sumatoria del total de las ventas
             de contado.
             */
            var url_TotalDeVentaDiaria = "${createLink(controller:'indicadores',action:'TotalVentaDiaria')}";


            var jsonData_TotalDeVentaDiaria = $.ajax({
                url: url_TotalDeVentaDiaria,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            var options_TotalDeVentaDiaria = {
                width: 400,
                height: 200
            };

            // Create our data table.
            var dataTable_TotalDeVentaDiaria = new google.visualization.DataTable(jsonData_TotalDeVentaDiaria);
            var chartVentaDiaria_div = new google.visualization.LineChart(document.getElementById('chartVentaDiaria_div'));
            chartVentaDiaria_div.draw(dataTable_TotalDeVentaDiaria, google.charts.Line.convertOptions(options_TotalDeVentaDiaria));

            //TOTAL DE VENTA DIARIA_______FIN


            //VENTAS POR VENDEDOR_______INICIO
            /**************** VENTAS POR VENDEDOR **********************************
             /**Grafica de Pie, donde cada color representa a un
             * vendedor y el porcentaje de venta que realizo respecto
             * al total de ventas en el periodo seleccionado
             */
            var url_VentasPorVendedor = "${createLink(controller:'indicadores',action:'VentasPorVendedor')}";

            var jsonData_VentasPorVendedor = $.ajax({
                url: url_VentasPorVendedor,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            var dataTable_VentaPorVendedor = new google.visualization.DataTable(jsonData_VentasPorVendedor);
            var chartVentasPorVendedor_div = new google.visualization.PieChart(document.getElementById('chartVentasPorVendedor_div'));
            chartVentasPorVendedor_div.draw(dataTable_VentaPorVendedor);
            //VENTAS POR VENDEDOR_______FIN

            //VENTAS POR POS__________INICIO
            /********* VENTAS POR POS *************/
            /*
             Grafica de Dona donde cada color representa un punto de venta
             y el porcentaje de venta que realizo respecto al total
             de ventas del periodo seleccionado
             */
            var url_VentaPorPOS = "${createLink(controller:'indicadores',action:'VentasPorPOS')}";

            var jsonData_VentaPorPOS = $.ajax({
                url: url_VentaPorPOS,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            var options_VentaPorPOS = {
                pieHole: 0.4,
            };



            // Create our data table.
            var dataTable_VentaPorPOS = new google.visualization.DataTable(jsonData_VentaPorPOS);
            var chartVentaPorPOS_div = new google.visualization.PieChart(document.getElementById('chartVentaPorPOS_div'));
            chartVentaPorPOS_div.draw(dataTable_VentaPorPOS, options_VentaPorPOS);
            //VENTAS POR POS____________FIN

            //TOP 5_________INICIO
            /*************************** TOP 5 ***************************/
            /*
             Grafica de Barras que muestra los 5 productos mas vendidos del periodo
             seleccionado y cada barra representa la cantidad de unidades vendidas.
             */
            var urlBar= "${createLink(controller:'indicadores',action:'productosMasVendidos')}";

            var jsonDataBar = $.ajax({
                url: urlBar,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            // Create our data table.
            dataBar = new google.visualization.DataTable(jsonDataBar);

            var optionsBar = {
                curveType: 'function',
                legend: { position: 'bottom' }
            };

            // Instantiate and draw our chart, passing in some options.
            chartBar = new google.visualization.BarChart(document.getElementById('chartTop5_div'));
            chartBar.draw(dataBar, {width: 400, height: 240});

            google.visualization.events.addListener(chartBar, 'select', selectHandler);
            chartBar.draw(dataBar, optionsBar);
            //TOP 5_________FIN

            //Total de Cobranza Diaria por Tipo de Pago___________INICIO
            /***********************Total de Cobranza Diaria por Tipo de Pago*********************/
            /*
             Grafica de Combo, donde la linea representa la suma de todos los abonos
             sin importar si fueron efectivo o tarjeta y Por cada dia mostraran dos
             barras una la sumatoria de todos los pagos  que se realizaron en Efectivo
             y otra  mostrara la suma de todos los pagos que se realizaron con Tarjeta.
             */
            var url_TotalDeCobranzaDiariaPorTipoDePago = "${createLink(controller:'indicadores',action:'TotalDeCobranzaDiariaPorTipoDePago')}";

            var jsonData_TotalDeCobranzaDiariaPorTipoDePago = $.ajax({
                url: url_TotalDeCobranzaDiariaPorTipoDePago,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            // Create our data table.
            var dataTable_options_TotalDeCobranzaDiariaPorTipoDePago = new google.visualization.DataTable(jsonData_TotalDeCobranzaDiariaPorTipoDePago);

            var options_TotalDeCobranzaDiariaPorTipoDePago = {
                vAxis: {title: 'Monto'},
                hAxis: {title: 'Fechas de abono'},
                seriesType: 'bars',
                series: {2: {type: 'line'}}
            };

            var chart_TotalDeCobranzaDiariaPorTipoDePago = new google.visualization.ComboChart(document.getElementById('chart_TotalDeCobranzaDiariaPorTipoDePago'));
            chart_TotalDeCobranzaDiariaPorTipoDePago.draw(dataTable_options_TotalDeCobranzaDiariaPorTipoDePago, options_TotalDeCobranzaDiariaPorTipoDePago);
            //Total de Cobranza Diaria por Tipo de Pago___________FIN

            //Total Cobranza Vencida___________INICIO
            /***********************Total Cobranza Vencida*********************/
            /*
             Grafica de Area, Esta grafica no depende de los rangos de fecha seleccionados:
             Es una grafica de Area donde el Area representa el Saldo de todas las ventas a credito
             (lo que se debe desde el origen de los tiempos a la fecha actual) y la segunda area
             representa el saldo de las ventas a credito pero cuya fecha de vencimiento
             es menor o igual a la fecha actual (lo vencido)
             */
            var url_TotalDeCobranzaVencida = "${createLink(controller:'indicadores',action:'TotalCobranzaVencida')}";

            var jsonData_TotalDeCobranzaVencida = $.ajax({
                url: url_TotalDeCobranzaVencida,
                data: {id:id,fechaInicio:fechaInicio,fechaFin:fechaFin},
                dataType: "json",
                async: false
            }).responseText;

            var dataTable_TotalDeCobranzaVencida = new google.visualization.DataTable(jsonData_TotalDeCobranzaVencida);

            var options_TotalDeCobranzaVencida = {
                hAxis: {title: 'Mes',  titleTextStyle: {color: '#333'}},
                vAxis: {minValue: 0}
            };

            var chart_TotalDeCobranzaVencida = new google.visualization.AreaChart(document.getElementById('chart_TotalCobranzaVencida'));
            chart_TotalDeCobranzaVencida.draw(dataTable_TotalDeCobranzaVencida,options_TotalDeCobranzaVencida);
            //Total Cobranza Vencida___________FIN
        }


        function selectHandler() {
            var selectedItem = chartLine.getSelection()[0];
            var value = dataLine.getValue(selectedItem.row, 0);
            alert('The user selected ' + value);

            var selectedItemBar = chartBar.getSelection()[0];
            var valueBar = dataBar.getValue(selectedItemBar.row, 0);
            alert('The user selected ' + valueBar);
        }

    </script>

    <style>
    .row{
        margin-bottom: .5em;
    }
    .imageInButton{
        width:30px;
    }
    .buttonImage{
        background-color: #48BFE6;
    }
    thead{
        background-color: #1c94c4;
        text-align: center;

    }
    thead tr th{
        font-family: "Arial";
        font-size: 14px;
        color:#FFF;
        text-align: center;
    }
    tbody tr{
        background-color: #D8DFE5;
        font-family: "Arial";
        font-size: 12px;
        color:#000;
        text-align: center;
    }
    tbody tr td{
        border-bottom: 1px solid #9B9B9B;
    }
    .semi-circulo-abajo
    {
        display: none;
    }
    .semi-circulo-arriba
    {
        display: none;
    }

    </style>
</head>

<body>


<div class="row" style="margin-top: 3%">
    <div class="col-md-12">
        <div class="panel panel-primary" style="border-color: #48BFE6">
            <div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
                <image width="25px" class="imageInButton" src="${resource(dir: "images", file: "PuntoVenta/PuntoVentaBlanco.png")}"></image>
                <g:message code="indicadore.label" default="Indicadores"/>
            </div>

            <div class="contenedor" style="margin-top: 3%; margin-bottom: 3%;  width: 90%;">
                <div class="row">
                    <div class="col-md-3">
                        <label for="puntoVenta">
                            <g:message code="indicadores.puntoVenta.label" default="Punto de Venta" />
                            <span class="required-indicator">*</span>
                        </label>

                        <g:select
                                id="selectGrafica"
                                name="puntoVenta"
                                from="${mx.elephantworks.iselling.PuntoVenta.list()}"
                                noSelection="['0':'Selecciona ...']"
                                optionKey="id"
                                optionValue="nombreNegocio"
                                class="form-control"
                        />
                    </div>
                    <div class="col-md-3">
                        <label for="fechaInicio">
                            <g:message code="indicadores.fechaInicio.label" default="Fecha Inicio" />
                            <span class="required-indicator">*</span>
                        </label>

                        <g:textField id="fechaInicio" name="fechaInicio" required=""  class="form-control" />
                    </div>
                    <div class="col-md-3">
                        <label for="fechaInicio">
                            <g:message code="indicadores.fechaFin.label" default="Fecha Fin" />
                            <span class="required-indicator">*</span>
                        </label>

                        <g:textField id="fechaFin" name="fechaFin" required="" class="form-control" />
                    </div>
                    <div class="col-md-3" style="margin-top: 25px;">
                        <g:submitButton id="btnBuscar" name="btnBuscar" class="btn btn-primary color-vennda" value="Buscar" />
                    </div>
                </div>
                <br>
                <br>


                <div class="row">
                    <div class="col-md-6">
                        <label id="lblTituloVentaDiaria">Total de venta diaria</label>
                        <div id="chartVentaDiaria_div"></div>
                    </div>
                    <div class="col-md-6">
                        <label id="lblTituloVentasPorVendedor">Ventas por vendedor</label>
                        <div id="chartVentasPorVendedor_div"></div>
                    </div>
                </div>
                <br>

                <div class="row">
                    <div class="col-md-6">
                        <label id="lblTituloVentaPorPOS">Ventas por POS</label>
                        <div id="chartVentaPorPOS_div"></div>
                    </div>
                    <div class="col-md-6">
                        <label id="lblTituloTop5">TOP 5</label>
                        <div id="chartTop5_div"></div>
                    </div>
                </div>
                <br>

                <div class="row">
                    <div class="col-md-6">
                        <label id="lblTituloTotalCobranzaDiariaTipoPago">Total de Cobranza Diaria por Tipo de Pago</label>
                        <div id="chart_TotalDeCobranzaDiariaPorTipoDePago"></div>
                    </div>
                    <div class="col-md-6">
                        <label id="lblTituloTotalCobranzaVencida">Total Cobranza vencida</label>
                        <div id="chart_TotalCobranzaVencida"></div>
                    </div>
                </div>
                <br>

            </div>
        </div>
    </div>
</div>













<script>
    $( function() {
        $("#fechaInicio").datepicker({
            dateFormat: "dd-mm-yy"
        });
        $("#fechaFin").datepicker({
            dateFormat: "dd-mm-yy"
        });
    });
</script>
</body>
</html>