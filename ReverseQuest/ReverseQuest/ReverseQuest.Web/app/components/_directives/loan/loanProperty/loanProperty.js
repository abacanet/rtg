(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanPropertyDirective', loanPropertyDirective);

    loanPropertyDirective.$inject = ['dal', '$mdExpansionPanel', 'notifications'];
    function loanPropertyDirective(dal, $mdExpansionPanel, notifications) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanProperty/loanProperty.html',
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