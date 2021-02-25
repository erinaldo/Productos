app.controller('ventasPorDiaMorController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');

    ctrl.url = undefined;
    ctrl.showList = false;
    ctrl.showSelect = undefined;
    ctrl.nShowLists = nShowLists;
    ctrl.selectedItem = ctrl.selectedItem;
    ctrl.OnSelectChange = OnSelectChange;
    ctrl.minDate = new Date();
    ctrl.GetList;


    GetList();
    function GetList() {
        menuServices.getReportList()
            .then(function successCallback(response) {
                ctrl.GetList = response.data;
            },
            function errorCallback(response) {
                if (response.status == 401) {
                    window.sessionStorage.clear();
                    window.location = url + '/Login';
                }
            });
    }


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


    var self = this;
    self.simulateQuery = false;
    self.isDisabled = false;
    self.querySearch = querySearch;
    self.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;


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

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            ctrl.titulo = result[0].Descripcion;
        });

        GetCedis();
    }

    ////Cedis config
    //var load = [GetCedis()]
    ////var load = [GetActivityList()]

    //$q.all(load).then(function () {
    //})

    //dates state functions
    ctrl.State = undefined;
    ctrl.dateState = GetDates();

    function GetDates() {
        $http({
            url: url + '/api/GetDateStatus',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            ctrl.dateState = response.data;
            _.remove(ctrl.dateState, function (n) { return n.Descripcion != "Entre" });
        }, function errorCallBack(response) {

        });
    }

    function GetCedis() {
        $http({
            url: url + '/api/GetCedis',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { USUId: window.sessionStorage.getItem('USUId') }
        }).then(function successCallBack(response) {
            //  self.states = loadAll(response.data);
            self.states = response.data;
        }, function errorCallBack(response) {

        });
    }

    //routes functions
    ctrl.routes = GetRoutes();
    ctrl.GetRoutes = GetRoutes;

    function GetRoutes(selectedItem) {
        if (selectedItem == undefined)
            selectedItem = "";
        $http({
            url: url + '/api/GetRoutes?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            ctrl.routes = response.data;
        }, function errorCallBack(response) {


        });
    }

    ctrl.SelectAllChekboxesRoutes = SelectAllChekboxesRoutes;

    function SelectAllChekboxesRoutes(selectAll) {
        if (selectAll == undefined || selectAll == false) {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = true;
            });
        }

        else {
            angular.forEach(ctrl.routes, function (item) {
                item.Checked = false;
            });
        }
    }

    ctrl.SubmitForm = SubmitForm;
    ctrl.date1 = undefined;
    ctrl.date2 = undefined;
    ctrl.pvEsFecha = false;
    ctrl.VAVClave = undefined;
    ctrl.ReportType = false;
    ctrl.UnidadMedida = "Cartones";

    ctrl.startbar = function () {
        cfpLoadingBar.start();
    };

    ctrl.completebar = function () {
        cfpLoadingBar.complete();
    };

    //envia el formulario completo
    function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
        if (Cedis == undefined || Cedis == null) {
            Cedis = {};
        }
        if (ctrl.State == undefined) {
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
                Cedis: Cedis.value,
                nombreCedis: Cedis.display,
                dateStatus: ctrl.State,
                Routes: Routes,
                init: moment(ctrl.date1).format('YYYY-MM-DD'),
                end:moment(ctrl.date2).format('YYYY-MM-DD'),
                vavclave: ctrl.VAVClave,
                reportType: ctrl.ReportType,
                unidadMedida: ctrl.UnidadMedida
            }

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
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