(function () {
    var uploadcsvCtrl = function ($rootScope, $scope, $location, util) {

        //if (util.getIsloggedIn() == false) {
        //    $location.path("login");
        //}

    };

    uploadcsvCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('uploadcsvCtrl', uploadcsvCtrl);
}());