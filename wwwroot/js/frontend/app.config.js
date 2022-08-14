'use strict';
angular.module('AngularJS_Proj').config(['$stateProvider', '$urlRouterProvider', '$locationProvider',
    function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/');
        $locationProvider.hashPrefix('#!').html5Mode(true);
        //$locationProvider.html5Mode(true);
        $stateProvider
            .state('main', {
                url: '/',
                templateUrl: '/views/main.html',
                controller: 'MainCtrl'
            })
            .state('reviews', {
                url: '/reviews',
                templateUrl: '/views/reviews.html'
            })
    }])
    .constant('API_URL', 'http://kwacupuncture.com/');
    //.constant('API_URL', 'http://localhost:56806/');
