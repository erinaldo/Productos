import {ModPOSService} from 'app/configuraciones/pais/pais.service'

declare var services: ModPOSService
declare var termino:boolean 

export class ModPOS{
    termino=false;
    
    onFileSelect(input: HTMLInputElement, sp:string, campos:string) {
        return new Promise(function(resolve, reject){
            var files = input.files;
            let arrayFilas:string[][]=[];
            var pruebas:ModPOSService;
            var fr = new FileReader();
            fr.onload =  function(e) {
              var text = fr.result;
              var rows = text.toString().split("\n");
              var parametros:string;
              var paramArray;
              var camposArray = campos.split(",");
              //Incorporo los valores de cada celda a arrayFilas.
              for (var t=0;t<rows.length-1;t++) {
                  if (rows[t].length!=0) {
                      parametros = "0,"; //La variable de baja = 0
                      paramArray = rows[t].split(",");
                      for(var i=0; i<paramArray.length;i++){
                        if(camposArray[i] = 'int')
                            parametros += paramArray[i].toString();
                        else if(camposArray[i] = 'string')
                            parametros += `'`+paramArray[i].toString()+`'`;
                        
                        parametros += ",";
                      }

                      parametros += '0' //Se enviara el usuario que modifico
                      console.log(parametros);
                      pruebas.guardar(sp,parametros);
                      arrayFilas.push(rows[t].split(","));
                  }
              }

              fr.onerror = function(error){
                reject(error);
              }
            };
            fr.readAsText(files[0],'ISO-8859-4');
        });
    }

}