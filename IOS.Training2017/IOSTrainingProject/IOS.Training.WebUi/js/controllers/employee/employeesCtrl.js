(function () {
    var employeesCtrl = function ($scope, $location, apiCallsSvc) {

        $scope.employeeList = [];

        /** get all employee details */
        function getAllEmployees() {
            apiCallsSvc.getAllEmployees(function (data) {
                $scope.employeeList = data;
            });
        };
        getAllEmployees();

        /** employee detail clicked event */
        $scope.employeeDetlClickedEvent = function (employee) {
            $location.path('/employeedetails/' + employee.Id);
        };
    };

    employeesCtrl.$inject = ['$scope', '$location', 'apiCallsSvc'];
    angular.module('trainingApp').controller('employeesCtrl', employeesCtrl);
}());