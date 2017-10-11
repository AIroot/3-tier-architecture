(function () {
    var dashboardCtrl = function ($rootScope, $scope, $location, util, authorizationSvc) {

        util.setIsloggedIn(true);

        $scope.credentioals = {
            UserName: '',
            Password: ''
        }

      

    };

    dashboardCtrl.$inject = ['$rootScope', '$scope', '$location', 'util', 'authorizationSvc'];
    angular.module('d2cApp').controller('dashboardCtrl', dashboardCtrl);


}());