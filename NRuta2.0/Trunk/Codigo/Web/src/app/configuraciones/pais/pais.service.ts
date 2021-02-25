import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ModPOSService {

  URLPruebas = "http://qanruta.serveftp.com/nruta/api/Pruebas/"
  URL = "http://qanruta.serveftp.com/nruta/api/"

  constructor(private http: HttpClient) { }

  consultar(tabla:String,campos:String,condiciones:String){
    return this.http.get('http://qanruta.serveftp.com/nruta/api/obtenerRegistros.php?Tabla='+tabla+'&Campos='+campos+'&Condiciones='+condiciones);
  }

  guardar(sp:String,parametros:String){
    return this.http.get(this.URLPruebas+'ejecutarSP.php?sp='+sp+'&parametros='+parametros);
  }

  eliminarPais(Baja: number, Clave: String, Nombre: String){
    return this.http.get('http://qaNruta.serveftp.com:8070/nruta/api/eliminarRegistro.php?Baja=${Baja}&Clave=${Clave}&Nombre=${Nombre}');
  }

  seleccionarPais(IdPais: number){
    return this.http.get('http://localhost:8070/nruta/api/SeleccionarPais.php?IdPais=${IdPais}');
  }

  modificar(tabla:String,campos:String,condiciones:String){
    return this.http.get('http://qanruta.serveftp.com/nruta/api/actualizarRegistro.php?Tabla='+tabla+'&Cambios='+campos+'&Condiciones='+condiciones);
  }
}