(function () {
    'use strict';

    window.APP_CONFIG = {
        AUTHENTICATION_SERVICE_BASE_URL: "http://localhost:33001/api/",
    };


    angular.module('d2cApp')
        .constant("configs", window.APP_CONFIG);  

})();