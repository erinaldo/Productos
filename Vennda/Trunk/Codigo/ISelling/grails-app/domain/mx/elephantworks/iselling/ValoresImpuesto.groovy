package mx.elephantworks.iselling

import org.apache.commons.lang.time.DateUtils
import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class ValoresImpuesto{
    boolean activo = true

    @BindUsing({ object, source -> return new BigDecimal(source['tasa']) })
    BigDecimal tasa

    @BindingFormat('dd-mm-yyyy')
    Date inicio

    @BindingFormat('dd-mm-yyyy')
    Date fin

    //static belongsTo = ['impuesto':Impuesto]

    static constraints = {
        /*tasa min:new BigDecimal('0'), validator: { val, obj ->
            if(obj.impuesto?.tipoAplicacion == TipoAplicacion.PORCENTAJE && val > new BigDecimal('100'))
                return false
            return true
        }
        impuesto validator: { val, obj ->
            def _noValido = false
            ValoresImpuesto.withNewSession {
                _noValido = ValoresImpuesto.isUnique(obj.id, obj.tasa, obj.impuesto).count() > 0
            }
            return !_noValido
        }*/
        inicio validator: { val, obj ->
            def _noValido = false
            ValoresImpuesto.withNewSession {
                //_noValido = ValoresImpuesto.isValidDate(obj.id, obj.inicio, obj.impuesto).count()>0
            }
            return !_noValido
        }
        activo default:true
    }
    static namedQueries = {
        activos CustomNamedQueries.filtroActivo()
        isUnique { Long idNuevo, tasaN, impuestoN ->
            activos()
            if(idNuevo != null)
                not{idEq idNuevo}
            if (impuestoN != null)
                eq 'impuesto', impuestoN
            if (tasaN != null)
                eq 'tasa', tasaN

            projections {
                rowCount()
            }
        }
        isValidDate { Long idNuevo, fechaN, impuestoN ->
            activos()
            if(idNuevo != null)
                not{idEq idNuevo}
            if (impuestoN != null)
                eq 'impuesto', impuestoN
            ge 'inicio',fechaN
            le 'fin', fechaN
            projections {
                rowCount()
            }
        }
    }

    void setInicio(Date inicio) {
        this.inicio = DateUtils.truncate(inicio, Calendar.DATE)
    }

    void setFin(Date fin) {
        this.fin = DateUtils.truncate(fin, Calendar.DATE)
    }

    def beforeDelete() {
        ValoresImpuesto.executeUpdate("update ValoresImpuesto vi set activo = false where id = :id", [id: id])
        return false
    }

    @Override
    public String toString() {
        def _string = tasa + " -> (";
        if(inicio)
            _string += inicio.format("dd-mm-yyyy")
        _string += ") - ("
        if(fin)
            _string += fin.format("dd-mm-yyyy")
        _string += ") "
        return _string
    }
}