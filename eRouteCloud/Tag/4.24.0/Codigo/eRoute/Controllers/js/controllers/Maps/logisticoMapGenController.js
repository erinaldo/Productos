(function () {
    angular
        .module('eRouteApp')
        .controller('logisticoMapGenController', logisticoMapGenController)
    logisticoMapGenController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function logisticoMapGenController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');
        ctrl.rutas;
        ctrl.showRutas = false;        

        //console.log(ctrl.rutas);

        ctrl.lat = 23.5309891;
        ctrl.long = -104.5345101;
        ctrl.zoom = 11;

        cargarRutas();
        function cargarRutas() {
            ctrl.data = window.opener.data;
            GetMapCoordinates();
            ctrl.showRutas = true;
        }
        
        ctrl.mapListCoordinates = ctrl.mapListCoordinates;
        ctrl.GetMapCoordinates = GetMapCoordinates;
        ctrl.RouteSelected = "Route";
        ctrl.mapDate = undefined;
        ctrl.test = ctrl.test;
        ctrl.lat = 23.5309891;
        ctrl.long = -104.5345101;
        ctrl.zoom = 11;

        NgMap.getMap().then(function (map) {
            ctrl.map = map;

        });

        $timeout(function () { $('#direOarea').focus(); });

        $scope.refreshMap = function () {
            google.maps.event.trigger($scope.map, 'resize');
        }

        $scope.mycallback = function (map) {
            $scope.mymap = map;
            $scope.$apply();
        };

        function GetMapCoordinates(){
                ctrl.lat = 0;
                ctrl.long = 0;
                ctrl.zoom = 0;

                ctrl.mapListCoordinates = ctrl.data;

                ctrl.mapFrequencyList = ctrl.data.ListFreq;
                ctrl.mapNoFrequencyList = ctrl.data.ListOutFreq;
                ctrl.nVisit = ctrl.data.ListNoVisit;
                ctrl.Real = ctrl.data.ListReal;
                ctrl.Config = ctrl.data.ListAgenda;
                ctrl.OutRange = ctrl.data.ListOutRange;
                ctrl.Tracking = ctrl.data.ListTracking;

                $timeout(function () {
                    ctrl.lat = ctrl.data.longitude;
                    ctrl.long = ctrl.data.latitude;
                    ctrl.zoom = 11;
                });

                //console.log("3lon " + ctrl.long + " lat " + ctrl.lat);

                //FilterbyFrequency();
                if ((ctrl.mapListCoordinates.ListFreq == "" && ctrl.mapListCoordinates.ListOutFreq == "" && ctrl.mapListCoordinates.ListNoVisit == "")) {

                    //ctrl.map.shapes.foo.setMap(null);
                    //ctrl.map.shapes.foo2.setMap(null);
                    //ctrl.map.shapes.foo3.setMap(null);
                    ////ctrl.map.shapes.foo4.setMap(null);
                    ////ctrl.map.shapes.foo5.setMap(null);
                    //ctrl.map.shapes.foo6.setMap(null);
                }
                else {
                    $scope.outFreq = ctrl.mapNoFrequencyList.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })
                    $scope.noVisit = ctrl.nVisit.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })
                    $scope.Freq = ctrl.mapFrequencyList.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })

                    $scope.reallist = ctrl.Real.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })
                    $scope.configurated = ctrl.Config.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })
                    $scope.outRangePath = ctrl.OutRange.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })
                    $scope.tracking = ctrl.Tracking.map(function (marker) {
                        return [marker.CoordenadaY, marker.CoordenadaX];
                    })

                    //ctrl.map.shapes.foo.setMap(ctrl.map);
                    //ctrl.map.shapes.foo2.setMap(ctrl.map);
                    //ctrl.map.shapes.foo3.setMap(ctrl.map);
                    /////ctrl.map.shapes.foo4.setMap(ctrl.map);
                    /////ctrl.map.shapes.foo5.setMap(ctrl.map);
                    //ctrl.map.shapes.foo6.setMap(ctrl.map);
                    ctrl.u = true;
                    ctrl.e = true;
                    ctrl.t = true;
                    ctrl.k = true;
                    ctrl.l = true;
                    ctrl.p = true;
                    ctrl.q = true;

                }

            }

        ctrl.u = true;
        ctrl.e = true;
        ctrl.t = true;
        ctrl.k = true;
        ctrl.l = true;
        ctrl.p = true;
        ctrl.q = true;

        ctrl.filter1 = filter1;
        ctrl.filter2 = filter2;
        ctrl.filter3 = filter3;
        ctrl.filter4 = filter4;
        ctrl.filter5 = filter5;
        ctrl.filter6 = filter6;
        ctrl.filter7 = filter7;

        function filter1() {
            if (ctrl.u == true) {
                ctrl.mapFrequencyList = null;
                //ctrl.map.shapes.foo.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo.setMap(ctrl.map);
                ctrl.mapFrequencyList = ctrl.mapListCoordinates.ListFreq;
            }
        }

        function filter2() {
            if (ctrl.e == true) {
                ctrl.mapNoFrequencyList = null;
                //ctrl.map.shapes.foo2.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo2.setMap(ctrl.map);
                ctrl.mapNoFrequencyList = ctrl.mapListCoordinates.ListOutFreq;
            }
        }

        function filter3() {
            if (ctrl.t == true) {
                ctrl.nVisit = null;
                //ctrl.map.shapes.foo3.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo3.setMap(ctrl.map);
                ctrl.nVisit = ctrl.mapListCoordinates.ListNoVisit;
            }
        }

        function filter4() {
            if (ctrl.k == true) {
                ctrl.Real = null;
                ctrl.map.shapes.foo4.setMap(null);
            }
            else {
                ctrl.map.shapes.foo4.setMap(ctrl.map);
                ctrl.Real = ctrl.mapListCoordinates.ListReal;
            }
        }

        function filter5() {
            if (ctrl.l == true) {
                ctrl.Config = null;
                ctrl.map.shapes.foo5.setMap(null);
            }
            else {
                ctrl.map.shapes.foo5.setMap(ctrl.map);
                ctrl.Config = ctrl.mapListCoordinates.ListAgenda;
            }
        }

        function filter6() {
            if (ctrl.p == true) {
                ctrl.OutRange = null;
                //ctrl.map.shapes.foo6.setMap(null);
            }
            else {
                //ctrl.map.shapes.foo6.setMap(ctrl.map);
                ctrl.OutRange = ctrl.mapListCoordinates.ListOutRange;
            }
        }

        function filter7() {
            if (ctrl.q == true) {
                ctrl.Tracking = null;
                ctrl.map.shapes.foo7.setMap(null);
            }
            else {
                ctrl.map.shapes.foo7.setMap(ctrl.map);
                ctrl.Tracking = ctrl.mapListCoordinates.ListTracking;
            }
        }


        ctrl.ShowInfo = function (evt, id) {
            ctrl.infoWindowPosition = ctrl.mapFrequencyList[id];
            ctrl.map.showInfoWindow('bar', 'custom-marker-' + id);
        };

        ctrl.ShowInfoOutFreq = function (evt, id) {
            ctrl.infoWindowPosition = ctrl.mapNoFrequencyList[id];
            ctrl.map.showInfoWindow('OutFreq', 'custom-marker2-' + id);
        };

        ctrl.ShowInfoTracking = function (evt, id) {
            ctrl.infoWindowPosition = ctrl.Tracking[id];
            ctrl.map.showInfoWindow('Tracking', 'custom-marker3-' + id);
        };
    }
})();