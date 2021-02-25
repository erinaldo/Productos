app.controller('scoreCardController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    //Inicialización de variables
    var ctrl = this;
    var url = window.sessionStorage.getItem('URL');
    ctrl.url = undefined;
    ctrl.showList = false;
    ctrl.showSelect = undefined;
    ctrl.nShowLists = nShowLists;
    ctrl.selectedItem = ctrl.selectedItem;
    ctrl.OnSelectChange = OnSelectChange;
    ctrl.minDate = new Date();

    ctrl.SubmitForm = SubmitForm;
    ctrl.date1 = undefined;
    ctrl.pvEsFecha = false;
    ctrl.VAVClave = undefined;

    var self = this;
    self.simulateQuery = false;
    self.isDisabled = false;
    self.querySearch = querySearch;
    self.selectedItemChange = selectedItemChange;
    self.searchTextChange = searchTextChange;


    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            ctrl.titulo = result[0].Descripcion;
        });

        GetCedis();
    }

    ////Carga la lista de CEDIS
    //var load = [GetCedis()]
    //$q.all(load).then(function () {
    //})

    function OnSelectChange(state) {
        if (state === 'Entre') {
            ctrl.showSelect = 'true';
        }
        else {
            ctrl.showSelect = undefined;
        }
    }

    function nShowLists(state) {
        if (state === undefined) {
            ctrl.showList = undefined;
        }
        else {
            ctrl.showList = 'true';
        }
    }

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
            self.dateState = response.data;
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
            self.states = response.data;
        }, function errorCallBack(response) {

        });
    }

    ctrl.startbar = function () {
        cfpLoadingBar.start();
    };

    ctrl.completebar = function () {
        cfpLoadingBar.complete();
    };

    ctrl.esquemas = GetEsquemas();
    ctrl.GetEsquemas = GetEsquemas;

    function GetEsquemas() {
        $http({
            url: url + '/api/GetScheme?Tipo=2&Nivel=1',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            ctrl.esquemas = response.data;
        }, function errorCallBack(response) {
        });
    }

    //Seleccionar todos los esquemas a la vez
    ctrl.SelectAllCheckBoxesEsquemas = SelectAllCheckBoxesEsquemas;

    function SelectAllCheckBoxesEsquemas(selectAll) {
        if (selectAll === undefined || selectAll === false) {
            angular.forEach(ctrl.esquemas, function (item) {
                item.Checked = true;
            });
        }
        else {
            angular.forEach(ctrl.esquemas, function (item) {
                item.Checked = false;
            });
        }
    }

    ctrl.ClearEsquemasCheckBoxes = ClearAllEsquemasCheckBoxes;

    function ClearAllEsquemasCheckBoxes() {
        $scope.fil = [];

        angular.forEach(ctrl.esquemas, function (item) {
            if (item.Checked == true) {
                $scope.fil.push(item.Checked);
            }
        });

        if ($scope.fil.length > 0) {
            angular.forEach(ctrl.esquemas, function (item) {
                item.Checked = false;
                //item.Disabled = true;

            });
            $scope.EsqumasSelectAllCheckBox = true;
            $scope.selectAll = false;
        }
        else if ($scope.fil.length == 0) {
            angular.forEach(ctrl.esquemas, function (item) {
                item.Checked = false;
                //item.Disabled = false;

            });
            $scope.EsqumasSelectAllCheckBox = false;
            $scope.selectAll = false;
        }

    }

    function SubmitForm(Cedis, dateStatus, Esquemas, pvEsFecha, campoFecha) {
        if (ctrl.State === undefined) {
            alert("Seleccione rango de fechas");
            cfpLoadingBar.complete();
        }
        else if (ctrl.date1 === undefined) {
            alert("Seleccione una fecha");
            cfpLoadingBar.complete();
        }
        else {
            var data = {
                nombreReport: ctrl.titulo,
                Cedis: ctrl.selectedItem.value,
                nombreCedis: ctrl.selectedItem.display,
                dateStatus: ctrl.State,
                ProductsSchema: Esquemas,
                init: moment(ctrl.date1).format('YYYY-MM-DD'),
                end:moment(ctrl.date2).format('YYYY-MM-DD'),
                vavclave: ctrl.VAVClave
            }

            $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
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
}]);