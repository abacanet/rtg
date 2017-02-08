(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('otherBalanceDirective', otherBalanceDirective);

    otherBalanceDirective.$inject = ['dal'];
    function otherBalanceDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/otherBalance/otherBalance.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;

                //FUNCTIONS


                //INIT
                init();

                function init() {

                }

            }

            , link: function (scope, element, attr, ctrl) {

            }
        }
    }
})();