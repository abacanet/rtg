(function () {
    'use strict';

    angular.module('reverseQuestApp.servicing', [
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
        var views = 'app/components/servicing/views/';

        $stateProvider
            .state('servicing', {
                abstract: true,
                url: '/servicing',
                templateUrl: views + 'index.html'
            })
            .state('servicing.search', {
                url: '/search',
                templateUrl: views + 'servicing-search.default.html'
            });

    }


})();