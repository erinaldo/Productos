package com.amesol.pruebaandroid.dat;

import java.util.Dictionary;
import java.util.Enumeration;



public abstract class Entidad {
	
	private class Elemento{
		private String nombre = null;
		private Object valor = null;
		private boolean esLlave = false;
		private boolean cambio = false;
		
		public Elemento(String nombre){
			this.nombre = nombre;
		}

		public void setValor(Object valor){
			this.valor = valor;
			cambio = true;
		}
		public Object getValor(){
			return this.valor;
		}
		protected void setLlave(boolean esLlave){
			this.esLlave = esLlave;
		}
		
	}
	private String nombreTabla = "";
	
	private Dictionary<String, Elemento> elementos = new java.util.Hashtable<String, Entidad.Elemento>();
	private boolean creacionColumnas = false;
	private boolean creacionLlaves = false;
	
	protected void setNombreTabla(String nombreTabla){
		this.nombreTabla= nombreTabla;
	}
	protected void crearColumnas(String... columnas){
		if(columnas.length ==0)
			return;
		
		for(String c:columnas){
			this.elementos.put(c, new Elemento(c));
		}
		creacionColumnas = true;
	}
	protected void crearLlaves(String... columnas){
		if(columnas.length ==0)
			return;
		
		for(String c: columnas){
			Elemento e = elementos.get(c);
			if(e != null)
				e.setLlave(true);
		}
		creacionLlaves = true;
	}
	
	private void validarCreacionCorrecta() {
		if((!creacionColumnas)||(creacionLlaves)) throw new RuntimeException("Entidad mal creada, tiene que tener columnas y al menos una llave");
	}
	

	
	public void insertar(String comandoSQL,Object[] valores){	
		validarCreacionCorrecta();
		
		comandoSQL = "INSERT INTO "+ nombreTabla + "(";
		Enumeration<String> i = elementos.keys();
		while(i.hasMoreElements()){
			comandoSQL += i.nextElement() +",";
		}
		comandoSQL = comandoSQL.substring(0, comandoSQL.length());
		valores = new Object[elementos.size()];
		i = elementos.keys();
		int idx = 0;
		while(i.hasMoreElements()){
			valores[idx++] = elementos.get(i.nextElement());
		}
	}
	
	/*public Entidad[] seleccionar(String[] columnasSeleccion, String[] columnasFiltros, Object[] valores, SessionBD sesion){
		validarCreacionCorrecta();
		
		StringBuffer sql = new StringBuffer();
		sql.append("SELECT ");
		if(columnasSeleccion == null)
			sql.append("*");
		else{
			int i = 1;
			for(String s: columnasSeleccion){
				sql.append(s);
				if(columnasSeleccion.length > i++)
					sql.append(",");
			}
		}
		if(columnasFiltros.length > 0){
			sql.append(" WHERE ");
			int i = 1;
			for(String s: columnasFiltros){
				sql.append(s);
				sql.append(" = ? ");
				if(columnasSeleccion.length > i++)
					sql.append(" AND ");
			}
		}
		sesion.consultar(sql.toString(), valores);

	}*/
	

}
