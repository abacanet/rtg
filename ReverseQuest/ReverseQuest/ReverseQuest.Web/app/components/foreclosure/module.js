(function () {
    'use strict';

    angular.module('reverseQuestApp.foreclosure', [
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
        var views = 'app/components/foreclosure/views/';

        $stateProvider
            .state('foreclosure', {
                abstract: true,
                url: '/foreclosure',
                templateUrl: views + 'index.html'
            })
            .state('foreclosure.search', {
                url: '/search',
                 templateUrl: views + 'foreclosure-search.default.html'
            })
            .state('foreclosure.setup', {
                url: '/setup',
                 templateUrl: views + 'foreclosure-search.setup.html'
            });

    }


})();