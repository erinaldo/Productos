package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.hibernate.criterion.DetachedCriteria
import org.hibernate.criterion.Projections
import org.hibernate.criterion.Restrictions
import org.hibernate.criterion.Subqueries

class Producto {
    boolean activo = true

    String clave
    String nombre
    String descripcion
    String codigoBarras
    String imagen
    @BindUsing({ object, source -> return new BigDecimal(source['precio']) })
    BigDecimal precio
    @BindUsing({ object, source -> return new BigDecimal(source['precio2']) })
    BigDecimal precio2
    @BindUsing({ object, source -> return new BigDecimal(source['precio3']) })
    BigDecimal precio3
    @BindUsing({ object, source -> return new BigDecimal(source['precio4']) })
    BigDecimal precio4
    @BindUsing({ object, source -> return new BigDecimal(source['precio5']) })
    BigDecimal precio5

    static hasOne = [unidad:Unidad]
    static belongsTo = [empresa:Empresa,categoria:Categoria]
    static hasMany = [impuesto:Impuesto]

    static constraints = {
        clave nullable: false, validator:  { val, obj ->
            def _noValido = false
            Producto.withNewSession {
                _noValido = Producto.isUnique(obj.id,obj.clave,null,obj.empresa).count()>0
            }
            return !_noValido
        }
        descripcion nullable: false
        codigoBarras nullable: false, validator:  { val, obj ->
            def _noValido = false
            Producto.withNewSession {
                _noValido = Producto.isUnique(obj.id,null,obj.codigoBarras,obj.empresa).count()>0
            }
            return !_noValido
        }
        imagen nullable: true
        precio nullable: false
        activo default:true
        nombre nullable: false, maxSize: 100
        impuesto nullable: true
        unidad nullable: true
        categoria nullable: true
        precio2 nullable: true
        precio3 nullable: true
        precio4 nullable: true
        precio5 nullable: true
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
        productosEmpresaNoLista{ Empresa empresa, String nombre, Long listaPrecioId ->
            filtroEmpresa(empresa.id)
            or {
                ilike 'clave', "%$nombre%"
                ilike 'descripcion', "%$nombre%"
            }
            add Subqueries.propertyNotIn('id',subQuery)
        }
        isUnique { Long idNuevo, String claveNuevo, String codigoBarrasNuevo, Empresa empresaNuevo ->
            activos()
            if(idNuevo)
                not{idEq idNuevo}
            if(claveNuevo && codigoBarrasNuevo){
                or {
                    eq 'clave', claveNuevo
                    eq 'codigoBarras', codigoBarrasNuevo
                }
            }else{
                if (claveNuevo)
                    eq 'clave', claveNuevo
                if (codigoBarrasNuevo)
                    eq 'codigoBarras', codigoBarrasNuevo
            }
            if (empresaNuevo)
                empresa { idEq empresaNuevo.id }
        }
    }

    def beforeValidate(){
        if(clave) clave = clave.toUpperCase()
    }
    def beforeDelete() {
        Producto.executeUpdate("update Producto p set activo = false where id = :id", [id: id])
        return false
    }

    @Override
    public String toString() {
        return clave
    }
}
