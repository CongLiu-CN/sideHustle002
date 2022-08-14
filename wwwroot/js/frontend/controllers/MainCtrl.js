'use strict';

angular.module('AngularJS_Proj')
    .controller('MainCtrl', function ($scope, $rootScope, $state, $http, $httpParamSerializer, alert, API_URL) {

        //$scope.key = '6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI';
        $scope.key = '6Ldt0F8UAAAAADVA1xFdeiokONgVCfj1V-I3vxM-';
        window.captchaSigned = false;

        window.enableBtn = function () {
            window.captchaSigned = true;
            $scope.$apply(function () {
                $scope.captchaSigned = window.captchaSigned;
            });
        };

        $scope.submit = function () {
            var user = {
                name: $scope.user.name,
                email: $scope.user.email,
                message: $scope.user.message,
                session: $scope.user.session,
                captchaKey: $scope.captchaKey
            };

            console.log("we are here");

            $http({
                url: API_URL + 'contact',
                method: "POST",
                data: user
            })
                .then(function (res) {
                    console.log(res);
                alert('success', 'Thank you', 'The message has been successfully sent!');
                $scope.user = null;
                $scope.contactForm.$setPristine();
            })
            .catch(function (fallback) {
                    console.log(fallback);
               alert('warning', 'Opps!', 'Something went wrong');
            });
        };
    });
