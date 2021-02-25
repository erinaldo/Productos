import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JwBootstrapSwitchNg2Module } from 'jw-bootstrap-switch-ng2';
import { TranslateModule } from '@ngx-translate/core'

import { ConfiguracionesRoutes } from './configuraciones.routing';

import { BancoComponent } from './banco/banco.component';
import { ImpuestoComponent } from './impuesto/impuesto.component';
import { MonedaComponent } from './moneda/moneda.component';
import { PaisComponent } from './pais/pais.component';
import { EntidadComponent } from './entidad/entidad.component';


@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(ConfiguracionesRoutes),
        FormsModule,
        JwBootstrapSwitchNg2Module,
        TranslateModule
    ],
    declarations: [
        BancoComponent,
        ImpuestoComponent,
        MonedaComponent,
        PaisComponent,
        EntidadComponent
    ]
})

export class ConfiguracionesModule {}
