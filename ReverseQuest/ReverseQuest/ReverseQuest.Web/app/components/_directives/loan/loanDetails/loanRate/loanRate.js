(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanRateDirective', loanRateDirective);

    loanRateDirective.$inject = ['dal'];
    function loanRateDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanDetails/loanRate/loanRate.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;

                //FUNCTIONS

                //INIT
                init();

                function init() {
                    console.log('loanRate', vm.model);
                    const today = new Date();

                    //Date Validations
                    $scope.minDate = minDate(today, 2);
                    $scope.maxDate = maxDate(today, 2);
                    $scope.weekendsOnly = weekendsOnly;
                    $scope.businessDaysOnly = businessDaysOnly;

                    //Date Cleanup
                    cleanDates();
                }

                function cleanDates() {
                    vm.model.FirstArmChangeDate = cleanDate(angular.copy(vm.model.FirstArmChangeDate));
                    vm.model.NextArmChangeDate = cleanDate(angular.copy(vm.model.NextArmChangeDate));
                }
            }

            , link: function (scope, element, attr, ctrl) {

            }
        };
    }
})();