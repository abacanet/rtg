(function () {
    'use strict';

    angular.module('reverseQuestApp.hmbs', [
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
        var views = 'app/components/hmbs/views/';
        $stateProvider
            .state('hmbs', {
                abstract: true,
                url: '/hmbs',
                templateUrl: views + 'index.html'
            })
            .state('hmbs.search', {
                url: '/search',
                templateUrl: views + 'hmbs-search.default.html'
            })
            .state('hmbs.psearch', {
                url: '/psearch',
                templateUrl: views + 'hmbs-psearch.default.html'
            })
            .state('hmbs.psetup', {
                url: '/psetup',
                templateUrl: views + 'hmbs-psearch.setup.html'
            });

    }


})();