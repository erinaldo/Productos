import { Component, OnInit, AfterViewInit, AfterViewChecked, AfterContentInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';


declare var $: any;
// Metadata
export interface RouteInfo {
    path: string;
    title: string;
    type: string;
    icontype: string;
    // icon: string;
    children?: ChildrenItems[];
}

export interface ChildrenItems {
    path: string;
    title: string;
    ab: string;
    type?: string;
}

// Menu Items
export const ROUTES: RouteInfo[] = [
    {
        path: '/dashboard',
        title: 'Dashboard',
        type: 'link',
        icontype: 'pe-7s-graph'
    }, {
        path: '/maps',
        title: 'Maps',
        type: 'link',
        icontype: 'pe-7s-map-marker'
    }, {
        path: '/#',
        title: 'Reportes',
        type: 'link',
        icontype: 'pe-7s-note2'
    }, {
        path: '/#',
        title: 'Operaciones',
        type: 'link',
        icontype: 'pe-7s-tools'
    }, {
        path: '/#',
        title: 'Catalogos',
        type: 'link',
        icontype: 'pe-7s-notebook'
    }, {
        path: '/configuraciones',
        title: 'Configuraciones',
        type: 'sub',
        icontype: 'pe-7s-config',
        children: [
            {path: 'moneda', title: 'Moneda', ab: 'M'},
            {path: 'impuesto', title: 'Impuesto', ab: 'I'},
            {path: 'pais', title: 'Pais', ab: 'P'},
            {path: 'banco', title: 'Banco', ab: 'B'},
            {path: 'entidad', title: 'Entidad', ab: 'E'}
        ]
    }, {
        path: '/components',
        title: 'Components',
        type: 'sub',
        icontype: 'pe-7s-plugin',
        children: [
            {path: 'buttons', title: 'Buttons', ab: 'B'},
            {path: 'grid', title: 'Grid System', ab: 'GS'},
            {path: 'panels', title: 'Panels', ab: 'P'},
            {path: 'sweet-alert', title: 'Sweet Alert', ab: 'SA'},
            {path: 'notifications', title: 'Notifications', ab: 'N'},
            {path: 'icons', title: 'Icons', ab: 'I'},
            {path: 'typography', title: 'Typography', ab: 'T'}
        ]
    }, {
        path: '/forms',
        title: 'Forms',
        type: 'sub',
        icontype: 'pe-7s-note2',
        children: [
            {path: 'regular', title: 'Regular Forms', ab: 'RF'},
            {path: 'extended', title: 'Extended Forms', ab: 'EF'},
            {path: 'validation', title: 'Validation Forms', ab: 'VF'},
            {path: 'wizard', title: 'Wizard', ab: 'W'}
        ]
    }, {
        path: '/tables',
        title: 'Tables',
        type: 'sub',
        icontype: 'pe-7s-news-paper',
        children: [
            {path: 'regular', title: 'Regular Tables', ab: 'RT'},
            {path: 'extended', title: 'Extended Tables', ab: 'ET'},
            {path: 'datatables.net', title: 'Datatables.net', ab: 'DT'}
        ]
    }, {
        path: '/charts',
        title: 'Charts',
        type: 'link',
        icontype: 'pe-7s-graph1'

    }, {
        path: '/calendar',
        title: 'Calendar',
        type: 'link',
        icontype: 'pe-7s-date'
    }, {
        path: '/pages',
        title: 'Pages',
        type: 'sub',
        icontype: 'pe-7s-gift',
        children: [
            {path: 'user', title: 'User Page', ab: 'UP'},
            {path: 'login', title: 'Login Page', ab: 'LP'},
            {path: 'register', title: 'Register Page', ab: 'RP'},
            {path: 'lock', title: 'Lock Screen Page', ab: 'LSP'}
        ]
    }
];

@Component({
    moduleId: module.id,
    selector: 'sidebar-cmp',
    templateUrl: 'sidebar.component.html',
})

export class SidebarComponent {
    constructor(public translate: TranslateService){
        
      }
    public menuItems: any[];
    isNotMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    }

    ngOnInit() {
        let isWindows: any = navigator.platform.indexOf('Win') > -1 ? true : false;
        this.menuItems = ROUTES.filter(menuItem => menuItem);

        isWindows = navigator.platform.indexOf('Win') > -1 ? true : false;

        if (isWindows) {
           // if we are on windows OS we activate the perfectScrollbar function
           $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();
           $('html').addClass('perfect-scrollbar-on');
       } else {
           $('html').addClass('perfect-scrollbar-off');
       }
    }
    ngAfterViewInit() {
        const $sidebarParent: any = $('.sidebar .nav > li.active .collapse li.active > a').parent().parent().parent();

        const collapseId: any = $sidebarParent.siblings('a').attr('href');

        $(collapseId).collapse('show');
    }
}
