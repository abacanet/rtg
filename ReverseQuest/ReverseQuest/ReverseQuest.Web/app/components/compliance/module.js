(function () {
    'use strict';

    angular.module('reverseQuestApp.compliance', [
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
        var views = 'app/components/compliance/views/';

        $stateProvider
            .state('compliance', {
                abstract: true,
                url: '/compliance',
                templateUrl: views + 'index.html'
            })
            .state('compliance.search', {
                url: '/search',
                templateUrl:  views + 'compliance-search.default.html'
            })
            .state('compliance.setup', {
                url: '/setup',
                templateUrl:  views + 'compliance-search.setup.html'
            });

    }


})();