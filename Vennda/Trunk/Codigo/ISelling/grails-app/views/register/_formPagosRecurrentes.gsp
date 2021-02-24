
<div class="row">
    <div class="col-md-12">
        <label for="owner">Nombre Completo (Como viene en la tarjeta)</label>
        <input name="nombreCompleto" type="text" class="form-control" id="owner" value="Luis Carlos de la Torre Flores">
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <label for="cvv">CVV</label>
        <input name="cvv" type="text" class="form-control" id="cvv" value="32144457">
    </div>
</div>
<div class="row">
    <div class="col-md-12">
        <label for="cardNumber">Numero de tarjeta</label>
        <input name="numeroTarjeta" type="text" class="form-control" id="cardNumber" value="4111111111111111">
    </div>
</div>
<div class="row">
    <div class="col-md-6">
        <label>Mes</label>
        <select name="mes" class="form-control">
            <option value="01">Enero</option>
            <option value="02">Febrero </option>
            <option value="03">Marzo</option>
            <option value="04">Abril</option>
            <option value="05">Mayo</option>
            <option value="06">Junio</option>
            <option value="07">Julio</option>
            <option value="08">Agosto</option>
            <option value="09">Septiembre</option>
            <option value="10">Octubre</option>
            <option value="11">Noviembre</option>
            <option value="12">Diciembre</option>
        </select>
    </div>

    <div class="col-md-6">
        <label>Año</label>
        <select name="ano" class="form-control">
            <option value="2016"> 2016</option>
            <option value="2017"> 2017</option>
            <option value="2018"> 2018</option>
            <option value="2019"> 2019</option>
            <option value="2020"> 2020</option>
            <option value="2021"> 2021</option>
        </select>
    </div>

</div>
<br>
<div class="row">
    <%--<img src="assets/images/visa.jpg" id="visa">
    <img src="assets/images/mastercard.jpg" id="mastercard">
    <img src="assets/images/amex.jpg" id="amex">--%>
    <div class="col-md-12">
        <g:radioGroup name="tipoTarjeta"
                      labels="['Visa','MasterCard']"
                      values="['VISA','MASTERCARD']">
            <b style="margin-right: 8px;">${it.label} ${it.radio}</b>
        </g:radioGroup>
    </div>
</div>

<br>


