(function () {
    'use strict';

    angular.module('reverseQuestApp.reports', [
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
        var views = 'app/components/reports/views/';

        $stateProvider
            .state('reports', {
                abstract: true,
                url: '/reports',
                templateUrl: views + 'index.html'
            })
            .state('reports.search', {
                url: '/search',
                templateUrl: views + 'reports-search.default.html'
            });

    }


})();