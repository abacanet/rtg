(function () {
    'use strict';

    angular.module('reverseQuestApp.bankruptcy', [
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
        var views = 'app/components/bankruptcy/views/';

        $stateProvider
            .state('bankruptcy', {
                abstract: true,
                url: '/bankruptcy',
                templateUrl: views + 'index.html'
            })
            .state('bankruptcy.search', {
                url: '/search',
                templateUrl: views + 'bankruptcy-search.default.html',
            })
            .state('bankruptcy.check', {
                url: '/check',
                templateUrl: views + 'bankruptcy-search.check.html',
            });

    }


})();