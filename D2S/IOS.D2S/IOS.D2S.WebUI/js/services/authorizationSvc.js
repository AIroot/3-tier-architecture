(function () {
    angular.module('d2cApp').factory('authorizationSvc', function ($http, configs) {

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

        var getOperationsByBranch = function (branchID, callbackFn) {

            var dataUrl = configs.AUTHENTICATION_SERVICE_BASE_URL + 'Auth/GetOperations?&branchId=' + branchID;
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

        var assignPermissions = function (modulesObj, callbackFn) {

            var dataUrl = configs.AUTHENTICATION_SERVICE_BASE_URL + 'Auth/AssignPermissions';
            $http({
                method: "POST",
                url: dataUrl,
                data: $.param(modulesObj),
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
            getRolesByBranch: getRolesByBranch,
            getOperationsByBranch: getOperationsByBranch,
            assignPermissions: assignPermissions
        };
    });
}());