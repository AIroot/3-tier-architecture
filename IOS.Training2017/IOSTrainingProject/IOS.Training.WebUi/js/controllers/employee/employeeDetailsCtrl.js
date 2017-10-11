(function () {
    var employeeDetailsCtrl = function ($scope, $routeParams) {
        alert($routeParams.employeeId);
    };
    employeeDetailsCtrl.$inject = ['$scope', '$routeParams'];
    angular.module('trainingApp').controller('employeeDetailsCtrl', employeeDetailsCtrl);
}());