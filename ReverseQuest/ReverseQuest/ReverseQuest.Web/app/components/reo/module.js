(function () {
    'use strict';

    angular.module('reverseQuestApp.reo', [
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
        var views = 'app/components/reo/views/';

        $stateProvider
            .state('reo', {
                abstract: true,
                url: '/reo',
                templateUrl: views + 'index.html'
                //controller: 'ReoCtrl as vm'
            })
            .state('reo.search', {
                url: '/search',
                templateUrl: views + 'reo-search.default.html'
            })
            .state('reo.setup', {
                url: '/setup',
                templateUrl: views + 'reo-search.setup.html'
            });

    }


})();