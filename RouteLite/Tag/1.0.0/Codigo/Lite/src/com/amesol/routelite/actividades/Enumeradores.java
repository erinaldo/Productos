package com.amesol.routelite.actividades;

public final class Enumeradores {

	public final static class Promocion{
			
		public final class Tipo{
			public final static int Producto = 1;
			public final static int Cliente = 2;
			public final static int ProductoAcumulado = 4;
		}
		
		public final class TipoAplicacion{
			public final static int Descuento = 1;
			public final static int Bonificacion = 2;
			public final static int Precio = 3;
			public final static int Producto = 4;
			public final static int Puntos = 5;
		}
		
		public final class TipoRango{
			public final static int Cantidad = 1;
			public final static int Importe = 2;
		}
		
		public final class TipoRegla{
			public final static int Rango = 1;
			public final static int Grupo = 2;
		}
		
		
		
	}
	
	public final static class Esquema{
		
		public final class TipoEsquema{
			public final static int Cliente = 1;
			public final static int Producto = 2;
		}
		
	}
	
	public final static class Folio{
		
		public final class TiposContenidoFolio{
			public final static int NoDefinido = 0;
			public final static int Constante = 1;
			public final static int Incremental = 2;
		}
		
	}
	
	public final static class Inventario{
		
		public final class TiposValidacionInventario{
			public final static int NoValidar = 0;
			public final static int ValidacionRestrictiva = 1;
			public final static int ValidacionInformativa = 2;
		}
		
		public final class TipoEnvioMovimientosAutomaticos{
			public final static int InventarioABordo = 0;
		}
		
	}
}
