(function () {
    var homeCtrl = function ($rootScope, $scope, $location,util) {

        //if (util.getIsloggedIn() == false) {
        //    $location.path("login");
        //} 

    };

    homeCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('homeCtrl', homeCtrl);
}());