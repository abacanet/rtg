(function () {
    'use strict';

    angular.module('reverseQuestApp.import-export', [
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

        $stateProvider
            .state('import-export', {
                url: '/import-export',
                templateUrl: 'app/components/import-export/views/import-export.html',
                controller: 'ImportExportCtrl as vm'
            });

    }


})();