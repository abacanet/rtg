(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('lesaDirective', lesaDirective);

    lesaDirective.$inject = ['dal'];
    function lesaDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/lesa/lesa.html',
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