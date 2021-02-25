package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;

public class ConsultarReporte extends Presentador
{
	IConsultaReporte mVista;
	
	public ConsultarReporte(IConsultaReporte vista){
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		
	}
	
	public void generarReporte(){
		try{
			int reporte = mVista.getReporteId();
			//Recibos recibo = new Recibos();
			//recibo.imprimirReporte(reporte, false, mVista);
			Recibos.imprimirReporte(reporte, false, mVista);
		}catch(Exception e){
			mVista.mostrarAdvertencia(e.getMessage());
			e.printStackTrace();
		}
		
		/*File file = new File(Environment.getExternalStorageDirectory().getAbsolutePath()+"/example.pdf");
		Intent intent = new Intent();
		intent.setDataAndType(Uri.fromFile(file), "application/pdf");
		intent.setClass(this, PDFViewer.class);
		intent.setAction("android.intent.action.VIEW");
		this.startActivity(intent);*/
	}

}
