(function () {
    'use strict';

    angular.module('reverseQuestApp.loan', [
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
        'ui.bootstrap',
        'disableAll'
    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider']

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state('loan', {
                abstract: true,
                url: '/loan',
                templateUrl: 'app/components/loan/views/index.html'
            })
            .state('loan.search', {
                url: '/search',
                templateUrl: 'app/components/loan/views/loan-search.default.html',
                controller: 'LoanSearchDefaultCtrl as vm'
            })
            .state('loan.note', {
                url: '/note',
                templateUrl: 'app/components/loan/views/loan-search.note.html',
                controller: 'LoanSearchNoteCtrl as vm'
            })
            .state('loan.qc', {
                url: '/qc',
                templateUrl: 'app/components/loan/views/loan-search.qc.html',
                controller: 'LoanSearchQCCtrl as vm'
            })
            .state('loan-detail', {
                url: '/loan/detail/{LoanSkey}',
                templateUrl: 'app/components/loan/views/loan.detail.html',
                controller: 'LoanDetailCtrl as vm'
            })
            .state('loanProperty', {
                url: '/property/{LoanSkey}',
                templateUrl: 'app/components/loan/views/property.html',
                controller: 'LoanPropertyCtrl as vm'
            })
            .state('loan-contacts', {
                url: '/contacts/{LoanSkey}',
                templateUrl: 'app/components/loan/views/loan.contacts.html',
                controller: 'LoanContactsCtrl as vm'
            })
            .state('loan-balance', {
                url: '/transactions/{LoanSkey}',
                templateUrl: 'app/components/loan/views/loan-balance.html',
                controller: 'LoanBalanceCtrl as vm'
            });

    }


})();