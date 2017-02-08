(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanRecordingDirective', loanRecordingDirective);

    loanRecordingDirective.$inject = ['dal'];
    function loanRecordingDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanDetails/loanRecording/loanRecording.html',
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
                    cleanDates();
                }
                function cleanDates() {
                    vm.model.ClosingSignedDate = cleanDate(angular.copy(vm.model.ClosingSignedDate));
                    vm.model.FundedDate = cleanDate(angular.copy(vm.model.FundedDate));
                    vm.model.FhaCaseNumAssignedDate = cleanDate(angular.copy(vm.model.FhaCaseNumAssignedDate));
                    vm.model.MicDate = cleanDate(angular.copy(vm.model.MicDate));
                    vm.model.StormSentDate = cleanDate(angular.copy(vm.model.StormSentDate));
                    vm.model.RecordedDate = cleanDate(angular.copy(vm.model.RecordedDate));
                }

            }

            , link: function (scope, element, attr, ctrl) {

            }
        };
    }
})();