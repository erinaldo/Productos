import { Routes } from '@angular/router';

import { BancoComponent } from './banco/banco.component';
import { ImpuestoComponent } from './impuesto/impuesto.component';
import { MonedaComponent } from './moneda/moneda.component';
import { PaisComponent } from './pais/pais.component';
import { EntidadComponent } from './entidad/entidad.component';

export const ConfiguracionesRoutes: Routes = [
    {
        path: '',
        children: [{
            path: 'banco',
            component: BancoComponent
        }]
    }, {
        path: '',
        children: [{
            path: 'impuesto',
            component: ImpuestoComponent
        }]
    }, {
        path: '',
        children: [{
            path: 'moneda',
            component: MonedaComponent
        }]
    }, {
        path: '',
        children: [{
            path: 'pais',
            component: PaisComponent
        }]
    }, {
        path: '',
        children: [{
            path: 'entidad',
            component: EntidadComponent
        }]
    }
];
