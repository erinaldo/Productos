app.controller('globalPorRutaAFRController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');

    ctrl.showList = false;
    ctrl.showSelect = undefined;
    ctrl.nShowLists = nShowLists;
    ctrl.selectedItem = ctrl.selectedItem;
    ctrl.OnSelectChange = OnSelectChange;
    ctrl.minDate = new Date();

    //muestra el segundo datepicker cuando el estado de la fecha es 'Entre'
    function OnSelectChange(state) {
        if (state == 'Entre') {
            ctrl.showSelect = 'true';
        }
        else {
            ctrl.showSelect = undefined;
        }
    }

    function nShowLists(state) {
        if (state == undefined) {
            ctrl.showList = undefined;
        }
        else {
            ctrl.showList = 'true';
        }
    }

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            ctrl.titulo = result[0].Descripcion;
        });

        GetRutas();
    }

    ////Cedis config
    //var load = [GetRutas()]

    //$q.all(load).then(function () {
    //})

    var self = this;
    self.simulateQuery = false;
    self.isDisabled = false;
    self.querySearch = querySearch;
    self.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;

    //load maps on sidebar menu

    function querySearch(query) {

        var results = query ? self.states.filter(createFilterFor(query)) : self.states,
            deferred;

        if (self.simulateQuery) {
            deferred = $q.defer();
            $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
            return deferred.promise;
        } else {
            return results;
        }
    }

    function createFilterFor(query) {
        var lowercaseQuery = angular.lowercase(query);
        return function filterFn(state) {
            return (state.value.indexOf(lowercaseQuery) === 0);
        };
    }

    function searchTextChange(text) {
        //console.log('Text changed to ' + text);
    }

    function selectedItemChange(item) {
        $log.info('Item changed to ' + JSON.stringify(item));
    }

    function loadAll(s) {
        var allstates = s;
        return allstates.toString().split(',').map(function (state) {
            return {
                value: state.toString().substr(0, state.indexOf(' ')),
                display: state
            };
        });
    }

    function GetRutas() {
        $http({
            url: url + '/api/GetRoutes?Cedis=',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            ctrl.rutas = response.data;
        }, function errorCallBack(response) {

        });
    }

    //dates state functions
    ctrl.State = undefined;
    ctrl.dateState = GetDates();

    function GetDates() {
        valorReferencia.obtenerValorClave('BFNUMERI', '7', function (result) {
            ctrl.State = 7;
            ctrl.dateState = result;

        });
    }

    ctrl.SubmitForm = SubmitForm;
    ctrl.date1 = undefined;
    ctrl.date2 = undefined;
    ctrl.pvEsFecha = false;
    ctrl.VAVClave = undefined;
    ctrl.ReportType = false;

    ctrl.startbar = function () {
        cfpLoadingBar.start();
    };

    ctrl.completebar = function () {
        cfpLoadingBar.complete();
    };

    //envia el formulario completo
    function SubmitForm(dateStatus, Routes, pvEsFecha, campoFecha) {
        //console.log(ctrl.State);
        var countRutas = 0;
        angular.forEach(ctrl.rutas, function (item) {

            if (item.Checked == true) {
                countRutas++;
            }
        });

        if (countRutas <= 0) {
            alert("Seleccione ruta");
            cfpLoadingBar.complete();
        }
        else if (ctrl.State == undefined) {
            alert("Seleccione rango de fechas");
            cfpLoadingBar.complete();
        }
        else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
            alert("Seleccion rango de fechas");
            cfpLoadingBar.complete();
        }
        else if (ctrl.date1 == undefined) {
            alert("Seleccion fecha");
            cfpLoadingBar.complete();
        }
        else {
            var data = {
                nombreReport: ctrl.titulo,
                dateStatus: ctrl.State,
                Routes: ctrl.rutas,
                init: moment(ctrl.date1).format('YYYY-MM-DD'),
                end:moment(ctrl.date2).format('YYYY-MM-DD'),
                vavclave: ctrl.VAVClave,
                reportType: false,
                Cedis: "",
                nombreCedis: ""
            }
            if (data.Cedis == undefined)
                data.Cedis = ""; if (data.Cedis == undefined)
                    data.Cedis = "";

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }

    ctrl.SelectAllChekboxesRutas = SelectAllChekboxesRutas

    function SelectAllChekboxesRutas(selectAll) {
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(ctrl.rutas, function (item) {
                item.Checked = true;
            });
        }

        else {
            angular.forEach(ctrl.rutas, function (item) {
                item.Checked = false;
            });
        }
    }

    var last = { bottom: true, top: false, left: true, right: false };


    //toast
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
}]);