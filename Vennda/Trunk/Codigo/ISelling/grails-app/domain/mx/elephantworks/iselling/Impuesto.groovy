package mx.elephantworks.iselling

class Impuesto {
    boolean activo = true

    String identificador
    int jerarquia
    boolean despuesDeImpuesto = true
    TipoAplicacion tipoAplicacion

    static hasMany = [valores:ValoresImpuesto]

    static constraints = {
        tipoAplicacion blank:false
        identificador nullable: false, validator: { val, obj ->
            def _noValido = false
            Impuesto.withNewSession {
                _noValido = Impuesto.isUnique(obj.id, obj.identificador).count()>0
            }
            return !_noValido
        }
        activo default:true
        jerarquia nullable:true
    }

    static namedQueries = {
        activos CustomNamedQueries.filtroActivo()
        isUnique { Long idNuevo, identificador ->
            activos()
            if(idNuevo != null)
                not{idEq idNuevo}
            if (identificador != null)
                eq 'identificador', identificador
        }

    }
    def beforeDelete() {
        Impuesto.executeUpdate("update Impuesto i set activo = false where id = :id", [id: id])
        ValoresImpuesto.executeUpdate("update ValoresImpuesto vi set activo = false where vi.impuesto.id = :id", [id: id])

        return false
    }

    @Override
    public String toString() {
        return identificador + " " + jerarquia
    }
}
enum TipoAplicacion {
    PORCENTAJE(1), IMPORTE(2)
    private final Integer value
    TipoAplicacion(Integer value) {
        this.value = value
    }
    Integer getId(){
        value
    }
}