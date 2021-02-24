/**
 * Created by HAMG on 16/07/16.
 */
package mx.elephantworks.iselling

class CustomNamedQueries {
    static filtroEmpresa(){{ Long u->
        eq 'activo', true
        empresa{
            idEq u
        }
    }}
    static filtroEmpresa2(){{ Long u->
        empresa{
            idEq u
        }
    }}
    static filtroActivo(){{ ->
        eq 'activo', true
    }}

    static saldoMayor(){{ ->
        gt 'saldo', 0
    }}
}
