package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.ParametroMSG;

@TablaDef(orden=1)
public class Cliente extends Entidad{

	@Llave()
	@Requerido
	public String ClienteClave;

	@Campo
	public String CNPId;
	
	@Campo(msgDescripcion="XClave")
	@Requerido
	public String Clave;
	
	@Campo(msgDescripcion="XCodigodeBarras")
	public String IdElectronico;

	@Campo(msgDescripcion="XRFC")
	public String IdFiscal;
	
	@Campo(msgDescripcion="XRazonSocial")
	@Requerido
	public String RazonSocial;
	
	@Campo
	@Requerido
	public short TipoFiscal;
	
	@Campo
	@Requerido
	public short TipoImpuesto;
	
	@Campo(msgDescripcion="XContacto")
	public String NombreContacto;
	
	@Campo(msgDescripcion="XTelefono")
	public String TelefonoContacto;
	
	@Campo(msgDescripcion="CLIFechaRegistroSistema")
	@Requerido
	public Date FechaRegistroSistema;
	
	@Campo(msgDescripcion="CLIFechaNacimiento")
	public Date FechaNacimiento;
	
	@Campo
	public float LimiteCreditoDinero;
	
	@Campo(msgDescripcion="XNombre")
	public String NombreCorto;
	
	@Campo
	@Requerido
	public short TipoEstado;
	
	@Campo
	public float LimiteDescuento;
	
	@Campo
	public float SaldoEfectivo;
	
	@Campo(msgDescripcion="XPrestamoEnvase")
	@Requerido
	public boolean Prestamo;
	
	@Campo(msgDescripcion="CLIExclusividad")
	@Requerido
	public boolean Exclusividad;
	
	@Campo(msgDescripcion="XVigenciaExclusividad")
	public Date VigExclusividad;
	
	@Campo
	@Requerido
	public boolean ActualizaSaldoCheque;
	
	@Campo
	@Requerido
	public boolean VencimientoVenta;
	
	@Campo
	public int DiasVencimiento;
	
	@Campo
	public float SaldoGarantia;
	
	@Campo
	public Date FechaFactura;
	
	@Campo
	public short TipoComplemento;
	
	@Campo
	public short TipoEstadoCom;
	
	@Campo(msgDescripcion="CLIExigirOrdenCompra")
	@Requerido
	public boolean ExigirOrdenCompra;
	
	@Campo
	public boolean ExigirPedidoAdicional;
	
	@Campo
	public String FormatoPedidoAdicional;
	
	@Campo
	@Requerido
	public Date MFechaHora;
	
	@Campo
	@Requerido
	public String MUsuarioID;
		
	@Campo
	public float SaldoEfectivoCarga;
	
	@Campo
	public float SaldoGarantiaCarga;
	
	@Campo(msgDescripcion="XDesglosaImpuestos")
	public boolean DesgloseImpuesto;
	
	@Campo
	public boolean ExigirTomaInvMer;
	
	@Campo
	public int LimiteEnvase;
	
	@Campo
	public boolean ValidarLimEnvase;
	
	@Campo
	public boolean ValidaFolNeg;
	
	@Campo
	public int PublicoGeneral;
	
	@Campo
	public boolean Enviado;

    @Campo
    public String CorreoElectronico;

    @Campo
    public int UsoCFDI;

	@Campo
	public String DatosExtra;

    public boolean RequiereFactura;
	
	@Hijos(tablaHijos=ClienteDomicilio.class)
	public List<ClienteDomicilio> ClienteDomicilio;
	
	@Hijos(tablaHijos=ClienteMensaje.class)
	public List<ClienteMensaje> ClienteMensaje;
	
	@Hijos(tablaHijos=ClienteEsquema.class)
	public List<ClienteEsquema> ClienteEsquema;
	
	@Hijos(tablaHijos=CLIFormaVenta.class)
	public List<CLIFormaVenta> CLIFormaVenta;
	
	@Hijos(tablaHijos=CenCli.class)
	public List<CenCli> CenCli;
	
	public Cliente(){		
			ClienteDomicilio = new ArrayList<ClienteDomicilio>();
			ClienteMensaje = new ArrayList<ClienteMensaje>();
			ClienteEsquema = new ArrayList<ClienteEsquema>();
			CLIFormaVenta = new ArrayList<CLIFormaVenta>();
			CenCli = new ArrayList<CenCli>();
	}
	
	@Override
	public void validar()throws ControlError{
		super.validar();
		if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("MttoClienteCamposReq")) {
			try {
				if (!((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("MttoClienteCamposReq").equals("")) {
                    String[] Campos = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("MttoClienteCamposReq").split("\\|");
					for (int i = 0; i <= Campos.length; i++){
						String cam = Campos[i].toLowerCase();
						switch (cam){
							case "cnpid":
								if (CNPId == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CNDCNPIdT", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "CNPId");
								}
								break;
							case "idelectronico":
								if (IdElectronico == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XCodigodeBarras", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "IdElectronico");
								}
								break;
							case "idfiscal":
								if (IdFiscal == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XRFC", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "IdFiscal");
								}
								break;
							case "nombrecontacto":
								if (NombreContacto == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XContacto", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "NombreContacto");
								}
								break;
							case "telefonocontacto":
								if (TelefonoContacto == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XTelefono", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "TelefonoContacto");
								}
								break;
							case "fechanacimiento":
								if (FechaNacimiento == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CLIFechaNacimiento", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "FechaNacimiento");
								}
								break;
							case "limitecreditodinero":
								if (LimiteCreditoDinero < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CFVLimiteCredito", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "LimiteCreditoDinero");
								}
								break;
							case "nombrecorto":
								if (NombreCorto == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XNombre", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "NombreCorto");
								}
								break;
							case "limitedescuento":
								if (LimiteDescuento < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("PROLimiteDescuento", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "LimiteDescuento");
								}
								break;
							case "saldoefectivo":
								if (SaldoEfectivo < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XSaldo", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "SaldoEfectivo");
								}
								break;
							case "vigexclusividad":
								if (VigExclusividad == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XVigenciaExclusividad", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "VigExclusividad");
								}
								break;
							case "diasvencimiento":
								if (DiasVencimiento < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CLIDiasVencimiento", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "DiasVencimiento");
								}
								break;
							case "saldogarantia":
								if (SaldoGarantia < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XSaldo", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "SaldoGarantia");
								}
								break;
							case "fechafactura":
								if (FechaFactura == null){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CLIFechaFactura", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "FechaFactura");
								}
								break;
							case "tipocomplemento":
								if (TipoComplemento < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CAFFormatoT", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "TipoComplemento");
								}
								break;
							case "tipoestadocom":
								if (TipoEstadoCom < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XEstado", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "TipoEstadoCom");
								}
								break;
							case "formatopedidoadicional":
								if (FormatoPedidoAdicional == ""){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("CLIFormatoPedidoA", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "FormatoPedidoAdicional");
								}
								break;
							case "saldoefectivocarga":
								if (SaldoEfectivoCarga < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XSaldo", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "SaldoEfectivoCarga");
								}
								break;
							case "saldogarantiacarga":
								if (SaldoGarantiaCarga < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XSaldo", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "SaldoGarantiaCarga");
								}
								break;
							case "limiteenvase":
								if (LimiteEnvase < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XSaldo", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "LimiteEnvase");
								}
								break;
							case "correoelectronico":
								if (CorreoElectronico == ""){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XCorreoCliente", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "CorreoElectronico");
								}
								break;
							case "usocfdi":
								if (UsoCFDI < 0){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XUsoCfdi", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "UsoCFDI");
								}
								break;
							case "datosextra":
								if (DatosExtra == ""){
									ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
									params.add(new ParametroMSG("XDatosExtra", true));
									throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "DatosExtra");
								}
								break;
						}
					}
				}
			} catch (Exception e) {
				e.printStackTrace();
//				throw new ControlError(e.getMessage());
				throw new ControlError("BE0001", e.getMessage().replace("[E0001] El campo ", "").replace("es requerido.", ""), this.getClass().getSimpleName(), "");
			}
		}
		if (RequiereFactura){
			if (IdFiscal == null){			
				ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
				params.add(new ParametroMSG("XRFC", true));
				throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "IdFiscal");
			}
            if (CorreoElectronico == null){
                ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
                params.add(new ParametroMSG("XCorreoElectronico", true));
                throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "CorreoElectronico");
            }
			try{
				int LongitudId = 14;
				if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("LongitudCampoIdFiscal")) {
					if (!((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("LongitudCampoIdFiscal").equals("0")) {
						LongitudId = Integer.parseInt(((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("LongitudCampoIdFiscal"));
						if (LongitudId == 0)
							LongitudId = 14;
						else
							LongitudId = LongitudId + 1;
					}
				}
				if (IdFiscal.toString().replace("-", "").trim().length() > LongitudId) {
					ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
					params.add(new ParametroMSG("XRFC", true));
					throw new ControlError(Mensajes.get("E0718").replace("$0$", "RFC").replace("$1$", String.valueOf(LongitudId)));
				}
			}
			catch(Exception e){
			}
		}
	}
	
	
	public boolean validarFormatoPedidoAdicional(String pedidoAdicional){
		
		if(pedidoAdicional.trim().equals(""))
			return false;

        int nLongMin = 1;
        if (this.FormatoPedidoAdicional.indexOf("*") > 0)
            nLongMin = this.FormatoPedidoAdicional.indexOf("*");
		
		if(pedidoAdicional.length() < nLongMin || pedidoAdicional.length() > this.FormatoPedidoAdicional.length())
			return false;
		
		for(int i = 0; i < pedidoAdicional.length(); i++){
			char c = pedidoAdicional.charAt(i);
			switch(FormatoPedidoAdicional.charAt(i)){
				case 'A': //cualquier letra mayuscula
					if(c < 'A' || c > 'Z')
						return false;
					break;
				case 'X': //cualquier letra mayuscula o numero
					if((c < 'A' || c > 'Z') && (c < '0' || c > '9'))
						return false;
					break;
				case '9': //cualquier numero
					if(c < '0' || c > '9')
						return false;
					break;
				case 'a': //cualquier letra mayuscula o miniscula
					if((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
						return false;
					break;
				case 'x': //cualquier letra maysucula, minuscula o numero
					if((c < 'A' || c > 'Z') && (c < 'a' || c > 'z') && (c < '0' || c > '9'))
						return false;
					break;
				//case 'z': //cualquier caracter, no validar
			}
		}
		
		return true;
	}
	
	
}
