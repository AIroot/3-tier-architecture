(function () {
    var managestdentsCtrl = function ($rootScope, $scope, $location, util) {

        //if (util.getIsloggedIn() == false) {
        //    $location.path("login");
        //}

    };

    managestdentsCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('managestdentsCtrl', managestdentsCtrl);
}());