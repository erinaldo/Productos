package mx.elephantworks.iselling

class Unidad {

    String abreviatura
    String descripcion

    static hasMany = [productos:Producto]

    static constraints = {
        abreviatura nullable: false
        descripcion nullable: false
    }

    static namedQueries = {
    }

    def beforeValidate(){
        if(abreviatura) abreviatura = abreviatura.toUpperCase()
    }

    @Override
    public String toString() {
        return descripcion
    }
}
