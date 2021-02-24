package mx.elephantworks.iselling

import org.grails.databinding.BindUsing

class Cliente {
    boolean activo = true

    String clave
    String razonSocial
    String rfc
    String domicilio
    String colonia
    String cp
    short diasCredito
    @BindUsing({ object, source -> return new BigDecimal(source['limiteCredito']) })
    BigDecimal limiteCredito
    @BindUsing({ object, source -> return new BigDecimal(source['creditoActual']) })
    BigDecimal creditoActual = 0.0
    String email
    Integer listaPrecios
    String telefonoCelular
    Integer alta = 1

    static belongsTo = [empresa:Empresa,
                        pais: Pais,
                        entidad: Entidad,
                        ciudad: Ciudad]


    static constraints = {
        clave nullable: false, validator:  { val, obj ->
            def _noValido = false
            Cliente.withNewSession {
                _noValido = Cliente.isUnique(obj.id,obj.clave,null,obj.empresa).count()>0
            }
            return !_noValido
        }
        razonSocial nullable: false
        rfc nullable: true, validator:  { val, obj ->
            def _noValido = false
            Cliente.withNewSession {
                _noValido = Cliente.isUnique(obj.id,null,obj.rfc,obj.empresa).count()>0
            }
            return !_noValido
        }
        domicilio nullable: true
        colonia nullable: true
        cp nullable: true
        pais nullable: true
        entidad nullable: true
        ciudad nullable: true
        listaPrecios nullable: false,min:1,max:5
        limiteCredito nullable: true
        email nullable: true
        activo default:true
        telefonoCelular nullable: true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
        isUnique { Long idNuevo, String claveNuevo, String rfcNuevo, Empresa empresaNuevo ->
            activos()
            if(idNuevo)
                not{idEq idNuevo}
            if(claveNuevo && rfcNuevo){
                or {
                    eq 'clave', claveNuevo
                    eq 'rfc', rfcNuevo
                }
            }else{
                if (claveNuevo)
                    eq 'clave', claveNuevo
                if (rfcNuevo)
                    eq 'rfc', rfcNuevo
            }
            if (empresaNuevo)
                empresa { idEq empresaNuevo.id }
        }
    }

    def beforeValidate(){
        if(rfc) rfc = rfc.toUpperCase()
        if(clave) clave = clave.toUpperCase()
    }
    def beforeDelete() {
        Cliente.executeUpdate("update Cliente c set activo = false where id = :id", [id: id])
        return false
    }

    @Override
    public String toString() {
        return clave
    }
}
