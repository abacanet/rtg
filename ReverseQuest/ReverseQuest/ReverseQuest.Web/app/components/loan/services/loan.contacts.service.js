﻿(function () {
    'use strict';

    //MODULE COMPONENTS
    angular
        .module('reverseQuestApp.shared')
        .factory('loanContactsDal', ['$http', '$q', 'jsonHelper', loanContactsDal]);

    //COMPONENT DEFINITION
    function loanContactsDal($http, $q, jsonHelper) {
        //FACTORY DECLARATION
        var service = {
            update: update,
            create: create
        };
        return service;

        function update(loanContactVM) {
            //var dataPromise = jsonHelper.postJsonData(RQ_APIURL + '/LoanContact/Update', loanContactVM, false);
            //dataPromise.then(function (result) {                
            //    console.log("result" + result);
            //    return result;
            //});

            var data = jsonHelper.postJsonData(RQ_APIURL + '/LoanContact/Update', loanContactVM, false);
            return data;
        }

        function create(loanContactVM) {
            var data = jsonHelper.postJsonData(RQ_APIURL + '/LoanContact/Create', loanContactVM, false);
            return data;
        }

        /////////////// Loan Boarding Functions /////////////////////////
        //function getLoanContacts(loanSkey) {
        //    var data = jsonHelper.getJsonData(RQ_APIURL + '/LoanContact/GetLoanContacts?sKey=' + loanSkey, false);
        //    return data;
        //}

    }
})();