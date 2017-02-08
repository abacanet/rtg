(function () {
    'use strict';

    angular.module('reverseQuestApp.loan').controller('LoanDetailCtrl', LoanDetailCtrl);
    LoanDetailCtrl.$inject = ['dal', 'errorHandler', '$stateParams'];

    function LoanDetailCtrl(dal, errorHandler, $stateParams) {
        var vm = this;
        vm.searchParams = {};
        vm.searchParams.aiLoanSKey = $stateParams.LoanSkey

        dal.getSearchResults('?aiLoanSKey=' + vm.searchParams.aiLoanSKey).then(function (result) {
            //debugger;
        }).catch(errorHandler.errorNotification);

    }

}());
