package mx.elephantworks.iselling

class Categoria {
    boolean activo = true
    String imagen
    String identificador
    String nombre

    static hasMany = [productos:Producto]
    static belongsTo = [empresa:Empresa]

    static constraints = {
        identificador nullable: false, validator:  { val, obj ->
            def _noValido = false
            Categoria.withNewSession {
                _noValido = Categoria.isUnique(obj.id,obj.identificador,null,obj.empresa).count()>0
            }
            return !_noValido
        }
        imagen nullable: true
        nombre nullable: false, validator:  { val, obj ->
            def _noValido = false
            Categoria.withNewSession {
                _noValido = Categoria.isUnique(obj.id,null,obj.nombre,obj.empresa).count()>0
            }
            return !_noValido
        }
        activo default:true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
        isUnique { Long idNuevo, String identificadorNuevo, String nombreNuevo, Empresa empresaNuevo ->
            activos()
            if(idNuevo)
                not{idEq idNuevo}
            if(identificadorNuevo && nombreNuevo){
                or {
                    eq 'identificador', identificadorNuevo
                    eq 'nombre', nombreNuevo
                }
            }else{
                if (identificadorNuevo)
                    eq 'identificador', identificadorNuevo
                if (nombreNuevo)
                    eq 'nombre', nombreNuevo
            }
            if (empresaNuevo)
                empresa { idEq empresaNuevo.id }
        }
    }

    def beforeValidate(){
        if(identificador) identificador = identificador.toUpperCase()
        if(nombre) nombre = nombre.toUpperCase()
    }
    def beforeDelete() {
        Categoria.executeUpdate("update Categoria c set activo = false where id = :id", [id: id])
        return false
    }


    @Override
    public String toString() {
        return nombre;
    }
}
