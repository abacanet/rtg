(function(){
    'use strict';
    var RQ_APIURL = '';
    angular.module('reverseQuestApp').config(config).run(run);
    
    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];
    function config($stateProvider, $urlRouterProvider, $locationProvider) {
        $urlRouterProvider.otherwise('/');
    }

    run.$inject = ['$document', '$log', '$rootScope', '$location', '$state', '$stateParams', 'session'];
    function run($document, $log, $rootScope, $location, $state, $stateParams, session) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;

        $rootScope.$on('$stateNotFound', function (event, unfoundState, fromState, formParams) {
            $log.error('The requested state was not found: ', unfoundState);
        });

        $rootScope.$on('$stateNotFound', function (event, unfoundState, fromState, formParams, error) {
            $log.error('An error occurred while changing states: ', error);
            $log.debug('event', event);
            $log.debug('toState', event);
            $log.debug('toParams', event);
            $log.debug('fromState', event);
            $log.debug('fromParams', event);
        });
    }

}());