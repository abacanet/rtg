(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('priorServicerInfoDirective', priorServicerInfoDirective);

    priorServicerInfoDirective.$inject = ['dal'];
    function priorServicerInfoDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanDetails/priorServicerInfo/priorServicerInfo.html',
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