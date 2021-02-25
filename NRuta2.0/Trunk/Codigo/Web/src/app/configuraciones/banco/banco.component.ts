import { Component, OnInit } from '@angular/core';
import { ConfiguracionesService } from '../configuraciones.service';
import swal from 'sweetalert2';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'data-table-cmp',
    templateUrl: 'banco.component.html'
})

export class BancoComponent implements OnInit {
    masterSelected: boolean;
    checkedList: any[] = [];
    public interval;
    public load = true;
    bancos = null;
    fileToUpload: File = null;

    constructor(private servicio: ConfiguracionesService) {
        this.masterSelected = false;
    }

    ngOnInit() {
        this.getBancos();
        this.startTimer();
    }

    checkUncheckAll() {
        for (let i = 0; i < this.bancos.length; i++) {
            this.bancos[i].isSelected = this.masterSelected;
        }
        this.getCheckedItemList();
    }

    isAllSelected() {
        this.masterSelected = this.bancos.every(function(item: any) {
            return item.isSelected === true;
        });
        this.getCheckedItemList();
    }

    getCheckedItemList() {
        this.checkedList = [];
        for (let i = 0; i < this.bancos.length; i++) {
            if (this.bancos[i].isSelected) {
                this.checkedList.push(this.bancos[i].sysIdBanco);
            }
        }
    }

    getBancos() {
        this.servicio.consultar('sysbanco', 'sysIdBanco,Clave,Nombre,RfcEmisor', 'Baja=0').subscribe(
            result => {
                this.bancos = result;
            }, error => {
                console.log(error);
            });
    }

    startTimer() {
        this.interval = setInterval(() => {
            if (this.bancos != null && this.load) {
                 $('#datatablesbanco').DataTable({
                     'pagingType': 'full_numbers',
                     'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']],
                     responsive: true,
                     'sDom': '<"H"lr>t<"F"ip>',
                     language: {
                         lengthMenu: 'Mostrar _MENU_ registros',
                         info: 'Mostrando del _START_ al _END_ de un total de _TOTAL_ registros.'
                        }
                    });
                    const table: any = $('#datatablesbanco').dataTable();
                    $('#searchbox').keyup(function() {
                        table.fnFilter( $(this).val() );
                    });
                    this.load = false;
                    clearInterval(this.interval);
                }
            }, 1000)
    }

    handleFileInput(files: FileList, ) {
        this.fileToUpload = files.item(0);
        this.servicio.archivoCSV(this.fileToUpload, 'sysbanco', 'sysIdBanco,Clave,Nombre').subscribe(datos => {
            if (datos['resultado'] === 'OK') {
                alert(datos['mensaje']);
                this.getBancos();
            }
        }, error => {
            console.log(error);
        });
    }

    delete() {
        if (this.checkedList.length > 0) {
            for (const indice of this.checkedList) {
                this.hide(indice);
            }
            this.getBancos();
        } else {
            this.showNotification('top', 'right');
        }
    }

    hide(id: number) {
        this.servicio.modificar('sysbanco', 'Baja=1', 'sysIdBanco=' + id.toString()).subscribe(
            datos => {
                if (datos['resultado'] === 'OK') {
                    this.getBancos();
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
