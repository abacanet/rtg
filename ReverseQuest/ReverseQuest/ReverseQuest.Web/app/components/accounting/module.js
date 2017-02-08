(function () {
    'use strict';

    angular.module('reverseQuestApp.accounting', [
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
        var views = 'app/components/accounting/views/';

        $stateProvider
            .state('accounting', {
                abstract: true,
                url: '/accounting',
                templateUrl: views + 'index.html'
            })
            .state('accounting.search', {
                url: '/search',
                templateUrl: views + 'accounting-search.default.html'
            })
            .state('accounting.check', {
                url: '/check',
                templateUrl: views + 'accounting-search.check.html'
            })
            .state('accounting.batch', {
                url: '/batch',
                templateUrl: views + 'accounting-search.batch.html'
            })
            .state('accounting.money', {
                url: '/money',
                templateUrl: views + 'accounting-search.money.html'
            });

    }


})();