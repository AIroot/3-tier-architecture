(function () {
    'use strict';

    angular.module('trainingApp').factory('apiCallsSvc', function ($http, configs) {

        var getAllEmployees = function (callbackFn) {
            var dataUrl = configs.SERVICE_BASE_URL + 'api/Employee/GetAllEmployees';

            $http.get(dataUrl).then(function (result) {
                callbackFn(result.data);
            }, function (result) {
                console.log(result.data);
                console.log(result.status);
            });
        };

        var advancedInvoiceSummarySearch = function (obj, callbackFn) {
            var dataUrl = configs.SERVICE_BASE_URL + 'api/';

            $http({
                method: "POST",
                url: dataUrl,
                data: $.param(obj),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (result) {
                callbackFn(result.data);
            }, function (result) {
                console.log(result.data);
                console.log(result.status);
            });
        };

        return {
            getAllEmployees: getAllEmployees
        };
    });
}());