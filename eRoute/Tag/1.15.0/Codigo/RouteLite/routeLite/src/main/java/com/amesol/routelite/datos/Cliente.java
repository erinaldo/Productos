package com.amesol.routelite.datos;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.amesol.routelite.datos.annotations.Campo;
import com.amesol.routelite.datos.annotations.Hijos;
import com.amesol.routelite.datos.annotations.Llave;
import com.amesol.routelite.datos.annotations.Requerido;
import com.amesol.routelite.datos.annotations.TablaDef;
import com.amesol.routelite.datos.generales.Entidad;
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
		if (DesgloseImpuesto){
			if (IdFiscal == null){			
				ArrayList<ParametroMSG> params =  new ArrayList<ParametroMSG>();
				params.add(new ParametroMSG("XRFC", true));
				throw new ControlError("BE0001", params, this.getClass().getSimpleName(), "IdFiscal");
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
