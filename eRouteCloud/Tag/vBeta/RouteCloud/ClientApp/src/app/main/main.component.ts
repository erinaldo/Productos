import { Component, Inject, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MediaMatcher } from '@angular/cdk/layout';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css']
})

export class MainComponent implements OnDestroy {
    public forecasts: WeatherForecast[];
    mobileQuery: MediaQueryList;

    fillerNav = Array.from({ length: 50 }, (_, i) => `Nav Item ${i + 1}`);

    fillerContent = Array.from({ length: 50 }, () =>
        `Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
       labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco
       laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in
       voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
       cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.`);

    private _mobileQueryListener: () => void;

    constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.mobileQuery = media.matchMedia('(max-width: 600px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        this.mobileQuery.addListener(this._mobileQueryListener);

        http.get<WeatherForecast[]>(baseUrl + 'Main').subscribe(result => {
            this.forecasts = result;
        }, error => console.error(error));
    }

    ngOnDestroy(): void {
        this.mobileQuery.removeListener(this._mobileQueryListener);
    }
}

//export class MainComponent {
//    public forecasts: WeatherForecast[];

//    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//        http.get<WeatherForecast[]>(baseUrl + 'Main').subscribe(result => {
//            this.forecasts = result;
//        }, error => console.error(error));
//    }
//    showFiller = false;
//    change = false;
//    icon = 'view_list';
//    iconChange = () => {
//        if (this.change) {
//            this.icon = 'view_list';
//        } else {
//            this.icon = 'sort';
//        }
//        this.change = !this.change;
//    }
//}

interface WeatherForecast {
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
