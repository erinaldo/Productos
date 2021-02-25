import { Component, OnInit } from '@angular/core';
import { ConfiguracionesService } from '../configuraciones.service';
import swal from 'sweetalert2';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'data-table-cmp',
    templateUrl: 'moneda.component.html'
})

export class MonedaComponent implements OnInit {
    public interval;
    public load = true;

    masterSelected: boolean;
    checkedList: any[] = [];
    monedas = null;
    fileToUpload: File = null;

    constructor(private servicio: ConfiguracionesService) {
        this.masterSelected = false;
    }

    ngOnInit(){
        this.getCoins();
        this.startTimer();
    }

    getCoins() {
        this.servicio.consultar('sysmoneda', 'sysIdMoneda,Clave,Descripcion', 'Baja=0').subscribe(
            result => {
                this.monedas = result;
            }, error => {
                console.log(error);
        });
    }

    startTimer() {
        this.interval = setInterval(() => {
            if (this.monedas != null && this.load){
                $('#datatablesmoneda').DataTable({
                    'pagingType': 'full_numbers',
                    'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'Todos']],
                    responsive: true,
                    'sDom': '<"H"lr>t<"F"ip>',
                    language: {
                        lengthMenu: 'Mostrar _MENU_ registros',
                        info: 'Mostrando del _START_ al _END_ de un total de _TOTAL_ registros.',
                    }
                });
                const table: any = $('#datatablesmoneda').dataTable()
                $('#searchbox').keyup(function() {
                    table.fnFilter( $(this).val() );
                });
                this.load = false
                clearInterval(this.interval)
            }
        }, 1000)
    }

    checkUncheckAll() {
        for (let i = 0; i < this.monedas.length; i++) {
            this.monedas[i].isSelected = this.masterSelected;
        }
        this.getCheckedItemList();
    }

    isAllSelected() {
        this.masterSelected = this.monedas.every(function(item: any) {
            return item.isSelected === true;
        });
        this.getCheckedItemList();
    }

    getCheckedItemList() {
        this.checkedList = [];
        for (let i = 0; i < this.monedas.length; i++) {
            if (this.monedas[i].isSelected) {
                this.checkedList.push(this.monedas[i].sysIdMoneda);
            }
        }
    }

    handleFileInput(files: FileList, ) {
        this.fileToUpload = files.item(0);
        this.servicio.archivoCSV(this.fileToUpload, 'sysmoneda', 'sysIdMoneda,sysIdPais,Clave,Descripcion').subscribe(datos => {
            if (datos['resultado'] === 'OK') {
                alert(datos['mensaje']);
                this.getCoins();
            }
        }, error => {
            console.log(error);
        });
    }

    delete() {
        if (this.checkedList.length > 0) {
            console.log(this.checkedList);
            for (const indice of this.checkedList) {
                console.log('indice: ' + indice);
                this.hide(indice);
            }
            this.getCoins();
        } else {
            this.showNotification('top', 'right');
        }
    }

    hide(id: number) {
        console.log(id);
        this.servicio.modificar('sysmoneda', 'Baja=1', 'sysIdMoneda=' + id.toString()).subscribe(
            datos => {
                if (datos['resultado'] === 'OK') {
                    this.getCoins();
                }
            }
        );
    }

    showNotification(from: any, align: any) {
        $.notify({
            icon: 'pe-7s-attention',
            message: '<b>Debe seleccionar un elemento.</b>'
        }, {
            type: 'warning',
            timer: 4000,
            placement: {
                from: from,
                align: align
            }
        });
    }
}
