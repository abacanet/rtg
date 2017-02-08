(function () {
    'use strict';

    angular.module('reverseQuestApp.claims', [
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
        var views = 'app/components/claims/views/';

        $stateProvider
            .state('claims', {
                abstract: true,
                url: '/claims',
                templateUrl: views + 'index.html'
            })
            .state('claims.search', {
                url: '/search',
                templateUrl: views + 'claims-search.default.html'
            })
            .state('claims.setup', {
                url: '/setup',
                templateUrl: views + 'claims-search.setup.html'
            });

    }


})();