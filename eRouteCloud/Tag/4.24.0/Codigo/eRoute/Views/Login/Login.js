
(function () {
    angular
       .module('loginApp', ['ngMaterial', 'angular-loading-bar', 'ngAnimate'])
       .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
           cfpLoadingBarProvider.includeBar = true;
           cfpLoadingBarProvider.includeSpinner = false;
       }])
       .controller('login', function ($location, $scope, $http, $mdToast, $rootScope, cfpLoadingBar) {

           var ctrl = this;
           ctrl.SendLogin = SendLogin;
           ctrl.logButton = false;

           var VirtualPath = $('#linkRoot').first().attr('href');

           if (VirtualPath == "/")
           {
               VirtualPath = "";
           }
           window.sessionStorage.setItem('URL', VirtualPath);

           function SendLogin() {
               ctrl.logButton = true;
               $http.post(VirtualPath + '/api/auth', {
                   userName: ctrl.UserName,
                   Password: ctrl.Password
               })
               .success(function (data, status, headers, config) {
                   $http.post(VirtualPath + '/Login/SetSession', {
                       URL: window.sessionStorage.getItem('URL'),
                       USUId: data.USUId,
                       PERClave: data.PERClave
                   })
                   .success(function (data2, status, headers, config) {                      
                       if (status == 200) {
                           window.sessionStorage.setItem('Clave', data.Clave);
                           window.sessionStorage.setItem('PERClave', data.PERClave);
                           window.sessionStorage.setItem('USUId', data.USUId);
                           window.sessionStorage.setItem('Token', data.Token);
                           window.location = VirtualPath + '/Menu';
                       }
                   });
               })
               .error(function (error, status, headers, config) {
                   ctrl.logButton = false;
                   if (status == 401 || status == 400) {
                       showSimpleToast("Usuario o contraseña incorrectos");
                   }
                   else if (status == 404) {
                       showSimpleToast("El usuario no está registrado");
                   }
                   else if (status == 500)
                   {
                       if (error == "") {
                           showSimpleToast("No se puede conectar con el servidor");
                       }
                       else {
                           showSimpleToast("No se ha podido iniciar sesión");
                       }
                   }
                   else {
                       showSimpleToast("Verificar conexión a internet");
                   }
               });
           }

           //toast control
           var last = { bottom: true, top: false, left: true, right: false };

           $scope.toastPosition = angular.extend({}, last);

           $scope.getToastPosition = function () {
               sanitizePosition();
               return Object.keys($scope.toastPosition)
                 .filter(function (pos) { return $scope.toastPosition[pos]; })
                 .join(' ');
           };

           function sanitizePosition() {
               var current = $scope.toastPosition;
               if (current.bottom && last.top) current.top = false;
               if (current.top && last.bottom) current.bottom = false;
               if (current.right && last.left) current.left = false;
               if (current.left && last.right) current.right = false;
               last = angular.extend({}, current);
           }

          function showSimpleToast(Message) {
               var pinTo = $scope.getToastPosition();
               $mdToast.show(
                 $mdToast.simple()
                   .textContent(Message)
                   .position(pinTo)
                   .hideDelay(3000)
               );
          };

           
          var init = function () {
              //if (window.sessionStorage.getItem('Token') != null) {
              //    window.location = url + '/Menu'
              //}
          };
           
          init();

       });
})();
