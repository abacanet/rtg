﻿(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('otherInfoDirective', otherInfoDirective);

    otherInfoDirective.$inject = ['dal'];
    function otherInfoDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanDetails/otherInfo/otherInfo.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;

                //FUNCTIONS


                //INIT
                init();

                function init() {
                    const today = new Date();

                    //Date Validations
                    $scope.minDate = minDate(today, 2);
                    $scope.maxDate = maxDate(today, 2);
                    $scope.weekendsOnly = weekendsOnly;
                    $scope.businessDaysOnly = businessDaysOnly;

                    //Date Cleanup
                    vm.model.BoardedDate = cleanDate(angular.copy(vm.model.BoardedDate));
                }

            }

            , link: function (scope, element, attr, ctrl) {

            }
        }
    }
})();