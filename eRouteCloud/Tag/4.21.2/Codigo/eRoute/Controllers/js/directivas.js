var app = angular.module('directivas', []);

app.directive("validarEmail", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            element.ready(function () {
                ngModel.$asyncValidators.emailInvalido = function (modelValue, viewValue) {
                    var defer = $q.defer();
                    if (modelValue != "" && modelValue != null) {
                        if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(modelValue)) {
                            console.log("La dirección de email es correcta!.");
                            defer.resolve();
                        } else {
                            console.log("La dirección de email es incorrecta!.");
                            defer.reject();
                        }
                    } else {
                        defer.resolve();
                    }
                    return defer.promise;
                }
            });
        }
    }
})

app.directive("validarRfc", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            var url = window.sessionStorage.getItem('URL');
            element.ready(function () {
                ngModel.$asyncValidators.rfcInvalido = function (modelValue, viewValue) {
                    var defer = $q.defer();
                    //Se retiran los guiones de la cadena
                    var rfcLimpio = modelValue.toString().replace(/-/g, "");
                    var tam = rfcLimpio.length;
                    if (modelValue = ! "" && modelValue != null) {
                        if (tam > 14) {
                            defer.reject();
                        } else {
                            defer.resolve();
                        }
                    }
                    //  defer.reject();
                    return defer.promise;
                }
            });
        }
    }
});

app.directive("validarTelefono", function ($http, $q) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function ($scope, element, attrs, ngModel) {
            element.ready(function () {
                ngModel.$asyncValidators.telefonoInvalido = function (modelValue, viewValue) {
                    var defer = $q.defer();
                    if (modelValue != "" && modelValue != null) {
                        if (/^[0-9]+(,[0-9]+)*$/i.test(modelValue)) {
                            defer.resolve();
                        } else {
                            defer.reject();
                        }
                    } else {
                        defer.resolve();
                    }
                    return defer.promise;
                }
            });
        }
    }
})

app.directive('validNumber', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }

            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }

                var clean = val.replace(/[^-0-9\.]/g, '');
                var negativeCheck = clean.split('-');
                var decimalCheck = clean.split('.');
                if (!angular.isUndefined(negativeCheck[1])) {
                    negativeCheck[1] = negativeCheck[1].slice(0, negativeCheck[1].length);
                    clean = negativeCheck[0] + '-' + negativeCheck[1];
                    if (negativeCheck[0].length > 0) {
                        clean = negativeCheck[0];
                    }

                }

                if (!angular.isUndefined(decimalCheck[1])) {
                    decimalCheck[1] = decimalCheck[1].slice(0, 2);
                    clean = decimalCheck[0] + '.' + decimalCheck[1];
                }

                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });

            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});

app.directive("moveNextOnMaxlength", function () {
    return {
        restrict: "A",
        link: function ($scope, element) {
            element.on("input", function (e) {
                if (element.val().length == element.attr("maxlength")) {
                    var $nextElement = element.next("input");
                    $nextElement.focus();
                }
            });
        }
    }
});