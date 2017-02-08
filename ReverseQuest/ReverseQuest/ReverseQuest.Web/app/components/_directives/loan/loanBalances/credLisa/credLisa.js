(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('credLisaDirective', credLisaDirective);

    credLisaDirective.$inject = ['dal'];
    function credLisaDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/credLisa/credLisa.html',
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