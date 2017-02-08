/*
(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanDirective', loanDirective);

    loanDirective.$inject = ['dal', 'notifications', '$mdExpansionPanel', '$window'];
    function loanDirective(dal, notifications, $mdExpansionPanel, $window) {
        return {
            restrict: 'A',
            scope: {
                model: '=',
                updateloaninfo: '&'
            },
            templateUrl: '/app/components/directives/loan/loan.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;

                $scope.$on('updateData', function (e, args) {
                    $scope.updateloaninfo();
                });

                //FUNCTIONS
                vm.subGo = subGo;

                //INIT
                init();

                function init() {
                    vm.model.initLoanSearchPage = true;
                    vm.model.subPage = 'search';
                }
                function subGo(where) {
                    vm.model.subPage = where;

                    if (vm.model.subPage === 'balances') {
                        vm.model.initLoanBalancesPage = true;
                    }
                    if (vm.model.subPage === 'contacts') {
                        vm.model.initLoanContactsPage = true;
                    }
                    if (vm.model.subPage === 'details') {
                        vm.model.initLoanDetailsPage = true;
                    }
                    if (vm.model.subPage === 'property') {
                        vm.model.initLoanPropertyPage = true;
                    }
                    if (vm.model.subPage === 'search') {
                        vm.model.initLoanSearchPage = true;
                    }
                }
            }

            , link: function (scope, element, attr, ctrl) {

            }
        }
    }
})();


*/