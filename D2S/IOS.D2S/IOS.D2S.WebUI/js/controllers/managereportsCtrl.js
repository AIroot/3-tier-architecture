(function () {
    var managereportsCtrl = function ($rootScope, $scope, $location, util) {

        //if (util.getIsloggedIn() == false) {
        //    $location.path("login");
        //}

        $('#startDate').datepicker();
        $('#endDate').datepicker();

    };

    managereportsCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('managereportsCtrl', managereportsCtrl);
}());