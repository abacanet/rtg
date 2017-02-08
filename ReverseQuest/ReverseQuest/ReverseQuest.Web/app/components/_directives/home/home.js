(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('homeDirective', homeDirective);

    homeDirective.$inject = ['dal', 'notifications', '$mdExpansionPanel', '$window'];
    function homeDirective(dal, notifications, $mdExpansionPanel, $window) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/home/home.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;

                //Sample options for first chart
                $scope.chartOptions = {
                    title: {
                        text: 'Payment History'
                    },
                    xAxis: {
                        categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                            'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
                    },

                    series: [{
                        data: [29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4]
                    }]
                };

                //FUNCTIONS
                vm.subGo = subGo;

                //INIT
                init();

                function init() {
                    vm.model.subPage = 'dashboard';
                    vm.model.directiveBusy = false;
                    vm.model.loanBalances.InitDisbLimit.IdlExpirationDate = cleanDate(angular.copy(vm.model.loanBalances.InitDisbLimit.IdlExpirationDate)).toDateString();
                }
                function subGo(where) {
                    vm.model.subPage = where;
                }
            }

            , link: function (scope, element, attr, ctrl) {

            }
        }
    }
})();