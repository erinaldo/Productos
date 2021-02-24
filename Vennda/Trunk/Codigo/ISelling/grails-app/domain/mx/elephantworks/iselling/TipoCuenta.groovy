package mx.elephantworks.iselling

class TipoCuenta {

    String descripcion

    static hasMany = [empreas:Empresa]
    static constraints = {
        descripcion nullable: false
    }

    @Override
    public String toString() {
        return descripcion
    }
}
