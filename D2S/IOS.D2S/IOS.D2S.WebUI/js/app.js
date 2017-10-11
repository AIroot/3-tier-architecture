
(function () {

    var app = angular.module('d2cApp', ['ngRoute', 'ui.bootstrap'] );

    app.filter('groupBy', function () {
        return _.memoize(function (items, field) {
            return _.groupBy(items, field);
        }
        );
    });

    // config route
    app.config(['$routeProvider',
        function ($routeProvider) {
            var baseUrl = "partials/";

            $routeProvider.when('/', {
                    templateUrl: baseUrl + 'home.html',
                    controller: 'homeCtrl'
                })
                .when('/home', {
                    templateUrl: baseUrl + 'home.html',
                    controller: 'homeCtrl'
                })

                 .when('/coupons', {
                     templateUrl: baseUrl + 'managecoupons.html',
                     controller: 'managecouponsCtrl'
                 })

                .when('/students', {
                    templateUrl: baseUrl + 'managestdents.html',
                    controller: 'managestdentsCtrl'
                })

                .when('/uploadcsv', {
                    templateUrl: baseUrl + 'uploadcsv.html',
                    controller: 'uploadcsvCtrl'
                })
                
                .when('/reports', {
                    templateUrl: baseUrl + 'managereports.html',
                    controller: 'managereportsCtrl'
                })

                .when('/login', {
                    templateUrl: baseUrl + 'login.html',
                    controller: 'loginCtrl'
                })

                .when('/admin', {
                    templateUrl: baseUrl + 'admin/admin.html',
                    controller: 'adminCtrl'
                })
                 .when('/assignPermissions', {
                     templateUrl: baseUrl + 'assignPermissions.html',
                     controller: 'permissionCtrl'
                 })
                 .when('/editPermissions', {
                     templateUrl: baseUrl + 'editPermissions.html',
                     controller: 'permissionCtrl'
                 })
                .when('/dashboard', {
                    templateUrl: baseUrl + 'kiosk/dashboard.html',
                    controller: 'kiosk/dashboardCtrl'
                })
                .when('/commandProfile', {
                    templateUrl: baseUrl + 'kiosk/commandProfile.html',
                    controller: 'kiosk/commandProfileCtrl'
                })
                .when('/machineSettings', {
                    templateUrl: baseUrl + 'kiosk/machineSettings.html',
                    controller: 'kiosk/machineSettingsCtrl'
                })
                .otherwise({
                    redirectTo: '/'
                });
        }
    ]);


}());

