'use strict';

angular.module('AngularJS_Proj')
    .service('alert', function ($rootScope, $timeout) {
        var alertTimeout;
        return function (type, title, message, timeout) {
            $rootScope.alert = {
                hasBeenShown: true,
                show: true,
                message: message,
                type: type,
                title: title
            };
            $timeout.cancel(alertTimeout);
            alertTimeout = $timeout(function () {
                $rootScope.alert.show = false;
            }, 4000);

        };
    });
