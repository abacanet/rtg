(function () {
    'use strict';

    angular.module('reverseQuestApp.default', [
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
        var views = 'app/components/default/views/';

        $stateProvider
            .state('default', {
                abstract: true,
                url: '/default',
                templateUrl: views + 'index.html'
            })
            .state('default.search', {
                url: '/search',
                templateUrl: views + 'default-search.default.html'
            })
            .state('default.setup', {
                url: '/setup',
                templateUrl: views + 'default-search.setup.html'
            });

    }


})();