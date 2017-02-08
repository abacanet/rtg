(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('principalLimitCalcDirective', principalLimitCalcDirective);

    principalLimitCalcDirective.$inject = ['dal'];
    function principalLimitCalcDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/principalLimitCalc/principalLimitCalc.html',
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