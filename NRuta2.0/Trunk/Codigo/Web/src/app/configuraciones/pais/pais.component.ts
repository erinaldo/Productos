import { Component, OnInit } from '@angular/core';
import { ConfiguracionesService } from '../configuraciones.service';

declare var $: any;

@Component({
    moduleId: module.id,
    selector: 'data-table-cmp',
    templateUrl: 'pais.component.html'
})

export class PaisComponent implements OnInit {
    masterSelected: boolean;
    checkedList: any[] = [];
    public interval;
    public load:boolean = true;
    fileToUpload: File = null;

    paises = null;
    constructor(private paisServicio: ConfiguracionesService) {
      this.masterSelected = false;
    }

    ngOnInit(){
        this.consultarPais(); 
        this.startTimer() 
    }

    checkUncheckAll() {
      for (let i = 0; i < this.paises.length; i++) {
          this.paises[i].isSelected = this.masterSelected;
      }
      this.getCheckedItemList();
  }

  isAllSelected() {
     
    this.masterSelected = this.paises.every(function(item: any) {
          return item.isSelected === true;
      });
     
      this.getCheckedItemList();

  }

  getCheckedItemList() {
      this.checkedList = [];
      for (let i = 0; i < this.paises.length; i++) {
          if (this.paises[i].isSelected) {
              this.checkedList.push(this.paises[i].sysidPais);
          }
      }
  }


    consultarPais(){
        this.paisServicio.consultar("syspais","sysidPais,Clave,Nombre","Baja=0").subscribe(
            resultado => this.paises = resultado
        );
    }

    
    eliminarMasivo(){
      if (this.checkedList.length > 0) {
        for (const indice of this.checkedList) {
          this.baja(indice);
        }
        this.consultarPais();
        } else {
            this.showNotification('top', 'right');
        }
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

    startTimer() {
        this.interval = setInterval(() => {
            if(this.paises != null && this.load){
                $('#datatablespais').DataTable({
                    'pagingType': 'full_numbers',
                    'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']],
                    responsive: true,
                    'sDom': '<"H"lr>t<"F"ip>',
                    language: {
                    //search: '_INPUT_',
                    //searchPlaceholder: 'Search records',
                    lengthMenu: 'Mostrar _MENU_ registros',
                    info: 'Mostrar registros del _START_ al _END_ de un total de _TOTAL_.'
                    }
                });
                const table: any = $('#datatablespais').dataTable()
                $('#searchbox').keyup(function() {
                    table.fnFilter( $(this).val() );
                });
                this.load = false
                clearInterval(this.interval)                
            }
        },10)
    }

    handleFileInput(files: FileList, ) {
        this.fileToUpload = files.item(0);
        this.paisServicio.archivoCSV(this.fileToUpload,'syspais','sysidPais,Clave,Nombre').subscribe(datos => {
          if(datos['resultado'] === 'OK'){
            this.consultarPais();
          }
          }, error => {
            console.log(error);
          });
      }
        
    baja(idEntidad){
        this.paisServicio.modificar('sysPais', 'Baja=1', 'sysIdPais='+idEntidad.toString()).subscribe(
            datos => {
                if(datos['resultado'] === 'OK')
                    console.log(datos['error']);
            }
        );
    }
}
