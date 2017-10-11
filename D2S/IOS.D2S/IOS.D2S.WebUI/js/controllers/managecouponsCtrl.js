(function () {
    var managecouponsCtrl = function ($rootScope, $scope, $location, util) {

        //if (util.getIsloggedIn() == false) {
        //    $location.path("login");
        //}

    };

    managecouponsCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('managecouponsCtrl', managecouponsCtrl);
}());