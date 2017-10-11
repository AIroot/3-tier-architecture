(function () {
    var navigationCtrl = function ($rootScope, $scope, $location,util) {

        //$scope.userLoggedIn = "";
        //if (util.getIsloggedIn() == false) {
        //    $scope.userLoggedIn = "";
        //    $location.path("login");
        //} else {
        //    $scope.userLoggedIn = "";
        //}

        $scope.modules = JSON.parse(localStorage.getItem("modules"));
        console.log($scope.modules);

        $scope.menuList = [
            {
                title: "Home",
                isSelected: true,
                url : "home"
            },
            {
                title: "Home",
                isSelected: true,
                subMenu : [
                {
                    title: "Home",
                    isSelected: true,
                    url: "home"
                }, {
                    title: "Home",
                    isSelected: true,
                    url: "home"
                }, {
                    title: "Home",
                    isSelected: true,
                    url: "home"
                }]
            }
        ];

        $scope.menuStatus = "";
        $scope.isShowMenuStatus = false;

        $scope.openMenuStatusViewClick = function () {
            if ($scope.isShowMenuStatus == false) {
                $scope.menuStatus = "open";
                $scope.isShowMenuStatus = true;
            } else {
                $scope.menuStatus = "";
                $scope.isShowMenuStatus = false;
            }
        };

        $scope.menuCouponStatus = "";
        $scope.isShowMenuCouponStatus = false;

        $scope.openMenuCouponStatusViewClick = function () {
            if ($scope.isShowMenuCouponStatus == false) {
                $scope.menuCouponStatus = "open";
                $scope.isShowMenuCouponStatus = true;
            } else {
                $scope.menuCouponStatus = "";
                $scope.isShowMenuCouponStatus = false;
            }
        };


        $scope.menuReportsStatus = "";
        $scope.isShowMenuReportStatus = false;

        $scope.openMenuReportStatusViewClick = function () {
            if ($scope.isShowMenuReportStatus == false) {
                $scope.menuReportsStatus = "open";
                $scope.isShowMenuReportStatus = true;
            } else {
                $scope.menuReportsStatus = "";
                $scope.isShowMenuReportStatus = false;
            }
        };

        $scope.openSubMenu = function (module) {
            module.showSubMenu = !module.showSubMenu;
        }



    };

    navigationCtrl.$inject = ['$rootScope', '$scope', '$location', 'util'];
    angular.module('d2cApp').controller('navigationCtrl', navigationCtrl);
}());