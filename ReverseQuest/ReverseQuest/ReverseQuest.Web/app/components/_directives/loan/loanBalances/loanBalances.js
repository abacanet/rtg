(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanBalancesDirective', loanBalancesDirective);

    loanBalancesDirective.$inject = ['dal', '$mdExpansionPanel', 'notifications'];
    function loanBalancesDirective(dal, $mdExpansionPanel, notifications) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/loanBalances.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;
                vm.model.today = new Date();

                // Sample data for pie chart
                $scope.pieData = [{
                        name: "Microsoft Internet Explorer",
                        y: 56.33
                    }, {
                        name: "Chrome",
                        y: 24.03,
                        sliced: true,
                        selected: true
                    }, {
                        name: "Firefox",
                        y: 10.38
                    }, {
                        name: "Safari",
                        y: 4.77
                    }, {
                        name: "Opera",
                        y: 0.91
                    }, {
                        name: "Proprietary or Undetectable",
                        y: 0.2
                    }]

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