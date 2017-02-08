(function () {
    'use strict';

    angular.module('reverseQuestApp.dashboard', [
        'reverseQuestApp.shared',
        'kendo.directives',
        'angularCSS',
        'ngNotificationsBar',
        'ngSanitize',
        'ngMessages',
        'ngNotificationsBar',
        'timer',
        'ui.utils.masks',
        'ui.router',
        'ui.bootstrap'
    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state('dashboard', {
                url: '/',
                templateUrl: 'app/components/dashboard/views/index.html'
                //controller: 'DashboardCtrl as vm'
            });

    }


})();