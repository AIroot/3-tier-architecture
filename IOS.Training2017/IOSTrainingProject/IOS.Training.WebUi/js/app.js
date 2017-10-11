(function () {
    var app = angular.module('trainingApp', ['ngRoute']);

    // config route
    app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider)
    {
        var baseUrl = "partials/";

        $routeProvider
            .when('/', {
                templateUrl: baseUrl + 'employee/employees.html',
                controller: 'employeesCtrl'
            })
            .when('/employees', {
                templateUrl: baseUrl + 'employee/employees.html',
                controller: 'employeesCtrl'
            })
            .when('/employeedetails/:employeeId', {
                templateUrl: baseUrl + 'employee/employeeDetails.html',
                controller: 'employeeDetailsCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
    }]);
}());


