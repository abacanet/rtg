(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanContactsDirective', loanContactsDirective);

    loanContactsDirective.$inject = ['dal', '$mdExpansionPanel', 'notifications'];
    function loanContactsDirective(dal, $mdExpansionPanel, notifications) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanContacts/loanContacts.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;
                $scope.myDate = new Date();

                $scope.minDate = new Date(
                    $scope.myDate.getFullYear(),
                    $scope.myDate.getMonth() - 2,
                    $scope.myDate.getDate()
                    );

                $scope.maxDate = new Date(
                    $scope.myDate.getFullYear(),
                    $scope.myDate.getMonth() + 2,
                    $scope.myDate.getDate());

                $scope.onlyWeekendsPredicate = function (date) {
                    var day = date.getDay();
                    return day === 0 || day === 6;
                };

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