package com.amesol.routelite.actividades;

import java.util.ArrayList;

import com.amesol.routelite.datos.Esquema;
import com.amesol.routelite.datos.FrecuenciaExcep;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.Consultas.ConsultasEsquema;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.vistas.utilerias.ServicesCentral;

import android.widget.CheckBox;
import android.widget.TextView;

public class Productos {
	
	public static final class vistaProductos{
		//producto
		private String ProductoClave;
		private String Nombre;
		private String NombreLargo;
		private String Id;
		//private int Tipo;
		//private String SubEmpresaId;
		//private float LimiteDescuento;
		//private int TipoFase;
		//private int Contenido;
		//private int Venta;
		//private int DecimalProducto;
		
		private boolean Checked = false;
		private float Existencia;
		private float Precio;
		private String Unidad;
		private int DecimalProducto;
		
		//productounidad
		private int PRUTipoUnidad;
		//private int TipoEstado;
		//private float KgLts;
		
		//inventario
		//private String AlmacenID;
		//private float Disponible;
		//private float NoDisponible;
		//private float Apartado;
		//private float Contenido_Inv;
		//private float Pedido;
		
		public vistaProductos(String pProductoClave, String pNombre,String pNombreLargo, String pId, float pExistencia,int pPRUTipoUnidad, String pUnidad, float pPrecio,boolean pChecked){
			ProductoClave = pProductoClave;
			Nombre = pNombre;
			NombreLargo = pNombreLargo;
			Id = pId;
			Existencia = pExistencia;
			PRUTipoUnidad = pPRUTipoUnidad;
			Unidad = pUnidad;
			Precio = pPrecio;
			Checked = pChecked;
			//DecimalProducto = pdecimalProducto;
		}
		
		public vistaProductos(String pProductoClave, String pNombre,String pNombreLargo, String pId, float pExistencia,int pPRUTipoUnidad, String pUnidad, float pPrecio,boolean pChecked, int pdecimalProducto){
			ProductoClave = pProductoClave;
			Nombre = pNombre;
			NombreLargo = pNombreLargo;
			Id = pId;
			Existencia = pExistencia;
			PRUTipoUnidad = pPRUTipoUnidad;
			Unidad = pUnidad;
			Precio = pPrecio;
			Checked = pChecked;
			DecimalProducto = pdecimalProducto;
		}
		
		public String getProductoClave() {
			return ProductoClave;
		}

		public void setProductoClave(String productoClave) {
			ProductoClave = productoClave;
		}

		public String getNombre() {
			return Nombre;
		}

		public void setNombre(String nombre) {
			Nombre = nombre;
		}

		public String getNombreLargo() {
			return NombreLargo;
		}

		public void setNombreLargo(String nombreLargo) {
			NombreLargo = nombreLargo;
		}

		public String getId() {
			return Id;
		}

		public void setId(String id) {
			Id = id;
		}

		public boolean isChecked() {
			return Checked;
		}

		public void setChecked(boolean checked) {
			Checked = checked;
		}
		
		public void toggleChecked() {
			Checked = !Checked ;
	    }

		public float getExistencia() {
			return Existencia;
		}

		public void setExistencia(float existencia) {
			this.Existencia = existencia;
		}

		public int getPRUTipoUnidad() {
			return PRUTipoUnidad;
		}

		public void setPRUTipoUnidad(int pRUTipoUnidad) {
			PRUTipoUnidad = pRUTipoUnidad;
		}
		
		public void setPrecio(float pPrecio){
			Precio = pPrecio;
		}
		
		public float getPrecio(){
			return Precio;
		}
		
		public void setUnidad(String pUnidad){
			Unidad = pUnidad;
		}
		
		public String getUnidad(){
			return Unidad;
		}
		
		public void setDecimalProducto(int pDecimalProducto){
			DecimalProducto = pDecimalProducto;
		}
		
		public int getDecimalProducto(){
			return DecimalProducto;
		}
		
		public static class ProductoViewHolder{
			private CheckBox checkBox ;
			private TextView txtUnidad ;
			private TextView txtClave ;
			private TextView txtDescripcion ;
			private TextView txtExistencia ;
			private TextView txtPrecio ;
			
			public ProductoViewHolder(CheckBox chckBox, TextView Unidad, TextView Clave, TextView Descripcion, TextView Existencia, TextView Precio){
				checkBox = chckBox;
				txtUnidad = Unidad;
				txtClave = Clave;
				txtDescripcion = Descripcion;
				txtExistencia = Existencia;
				txtPrecio = Precio;
			}
			
			public CheckBox getCheckBox() {
		      return checkBox;
		    }
		    public void setCheckBox(CheckBox checkBox) {
		      this.checkBox = checkBox;
		    }
		    public TextView gettxtUnidad() {
		      return txtUnidad;
		    }
		    public void settxtUnidad(TextView textView) {
		      this.txtUnidad = textView;
		    }  
		    public TextView gettxtClave() {
		      return txtClave;
		    }
		    public void settxtClave(TextView textView) {
		      this.txtClave = textView;
		    }
		    public TextView gettxtDescripcion() {
		      return txtDescripcion;
		    }
		    public void settxtDescripcion(TextView textView) {
		      this.txtDescripcion = textView;
		    }
		    public TextView gettxtExistencia() {
		      return txtExistencia;
		    }
		    public void settxtExistencia(TextView textView) {
		      this.txtExistencia = textView;
		    }
		    public TextView gettxtPrecio() {
		      return txtPrecio;
		    }
		    public void settxtPrecio(TextView textView) {
		      this.txtPrecio = textView;
		    }
		}
	}

	public static class vistaProductoUnidadFactor{
		private int _PRUTipoUnidad;
		private int _Factor;
		private String _DescUnidad;
		
		public vistaProductoUnidadFactor(int pPRUTipoUnidad, int pFactor, String pDescUnidad ){
			_PRUTipoUnidad = pPRUTipoUnidad;
			_Factor = pFactor;
			_DescUnidad = pDescUnidad;
		}
		
		public int getTipoUnidad(){
			return _PRUTipoUnidad;
		}
		
		public int getFactor(){
			return _Factor;
		}
		
		public String getDescUnidad(){
			return _DescUnidad;
		}
	}

     public static boolean obtenerEsquemasModulo(String moduloMovDetalleClave,  ArrayList<String> refaArreglo){
    	 try{
    		 
    		ISetDatos dataTableEsquema = Consultas.ConsultasModuloMovDetalle.obtenerModuloEsquema(moduloMovDetalleClave);
    		
	        if (dataTableEsquema.getCount() <=0){
	        	return false;
	        }
	        					
	        while(dataTableEsquema.moveToNext()){
	        	buscarNodosArbol(refaArreglo, dataTableEsquema.getString("EsquemaID"));
	        }
	        
	        dataTableEsquema.close();
	        if (refaArreglo.size() >0){
		        return true;	        	
	        }

    	 }catch (Exception ex){
    		 ex.printStackTrace();
	    }	    
	    return false;
 }

     private static void buscarNodosArbol(ArrayList<String> refaArreglo, String parsNodo){
    	try{
    		//Si los hijos del nodo actual ya se obtuvieron, se sale.
    		if (refaArreglo.contains("'" + parsNodo + "'")) return;
    		
    		ISetDatos IEsquemas = Consultas.ConsultasEsquema.obtenerHijosEsquema(parsNodo);
    		
    		refaArreglo.add("'" + parsNodo + "'");
    		
    		while (IEsquemas.moveToNext())
			{
    			if (!refaArreglo.contains("'" + IEsquemas.getString("EsquemaId") + "'")){    				
    				buscarNodosArbol(refaArreglo, IEsquemas.getString("EsquemaId"));
    				if (!refaArreglo.contains("'" + IEsquemas.getString("EsquemaId") + "'")){    	
    					refaArreglo.add("'" + IEsquemas.getString("EsquemaId") + "'");
    				}
    			}
			}
    		IEsquemas.close();
			
    	}catch(Exception ex){
    		ex.printStackTrace();
    	}
     }

}