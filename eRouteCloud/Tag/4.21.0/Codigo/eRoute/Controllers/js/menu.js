(function () {
    angular
        .module('eRouteApp')
       .controller('menu', menu)

    menu.$inject = ["$scope", "$http", "cfpLoadingBar", "menuServices", "translationService"];
    function menu($scope, $http, cfpLoadingBar, menuServices, translationService) {

           var ctrl = this;

           var url = window.sessionStorage.getItem('URL');           

           ctrl.url = undefined; 
           ctrl.Logout = Logout;
           ctrl.About = About;      
           translationService.getTranslation($scope);
           ctrl.LogoutDelete = LogoutDelete;

           GetModules();

           LogoutModel = {
               Token: window.sessionStorage.getItem('Token')
           }

           function Logout() {
               menuServices.logout(LogoutModel)
                   .then(function successCallback(response) {
                       LogoutDelete();
                       if (response.status == 200) {
                           window.sessionStorage.clear();
                           window.location = url + '/Login';
                       }
                   },
               function errorCallback(response) {
                   if (response.status == 401) {
                       window.sessionStorage.clear();
                       window.location = url + '/Login';
                   }
               });
           }

           function LogoutDelete() {
               menuServices.LogoutDelete()
                   .then(function successCallback(response) {
                   },
                   function errorCallback(response) {
                       if (response.status == 401) {
                           window.sessionStorage.clear();
                           window.location = url + '/Login';
                       }
                   });
           }


           function About() {
               window.location = url + '/Home/About';
               //window.location.href = '../Home/About';
           }



           function GetModules() {
               $http({
                   url: url + '/api/ProfileList/GetModules?PERClave=' + window.sessionStorage.getItem('PERClave') + '&USUId=' + window.sessionStorage.getItem('USUId').replace(/\+/g, "%2B"),
                   method: 'GET',
                   headers: {                       
                       Authorization: window.sessionStorage.getItem('Token'),
                       'Content-Type': 'application/json'
                   },
               }).success(function (data, status) {                  
                   $scope.modulos = data;
               }).error(function (error, status) {
                   if (status == 401) {
                       window.sessionStorage.clear();
                       window.location = url + '/Login'
                   }
               });
           }

       }
})();
