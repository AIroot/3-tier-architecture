(function () {
    angular.module('d2cApp').factory('machineSettingsSvc', function ($http, configs) {

        /**
        *   Check whether admin created customer or not
        */
        var login = function (credentialObj, callbackFn) {

            var dataUrl = configs.AUTHENTICATION_SERVICE_BASE_URL + 'Auth/GetUserByCredentials';
            $http({
                method: "POST",
                url: dataUrl,
                data: $.param(credentialObj),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                callbackFn(data);
            }).error(function (data, status, headers, config) {
                console.log(data);
                console.log(status);
            });
        }

        var getPermissionByRole = function (roleID, branchID, callbackFn) {

            var dataUrl = configs.AUTHENTICATION_SERVICE_BASE_URL + 'Auth/GetModulesByRole?roleId=' + roleID + '&branchId=' + branchID;
            $http({
                method: "GET",
                url: dataUrl,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                callbackFn(data);
            }).error(function (data, status, headers, config) {
                console.log(data);
                console.log(status);
            });
        }

        var getRolesByBranch = function (branchID, callbackFn) {

            var dataUrl = configs.AUTHENTICATION_SERVICE_BASE_URL + 'Auth/GetUserRoles?&branchId=' + branchID;
            $http({
                method: "GET",
                url: dataUrl,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).success(function (data) {
                callbackFn(data);
            }).error(function (data, status, headers, config) {
                console.log(data);
                console.log(status);
            });
        }



        return {
            login: login,
            getPermissionByRole: getPermissionByRole,
            getRolesByBranch: getRolesByBranch
        };
    });
}());