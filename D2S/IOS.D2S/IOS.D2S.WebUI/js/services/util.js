(function () {
    var util = function () {

        var isloggedIn = false;
        this.getIsloggedIn = function () {
            return isloggedIn;
        };

        this.setIsloggedIn = function (item) {
            isloggedIn = item;
        };

        var menuloggedIn = "remove";
        this.getMenuloggedIn = function () {
            return menuloggedIn;
        };

        this.setMenuloggedIn = function (item) {
            menuloggedIn = item;
        };
    };

    //angular.$inject = ['$location'];
    angular.module('d2cApp').service('util', util);

}());