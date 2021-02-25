import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable({
  providedIn: 'root'
})
export class ConfiguracionesService {

  UrlServer = '/nruta/api/';
  UrlLocal = 'http://localhost:8070/nruta/api/';
  UrlProductivo = 'http://localhost/nruta/api/';

  constructor(private http: HttpClient) { }

  consultar(tabla: String, campos: String, condiciones: String) {
    return this.http.get(this.UrlServer + 'obtenerRegistros.php?Tabla=' + tabla + '&Campos=' + campos + '&Condiciones=' + condiciones);
  }

  eliminar(tabla: String, condiciones: String){
    return this.http.get(this.UrlServer + 'eliminarRegistro.php?Tabla=' + tabla + '&Condiciones=' + condiciones);
  }

  modificar(tabla: String, campos: String, condiciones: String) {
    return this.http.get(this.UrlServer + 'actualizarRegistro.php?Tabla=' + tabla + '&Cambios=' + campos + '&Condiciones=' + condiciones);
  }

  archivoCSV(fileToUpload: File, tabla: String, campos: String) {
    const endpoint = this.UrlServer + 'importarCSV.php?Tabla=' + tabla + '&Campos=' + campos;
    const formData: FormData = new FormData();
    formData.append('archivo', fileToUpload, fileToUpload.name);
    return this.http.post(endpoint, formData);
  }

  ejecutarSP(sp: String, parametros: String) {
    return this.http.get(this.UrlServer + 'ejecutarSP.php?sp=' + sp + '&parametros=' + parametros);
  }
}
