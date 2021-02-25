import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class DataApiService {
    private baseUrl: string;
    module: Observable<any>;
    modules: Observable<any>;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getModules() {
        return this.http.get<Module[]>(this.baseUrl + 'Main');
    }
}


interface Module {
    MODId: string,
    Clave: string,
    nombre: string,
    Secuencia: number,
    TipoInterfaz: number,
    Actividades: Actividad[]
}

interface Actividad {
    ACTId: string,
    Nombre: string,
    Permiso: string,
    PermisoA: string,
    Secuencia: number,
    TipoActividad: number
}
