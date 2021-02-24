package mx.elephantworks.iselling

import grails.plugin.springsecurity.SecurityTagLib

class CustomTagsTagLib extends SecurityTagLib{

    static defaultEncodeAs = [taglib:'none']
    //static encodeAsForTags = [withAccessSubmit: [taglib:'none']]
    static namespace = "ct"

    def withAccessSubmit = { attrs ->
        if (hasAccess(attrs, 'access')){
            out << actionSubmit(attrs)
        }
    }
}