/**
 * Created by HAMG on 16/07/16.
 */

import mx.elephantworks.iselling.CustomUserDetails
import mx.elephantworks.iselling.Empresa
class CustomFilters {
    def springSecurityService
    def filters = {

        userFilter(controller: '*', action: '*') {
            before = {
                params.usuario = springSecurityService.currentUserId
                log.info params.usuario
            }
        }
        empresaFilter(controller: '*'){
            before = {
                params.empresa = null
                if(springSecurityService.principal instanceof CustomUserDetails)
                    params.empresa = springSecurityService.principal.empresa
                log.info params.empresa
            }
        }
    }
}
