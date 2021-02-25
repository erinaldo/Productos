import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/index.service';
import { Login } from '../../models';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnDestroy {
    mobileQuery: MediaQueryList;
    public modules: Modules[];
    hide: boolean = true;
    private _mobileQueryListener: () => void;
    currentUser: Login;

    constructor(
        http: HttpClient, @Inject('BASE_URL') baseUrl: string,
        private router: Router,
        private authenticationService: AuthenticationService,
        changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
        this.authenticationService.currentUser.subscribe((x: Login) => this.currentUser = x);
        this.mobileQuery = media.matchMedia('(max-width: 600px)');
        this._mobileQueryListener = () => changeDetectorRef.detectChanges();
        this.mobileQuery.addListener(this._mobileQueryListener);

        http.get<Modules[]>(baseUrl + 'Main').subscribe(result => {
            this.modules = result;
        }, error => console.error(error));
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }

    ngOnDestroy(): void {
        this.mobileQuery.removeListener(this._mobileQueryListener);
    }
}

interface Modules {
    MODId: string,
    Clave: string,
    nombre: string,
    Secuencia: number,
    TipoInterfaz: number,
    actividades: Actividad[]
}

interface Actividad {
    ACTId: string,
    nombre: string,
    Permiso: string,
    PermisoA: string,
    Secuencia: number,
    TipoActividad: number
}
