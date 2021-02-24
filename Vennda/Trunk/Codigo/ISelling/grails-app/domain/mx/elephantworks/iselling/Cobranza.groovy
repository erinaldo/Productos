package mx.elephantworks.iselling

import org.grails.databinding.BindUsing
import org.grails.databinding.BindingFormat

class Cobranza {

    /* private int idCobranza;
      private Venta venta;
      private Abono abono;
      private Date fecha;
      private double saldo;
      private double saldoAbono;*/

    @BindingFormat('dd-mm-yyyy')
    Date fecha
    @BindUsing({ object, source -> return new BigDecimal(source['saldo']) })
    BigDecimal saldo
    @BindUsing({ object, source -> return new BigDecimal(source['saldoAbono']) })
    BigDecimal saldoAbono


    static belongsTo = [venta: Venta,
                        abono: Abono]

    static constraints = {
        fecha nullable: false
        saldo nullable: false
        venta nullable: false
        abono nullable: false
    }

    static namedQueries = {
        filtroEmpresa CustomNamedQueries.filtroEmpresa()
        activos CustomNamedQueries.filtroActivo()
//        saldo {gt 'saldo', 0.0}
    }
}
