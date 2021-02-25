import { Component, OnInit } from '@angular/core';
import { ConfiguracionesService } from '../configuraciones.service';
import { NullTemplateVisitor } from '@angular/compiler';
import swal from 'sweetalert2';

declare var $: any;

declare interface EntidadTable{
  sysidEntidad: number,
  Clave: string,
  Nombre: string
}

declare interface EntidadInt {
  headerRow: string[];
  dataRows: EntidadTable[];
}

@Component({
  moduleId: module.id,
  selector:'data-table-cmp',
  templateUrl: 'entidad.component.html'
})

export class EntidadComponent implements OnInit {
  masterSelected: boolean;
  checkedList: any[] = [];
  public interval;
  public load = true;
  public intEntidad: EntidadInt;

  entidades = null;

  public seleccionados: number[] = [];

  fileToUpload: File = null;

  constructor(private servicio: ConfiguracionesService) {
    this.masterSelected = false;
  }

  ngOnInit() {
    this.consultarEntidad();
    this.startTimer();
  }

  checkUncheckAll() {
    for (let i = 0; i < this.entidades.length; i++) {
        this.entidades[i].isSelected = this.masterSelected;
    }
    this.getCheckedItemList();
  }

  isAllSelected() {
    this.masterSelected = this.entidades.every(function(item: any) {
      return item.isSelected === true;
    });
    this.getCheckedItemList();
  }

 getCheckedItemList() {
    this.checkedList = [];
    for (let i = 0; i < this.entidades.length; i++) {
        if (this.entidades[i].isSelected) {
            this.checkedList.push(this.entidades[i].sysidEntidad);
        }
    }
 }

  consultarEntidad() {
    this.servicio.consultar('sysentidad', 'sysidEntidad,Clave,Nombre', 'Baja=0').subscribe(
      result => this.entidades = result
    );
  }

  eliminarEntidad(IdEntidad, Clave) {
    this.servicio.eliminar('sysentidad', 'SysIdEntidad=' + IdEntidad + ' and Clave=\'' + Clave + '\'').subscribe(
      datos => {
        if(datos['resultado'] === 'OK') {
          alert(datos['mensaje']);
          this.consultarEntidad();
        }
      }
    );
  }

  bajaEntidad(IdEntidad) {
    this.servicio.modificar('sysentidad', 'Baja=1', 'sysIdEntidad=' + IdEntidad.toString()).subscribe(
      datos => {
        if(datos['resultado'] === 'OK') {
          this.consultarEntidad();
        }
      }
    );
  }

  handleFileInput(files: FileList, ) {
    this.fileToUpload = files.item(0);
    this.servicio.archivoCSV(this.fileToUpload, 'sysentidad', 'sysidEntidad,Clave,Nombre').subscribe(datos => {
      if (datos['resultado'] === 'OK') {
        alert(datos['mensaje']);
        this.consultarEntidad();
      }
      }, error => {
        console.log(error);
      });
  }

  busqueda() {
    const table: any = $('#datatablesentidad').dataTable();
    $('#ebBusqueda').keyup(function() {
        table.fnFilter( $(this).val() );
    });
  }

  eliminarMasivo() {
    if (this.checkedList.length > 0) {
      for (const indice of this.checkedList) {
        this.bajaEntidad(indice);
      }
      this.consultarEntidad();
      window.location.reload();
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
          if(this.entidades != null && this.load) {
              $('#datatablesentidad').DataTable({
                  'pagingType': 'full_numbers',
                  'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']],
                  responsive: true,
                  'sDom': '<"H"lr>t<"F"ip>',
                  language: {
                  lengthMenu: 'Mostrar _MENU_ registros',
                  info: 'Mostrar registros del _START_ al _END_ de un total de _TOTAL_.'
                  }
              });
              const table: any = $('#datatablesentidad').dataTable()
              $('#searchbox').keyup(function() {
                  table.fnFilter( $(this).val() );
              });
              this.load = false
              clearInterval(this.interval);
          }
      }, 1000)
  }

  hayDatos() {
    return true;
  }
}
