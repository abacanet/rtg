(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('payPlanInfoDirective', payPlanInfoDirective);

    payPlanInfoDirective.$inject = ['dal'];
    function payPlanInfoDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/payPlanInfo/payPlanInfo.html',
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