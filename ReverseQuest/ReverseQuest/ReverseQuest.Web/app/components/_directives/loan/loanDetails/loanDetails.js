(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanDetailsDirective', loanDetailsDirective);

    loanDetailsDirective.$inject = ['dal', '$mdExpansionPanel', 'notifications'];
    function loanDetailsDirective(dal, $mdExpansionPanel, notifications) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanDetails/loanDetails.html',
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
        };
    }
})();