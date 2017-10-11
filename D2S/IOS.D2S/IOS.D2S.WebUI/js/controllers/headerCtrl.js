(function () {
    var headerCtrl = function ($rootScope, $scope, $location, util) {

        //$scope.userLoggedIn = "";
        //if (util.getIsloggedIn() == false) {
        //    $scope.userLoggedIn = "";
        //    $location.path("login");
        //} else {
        //    $scope.userLoggedIn = "";
        //}

        $scope.userStatus = "";
        $scope.isShowUserStatus = false;

        $scope.openUserStatusViewClick = function () {
            if ($scope.isShowUserStatus == false) {
                $scope.userStatus = "active";
                $scope.isShowUserStatus = true;
            } else {
                $scope.userStatus = "";
                $scope.isShowUserStatus = false;
            }
        };

        $scope.btnClass = "";
        $scope.bodyClass = "";
        $scope.isMobileViewOpen = false;
        $scope.openNavigation = function () {
            if ($scope.isMobileViewOpen == false) {
                $scope.btnClass = "nav-out";
                $scope.bodyClass = "nav-open";
                $scope.isMobileViewOpen = true;
            } else {
                $scope.btnClass = "";
                $scope.bodyClass = "";
                $scope.isMobileViewOpen = false;
            }
        };

    };

    headerCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('headerCtrl', headerCtrl);
}());