import { Component,Inject, ChangeDetectorRef } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MediaMatcher } from '@angular/cdk/layout';
import { first } from 'rxjs/operators';
import { Login } from '../../models';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent {
  loading = false;
  users: Login[];
    public forecasts: WeatherForecast[];
    mobileQuery: MediaQueryList;

    fillerNav = Array.from({ length: 50 }, (_, i) => `Nav Item ${i + 1}`);

    fillerContent = Array.from({ length: 50 }, () =>
        `Testeando este contenido`);

    private _mobileQueryListener: () => void;

    constructor(private userService: LoginService, changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
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

  ngOnInit() {
      this.loading = true;
      this.userService.getAll().pipe(first()).subscribe((users: Login[]) => {
          this.loading = false;
          this.users = users;
      });
  }
}


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
