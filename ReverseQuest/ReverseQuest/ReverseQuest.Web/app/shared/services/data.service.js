(function () {
    'use strict';

    //MODULE COMPONENTS
    angular.module('reverseQuestApp.shared').factory('dal', dal);
    dal.$inject = ['$http', '$q', 'jsonHelper', '$resource', '$cacheFactory', 'appSetting'];

    //COMPONENT DEFINITION
    function dal($http, $q, jsonHelper, $resource, $cacheFactory, appSettings) {
        var cache  = $cacheFactory('dataService');

        return {

            refapi: (function () {
                return $resource(appSettings.serverPath + 'refapi/v1/:id', {id: '@id'}, {
                    'get': { method: 'GET', cache: cache },
                    'query': { method: 'GET', cache: cache, isArray: true }
                });
            }()),

            lsapi: (function () {
                return $resource(appSettings.serverPath + 'api/ls/:id', {id: '@id'}, {
                    'get': { method: 'GET', cache: cache },
                    'query': { method: 'GET', cache: cache, isArray: true }
                });
            }()),

            lssapi: (function () {
                return $resource(appSettings.serverPath + 'api/lss/:id', {id: '@id'}, {
                    'get': { method: 'GET', cache: cache },
                    'query': { method: 'GET', cache: cache, isArray: true }
                });
            }()),

            rppapi: (function () {
                return $resource(appSettings.serverPath + 'api/rpp/:id', { id: '@id' }, {
                    'get': { method: 'GET', cache: cache },
                    'query': { method: 'GET', cache: cache, isArray: true }
                });
            }()),


            // Get Search Results
            getSearchResults: function (searchParameters) {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', searchParameters, false);
            },

            // Get Search Results
            getNoteSearchResults: function (searchParameters) {
                return jsonHelper.postJsonData(RQ_WEBAPIURL + 'Loan/NotesSearch?aiPageNumber=1&aiNumberOfRecords=100', searchParameters, false);
            },

            // Get Search Results
            getQCSearchResults: function (searchParameters) {
                return jsonHelper.postJsonData(RQ_APIURL + '/Loan/QCSearch?aiPageNumber=1&aiNumberOfRecords=100', searchParameters, false);
            },
            
            // Save Loan Boarding
            saveLoanBoarding: function (loanBoardingVM) {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanBoarding/Save', loanBoardingVM, false);
            },

            // Get Laon Balances
            getLoanBalances: function (sKey) {
                return jsonHelper.getJsonData(RQ_APIURL + '/Loan/GetLoanBalance?sKey=' + sKey, false);
            },

            // Get Loan Details
            getLoanDetails: function (sKey) {
                return jsonHelper.getJsonData(RQ_APIURL + '/Loan/GetLoanDetail?sKey=' + sKey, false);
            },

            // Get Investors
            getInvestors: function (clientId) {
                return jsonHelper.getJsonData(RQ_APIURL + '/LoanBoarding/GetInvestors?clientId=' + clientId, false);
            },

            // Get Servicers
            getServicers: function (clientId) {
                return jsonHelper.getJsonData(RQ_APIURL + '/LoanBoarding/GetServicers?clientId=' + clientId, false);
            },

            // Get Investor Pools
            getInvestorPools: function (clientId) {
                return jsonHelper.getJsonData(RQ_APIURL + '/LoanBoarding/GetInvestorPools?clientId=' + clientId, false);
            },


             // Get Credit Types
            getCreditTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get SPOCs
            getSPOCS: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Boarding Types
            getboardingTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get States
            getStates: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Loan Statuses
            getLoanStatuses: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Contact Types
            getContactTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Doc Types
            getDocTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

            // Get Alerts
            getAlerts: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Investor Pools
            getInvestorPools: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

             // Get Payment Plan Types
            getPaymentPlanTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

            // Get Payment Plan Types
            getProductTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

            // Get Rate Index Types
            getRateIndexTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            },

            // Get ARM Types
            getARMTypes: function () {
                return jsonHelper.postJsonData(RQ_APIURL + '/LoanSearch/GetLoanSearchResults', {}, false);
            }

        };

    }
})();