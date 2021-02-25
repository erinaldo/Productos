app
    .config(function ($mdDateLocaleProvider) {
        $mdDateLocaleProvider.formatDate = function (date) {
            return date ? moment(date).format('DD-MM-YYYY') : '';
        };

        $mdDateLocaleProvider.parseDate = function (dateString) {
            var m = moment(dateString, 'DD-MM-YYYY', true);
            return m.isValid() ? m.toDate() : new Date(NaN);
        };

        $mdDateLocaleProvider.isDateComplete = function (dateString) {
            dateString = dateString.trim();
            var re = /^(([a-zA-Z]{3,}|[0-9]{1,4})([ .,]+|[/-]))([a-zA-Z]{3,}|[0-9]{1,4})/;
            return re.test(dateString);
        };
    })
    .controller('dynamicReportController', ['$scope', 'valorReferencia', 'reportServices', '$http', 'cfpLoadingBar', function ($scope, valorReferencia, reportServices, $http, cfpLoadingBar) {
        var self = this;
        self.filtersRequiredList = [];
        var url = window.sessionStorage.getItem('URL');

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        $scope.EstablecerReporte = function (VAVClave) {
            return valorReferencia.obtenerValorClave('REPORTED', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
                self.VAVClave = VAVClave;
                FiltersRequired();
            });
        }

        function FiltersRequired() {
            valorReferencia.obtenerFiltrosDinamicos(self.VAVClave, function (result) {
                self.filtersList = result;
                self.GetConditionedFilter();
            });
        }

        self.QuerySearch = function (query, name) {
            name = name ? name : {};
            var results = query ? name.filter(createFilterFor(query)) : name;
            return results;
        }

        function createFilterFor(query) {
            var lowercaseQuery = query.toLowerCase();
            return function filterFn(cedis) {
                var dis = cedis.Nombre;
                var lowercaseDispley = dis.toLowerCase();
                return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
            };
        }

        self.GetConditionedFilter = function (filter, dato) {
            var selected = '?';
            var cleanerClient = false;
            var cleanerProd = false;
            var filterCopy = [];
            Object.assign(filterCopy, self.filtersList);
            angular.forEach(self.filtersList, function (value) {
                var temp;
                var selectedList = [];
                var parameterConstruction = [];
                var currentIndex = filterCopy.findIndex(filter => filter['TipoFiltro'] === value['TipoFiltro']);
                var currentFilter = filterCopy.find(filter => filter['TipoFiltro'] === value['TipoFiltro']);
                var currentRequiredIndex = self.filtersRequiredList.findIndex(filter => filter['TipoFiltro'] === value['TipoFiltro']);
                var currentRequiredFilter = self.filtersRequiredList.find(filter => filter['TipoFiltro'] === value['TipoFiltro']);
                if (currentIndex > -1) {
                    Object.assign(filterCopy[currentIndex], { showInactive: undefined, get: true });
                }
                var inactive = filter ? filter === value['Descripcion'] && dato === 'I' : false;
                switch (value['Descripcion']) {
                    case 'CEDI':
                        if (self.filtersRequiredList.length !== 0) {
                            temp = currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? [currentRequiredFilter['selected']] : null : currentRequiredFilter['selected'] : currentRequiredFilter['selected'];
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0) {
                            self.filtersRequiredList.splice(1, filterCopy.length - 1);
                            filterCopy.splice(0, filterCopy.length, currentFilter);
                            Object.assign(filterCopy[currentIndex], { get: self.filtersRequiredList.length === 0 });
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            selected = selected.concat('cedis=');
                            angular.forEach(parameterConstruction, function (parameter) {
                                selectedList.push(parameter['Clave'].replace(/\+/g, "%2B"));
                            });
                            selected = selected.concat(selectedList);
                            filterCopy.splice(0, 1);
                        }
                        break;
                    case 'RUTA':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? value['Opciones'].includes('E') ? self.switch !== undefined ? !self.switch ? [currentRequiredFilter['selected']] : null : [currentRequiredFilter['selected']] : [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? self.switch !== undefined ? !self.switch ? currentRequiredFilter['selected'] : null : currentRequiredFilter['selected'] : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            value['Opciones'].includes('E') ? !self.switch ? cleanerClient = true : undefined : cleanerClient = true;
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter) });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            cleanerClient = false;
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                                cleanerClient = 'E';
                            }
                            selected = selected.concat(selected !== '?' ? '&' : '');
                            selected = selected.concat('routes=');
                            angular.forEach(parameterConstruction, function (parameter) {
                                selectedList.push(parameter['Clave'].replace(/\+/g, "%2B"));
                            });
                            selected = selected.concat(selectedList);
                            filterCopy.splice(currentIndex, 1);
                        }
                        if (value['Opciones'].includes('E') && self.switch) {
                            self.nameSwitch = value['Descripcion'];
                            if (currentIndex > -1) {
                                filterCopy.splice(currentIndex, 1);
                            }
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList.splice(currentRequiredIndex, 1);
                            }
                        }
                        break;
                    case 'VENDEDOR':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? value['Opciones'].includes('E') ? self.switch ? [currentRequiredFilter['selected']] : null : [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? self.switch ? currentRequiredFilter['selected'] : null : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            value['Opciones'].includes('E') ? self.switch ? cleanerClient = true : undefined : cleanerClient = true;
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter) });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            cleanerClient = false;
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                                cleanerClient = 'E';
                            }
                            selected = selected.concat(selected !== '?' ? '&' : '');
                            selected = selected.concat('sellers=');
                            angular.forEach(parameterConstruction, function (parameter) {
                                selectedList.push(parameter['Clave'].replace(/\+/g, "%2B"));
                            });
                            selected = selected.concat(selectedList);
                            filterCopy.splice(currentIndex, 1);
                        }
                        if (value['Opciones'].includes('E') && !self.switch) {
                            self.nameSwitch = value['Descripcion'];
                            if (currentIndex > -1) {
                                filterCopy.splice(currentIndex, 1);
                            }
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList.splice(currentRequiredIndex, 1);
                            }
                        }
                        break;
                    case 'ESQCLI':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? self.switch ? currentRequiredFilter['selected'] : null : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            cleanerClient = cleanerClient ? cleanerClient : (selected.includes('routes') || selected.includes('sellers')) && !cleanerClient ? filter === value['Descripcion'] ? 'E' : false : true;
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter) });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            cleanerClient = cleanerClient !== false ? selected.includes('routes') || selected.includes('sellers') ? 'E' : cleanerClient ? 'E' : false : false;
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                                cleanerClient = 'E';
                            }
                            selected = selected.concat(selected !== '?' ? '&' : '');
                            selected = selected.concat('clientScheme=');
                            angular.forEach(parameterConstruction, function (parameter) {
                                selectedList.push(parameter['Clave'].replace(/\+/g, "%2B"));
                            });
                            selected = selected.concat(selectedList);
                            filterCopy.splice(currentIndex, 1);
                        }
                        break;
                    case 'CLIENTE':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = cleanerClient ? undefined : currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            //temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? cleanerClient ? null : [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? cleanerClient ? null : currentRequiredFilter['selected'] : null : null;
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? cleanerClient ? null : [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? cleanerClient ? currentRequiredFilter['selected'] : currentRequiredFilter['selected'] : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter || cleanerClient.toString() === 'E') });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                                cleanerClient = false;
                            }
                            if (!cleanerClient) {
                                filterCopy.splice(currentIndex, 1);
                            }
                        }
                        if (cleanerClient) {
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList.splice(currentRequiredIndex, 1);
                            }
                            if (currentIndex > -1 && cleanerClient.toString() !== 'E') {
                                filterCopy.splice(currentIndex, 1);
                            }
                        }
                        cleanerClient = false;
                        break;
                    case 'ESQPROD':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? currentRequiredFilter['selected'] : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            cleanerProd = true;
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter) });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            cleanerProd = false;
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                                cleanerProd = 'E';
                            }
                            selected = selected.concat(selected !== '?' ? '&' : '');
                            selected = selected.concat('productSchemes=');
                            angular.forEach(parameterConstruction, function (parameter) {
                                selectedList.push(parameter['Clave'].replace(/\+/g, "%2B"));
                            });
                            selected = selected.concat(selectedList);
                            filterCopy.splice(currentIndex, 1);
                        }
                        break;
                    case 'PRODUCTO':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = cleanerProd ? undefined : currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? cleanerProd ? null : [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? cleanerProd ? null : currentRequiredFilter['selected'] : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter || cleanerProd.toString() === 'E') });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                            }
                            filterCopy.splice(currentIndex, 1);
                        }
                        if (cleanerProd) {
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList.splice(currentRequiredIndex, 1);
                            }
                            if (currentIndex > -1 && cleanerProd.toString() !== 'E') {
                                filterCopy.splice(currentIndex, 1);
                            }
                        }
                        cleanerProd = false;
                        break;
                    case 'FECHA':
                        if (currentFilter && !currentRequiredFilter) {
                            Object.assign(filterCopy[currentIndex], { todayDate: new Date(), startDate: new Date() });
                            if ((Array.from(value['Opciones']))[1] === 'E') {
                                Object.assign(filterCopy[currentIndex], { endDate: new Date() });
                            }
                        } else if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentRequiredIndex > -1 && currentIndex > -1) {
                                currentRequiredFilter['selected'] ? filterCopy.splice(currentIndex, 1) : undefined;
                            }
                        }
                        break;
                    case 'LISTPRE':
                        if (self.filtersRequiredList.length !== 0) {
                            if (currentRequiredFilter && currentIndex > -1) {
                                filterCopy[currentIndex]['showInactive'] = currentRequiredFilter['showInactive'];
                                selected = selected.concat(filterCopy[currentIndex]['showInactive'] && inactive ? (selected !== '?' ? '&' : '') + 'state=0, 1' : '');
                            }
                            temp = currentRequiredFilter ? currentRequiredFilter['searchText'] ? currentRequiredFilter['selected'] !== null ? currentRequiredFilter['searchText'] === currentRequiredFilter['selected']['Nombre'] ? [currentRequiredFilter['selected']] : null : null : Array.isArray(currentRequiredFilter['selected']) ? currentRequiredFilter['selected'] : null : null;
                            temp === null ? parameterConstruction = [] : Object.assign(parameterConstruction, temp);
                        }
                        if (currentFilter && parameterConstruction.length === 0 || inactive) {
                            filterCopy.splice(currentIndex, 1, currentFilter);
                            if (currentRequiredIndex > -1) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = undefined;
                            }
                            Object.assign(filterCopy[currentIndex], { get: (self.filtersRequiredList.length === 0 || inactive || !currentRequiredFilter) });
                            if (inactive) {
                                if (currentRequiredIndex > -1) {
                                    self.filtersRequiredList.splice(currentRequiredIndex, 1);
                                }
                            }
                        } else if (currentFilter && parameterConstruction.length !== 0) {
                            var last = parameterConstruction.length;
                            if (!currentRequiredFilter['lastSelected'] || (last !== currentRequiredFilter['lastSelected'])) {
                                self.filtersRequiredList[currentRequiredIndex]['lastSelected'] = last;
                            }
                            filterCopy.splice(currentIndex, 1);
                        }
                        break;
                }
            });

            selected = selected.replace('&&', '&');
            angular.forEach(filterCopy, function (value) {
                if (value['get']) {
                    var index;
                    let fn = new Function('reportServices', 'selected', 'return reportServices.Get' + value['Descripcion'] + '(selected);');
                    let elfiltrador;
                    fn(reportServices, selected).then(function (response) {
                        elfiltrador = [];
                        Object.assign(elfiltrador, value);
                        Object.assign(elfiltrador, { data: response, Opciones: Array.from(value['Opciones']), selected: undefined, lastSelected: undefined });
                        if ((Array.from(value['Opciones']))[1] === 'M') {
                            Object.assign(elfiltrador, { selected: [] });
                        }
                        Object.assign(elfiltrador, { showInactive: value['showInactive'] });
                        if (value['TipoFiltro'] === 4) {
                            Object.assign(elfiltrador, { state: (elfiltrador['Opciones'][1] === 'E' && elfiltrador['Opciones'][3] === 'E' ? response[1]['Nombre'] : response[0]['Nombre']) });
                            if (elfiltrador['Opciones'][1] === 'I') {
                                var start;
                                start = elfiltrador['startDate'];
                                start = start ? moment(start).format('YYYY-MM-DD') : undefined;
                                Object.assign(elfiltrador, { selected: start });
                            } else if (elfiltrador['Opciones'][1] === 'E') {
                                if (elfiltrador['state'] === 'Igual') {
                                    Object.assign(elfiltrador, { endDate: elfiltrador['startDate'] });
                                };
                                var start, end;
                                start = elfiltrador['startDate'];
                                end = elfiltrador['endDate'];
                                start = start ? moment(start).format('YYYY-MM-DD') : undefined;
                                end = end ? moment(end).format('YYYY-MM-DD') : undefined;
                                Object.assign(elfiltrador, { selected: start.concat('&', end) });
                            };
                        };
                        index = self.filtersRequiredList.findIndex(filter => filter['TipoFiltro'] === value['TipoFiltro']);
                        index > -1 ? self.filtersRequiredList.splice(index, 1, elfiltrador) : self.filtersRequiredList.push(elfiltrador);
                    });
                }
            });
        }

        self.OnSelectChange = function (filter) {
            if (filter['Opciones'][1] === 'I') {
                var start;
                start = filter['startDate'];
                start = start ? moment(start).format('YYYY-MM-DD') : undefined;
                Object.assign(filter, { selected: start });
            } else if (filter['Opciones'][1] === 'E') {
                if (filter['state'] === 'Igual') {
                    Object.assign(filter, { endDate: filter['startDate'] });
                };
                var start, end;
                start = filter['startDate'];
                end = filter['endDate'];
                start = start ? moment(start).format('YYYY-MM-DD') : undefined;
                end = end ? moment(end).format('YYYY-MM-DD') : undefined;
                Object.assign(filter, { selected: start.concat('&', end) });
            };
        }

        self.OnChange = function (cbState) {
            if (!cbState) {
                Object.assign(cbState, '');
            } else {
                Object.assign(cbState, cbState);
            }
        };

        $scope.toggle = function (item, list, filter) {
            var idx = list.indexOf(item);
            if (idx > -1) {
                list.splice(idx, 1);
            }
            else {
                list.push(item);
            }
            self.GetConditionedFilter(filter);
        };

        $scope.exists = function (item, list) {
            return list.indexOf(item) > -1;
        };

        $scope.isIndeterminate = function (items, selected) {
            return !items ? false : (selected.length !== 0 &&
                selected.length !== items.length);
        };

        $scope.isChecked = function (items, selected) {
            return !items ? false : selected.length === items.length;
        };

        $scope.toggleAll = function (item, list, filter) {
            if (list.length === item.length) {
                list.splice(0, list.length);
            } else if (list.length === 0 || list.length > 0) {
                Object.assign(list, item);
            }
            self.GetConditionedFilter(filter);
        };

        function GetArrayValues(filters) {
            var newArray = [];
            var stringArray = [];
            var filterString = '';
            angular.forEach(filters, function (item) {
                newArray.push({ TipoFiltro: item.TipoFiltro, Descripcion: item.Descripcion, Selected: Array.isArray(item.selected) ? item.selected : typeof item.selected === 'object' ? [item.selected] : (item.selected !== null && item.selected !== undefined) ? item.selected : "" });
            });

            angular.forEach(self.filtersList, function (item) {
                var currentFilter = newArray.find(filter => filter['TipoFiltro'] === item['TipoFiltro']);
                if (currentFilter === undefined) {
                    stringArray.push('');
                } else if (Array.isArray(currentFilter['Selected'])) {
                    angular.forEach(currentFilter['Selected'], function (value) {
                        stringArray.push(value === null ? '' : value['Clave']);
                    });
                } else if (typeof currentFilter['Selected'] !== 'string') {
                    stringArray.push(currentFilter['Selected'].toString());
                } else {
                    stringArray.push(currentFilter['Selected']);
                }
                filterString = filterString.concat(item['TipoFiltro'] === self.filtersList[self.filtersList.length - 1]['TipoFiltro'] ? (Array.isArray(stringArray) ? stringArray.toString() : stringArray) : (Array.isArray(stringArray) ? stringArray.toString() : stringArray) + '&');
                stringArray = [];
            });
            return filterString;
        };

        $scope.submit = function () {
            var url = window.sessionStorage.getItem('URL');
            var dataList = GetArrayValues(self.filtersRequiredList);
            var data = {
                dataListObject: dataList,
                ReportName: self.titulo,
                VAVClave: self.VAVClave
            }
            $http.post(url + '/Reports/SetDynamicConditions', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + "/Reports/GetDynamicReport");
                    cfpLoadingBar.complete();
                });
        };
    }]);