(function () {
    var loginCtrl = function ($rootScope, $scope, $location, util, authorizationSvc) {

        util.setIsloggedIn(true);

        $scope.credentials = {
            UserName: '',
            Password:''
        }

        $scope.loginClick = function() {
            util.setIsloggedIn(true);
            console.log('--------------');
            console.log($scope.credentials);
            authorizationSvc.login($scope.credentials, function (data) {

                //alert(data);
                console.log(data);
                // localStorageService.set('modules', data.Modules);
                localStorage.setItem("modules", JSON.stringify(data.Modules));
                localStorage.setItem("user", JSON.stringify(data));

                if (data != null) {
                    $('#preloader').hide();
                    $location.path("home");
                }
            });
            
        };

    };

    loginCtrl.$inject = ['$rootScope', '$scope', '$location', 'util', 'authorizationSvc'];
    angular.module('d2cApp').controller('loginCtrl', loginCtrl);


}());