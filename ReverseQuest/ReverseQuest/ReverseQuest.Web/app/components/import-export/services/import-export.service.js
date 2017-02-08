(function () {
    'use strict';

    //MODULE COMPONENTS
    angular
        .module('reverseQuestApp.shared')
        .factory('loanboardingDal', ['$http', '$q', 'jsonHelper', loanboardingDal]);

    //COMPONENT DEFINITION
    function loanboardingDal($http, $q, jsonHelper) {
        //FACTORY DECLARATION
        var service = {
            getBoardingResults: getBoardingResults,
            getBoardingStatus: getBoardingStatus,
            saveLoanBoarding: saveLoanBoarding,
            getBatchSkey: getBatchSkey
        };
        return service;


        /////////////// Loan Boarding Functions /////////////////////////
        function getBatchSkey() {
            var data = jsonHelper.getJsonData(RQ_APIURL + '/LoanBoarding/GetBatchSkey', false);
            return data;
        }

        function getBoardingStatus(batchSkey) {
            return $http({
                method: 'GET',
                url: RQ_WEBAPIURL + 'Loan/BoardingStatus?aiBatchSkey=' + batchSkey
            }).then(function (data) {
                return data;
            });
        }

        function getBoardingResults(batchSkey) {
            return $http({
                method: 'GET',
                url: RQ_WEBAPIURL + 'Loan/BoardingResult?aiBatchSkey=' + batchSkey
            }).then(function (data) {
                return data;
            });
        }

        function saveLoanBoarding(loanBoardingVM) {
            var data = jsonHelper.postJsonData(RQ_APIURL + '/LoanBoarding/Save', loanBoardingVM, false);
            return data;
        }
        /////////////// End Loan Boarding Functions /////////////////////////
    }
})();