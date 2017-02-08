(function () {
    'use strict';

    angular.module('reverseQuestApp.loan').controller('LoanSearchQCCtrl', LoanSearchQCCtrl);
    LoanSearchQCCtrl.$inject =  ['$state', 'utils', 'errorHandler', 'session', 'dal', 'kendoGrid'];

    function LoanSearchQCCtrl($state, utils, errorHandler, session, dal, kendoGrid) {
        var clientId = 20;
        var vm = this;
        vm.searchParams = {};

        vm.loanSearchGridOptions = {
            dataSource: {
                data: []
            },
            noRecords: true,
            messages: {
                noRecords: "No data"
            },
            sortable: true,
            selectable: true,
            columns: [
                { field: "LoanSkey", title: "Loan SKey", width: 150 },
                { field: "OriginalLoanNumber", title: "Original Loan #", width: 150 },
                { field: "FhaCaseNumber", title: "FHA #", width: 150 },
                { field: "PriorServicerLoanNumber", title: "Prior Servicer Loan #", width: 150 },
                { field: "InvestorLoanNumber", title: "Investor Loan #", width: 150 },
                { field: "LoanStatus", title: "Loan Status", width: 150 },
                { field: "LoanSubStatus", title: "Loan Sub Status", width: 150 },
                { field: "BorrowerFirstName", title: "Borrower First Name", width: 150 },
                { field: "BorrowerLastName", title: "Borrower Last Name", width: 150 },
                { field: "CoborrowerFirstName", title: "Co-borrower First Name", width: 150 },
                { field: "CoborrowerLastName", title: "Co-borrower Last Name", width: 150 },
                { field: "BorrowerPhoneNumber", title: "Borrower Phone #", width: 150 },
                { field: "EnbsFirstName", title: "Enbs First Name", width: 150 },
                { field: "EnbsLastName", title: "Enbs Last Name", width: 150 },
                { field: "PropertyAddress1", title: "Property Address 1", width: 150 },
                { field: "PropertyAddress2", title: "Property Address 2", width: 150 },
                { field: "PropertyCity", title: "Property City", width: 150 },
                { field: "PropertyCounty", title: "Property County", width: 150 },
                { field: "PropertyState", title: "Property State", width: 150 },
                { field: "PropertyZipcode", title: "Property Zip code", width: 150 },
                { field: "ServicerName", title: "Servicer Name", width: 150 },
                { field: "InvestorName", title: "Investor Name", width: 150 },
                { field: "LoanPoolDescription", title: "Loan Pool Description", width: 150 },
                { field: "ProductTypeDescription", title: "Product Type Description", width: 150 },
                { field: "PaymentPlanTypeDescription", title: "Payment Plan Type Description", width: 150 },
                { field: "ArmTypeDescription", title: "Arm Type Description", width: 150 },
                { field: "RateIndexTypeDescription", title: "Rate Index Type Description", width: 150 },
                { field: "Spoc", title: "Spoc", width: 150 },
                { field: "BoardedBy", title: "Boarded By", width: 150 },
                { field: "BoardedDate", title: "Boarded Date", width: 150 },
                { field: "BoardingTypeDescription", title: "Boarding Type Description", width: 150 },
                { field: "CreditTypeDescription", title: "Credit Type Description", width: 150 },
                { field: "MersMinNumber", title: "Mers Min #", width: 150 },
                { field: "LoanSubStatusCode", title: "Loan Sub-Status Code", width: 150 },
                { field: "LoanServicerSkey", title: "Loan Servicer SKey", width: 150 },
                { field: "InvestorSkey", title: "Investor SKey", width: 150 },
                { field: "LoanPoolSkey", title: "Loan Pool SKey", width: 150 },
                { field: "ProductTypeSkey", title: "Product Type SKey", width: 150 },
                { field: "PaymentPlanType", title: "Payment Plan Type", width: 150 },
                { field: "ArmType", title: "ARM Type", width: 150 },
                { field: "RateIndexTypeSkey", title: "Rate Index Type Skey", width: 150 },
                { field: "SpocSkey", title: "Spoc SKey", width: 150 },
                { field: "BoardingType", title: "Boarding Type", width: 150 },
                { field: "CreditType", title: "Credit Type", width: 150 },
                { field: "RecordCount", title: "Record Count", width: 150 },
                { field: "LoanStatusCode", title: "Loan Status Code", width: 150 },
                { field: "Filler", title: "Filler", width: 150 }
                
            ],
            pageable: {
                pageSize: 20,
                pageSizes: [10, 25, 50, 100, 'All'],
                buttonCount: 5,
                message: {
                    empty: 'No Data',
                    allPages: 'All'
                }
            }
        };

        vm.submitHandler = function () {
            dal.getQCSearchResults(utils.removeEmptyProp(vm.searchParams)).then(function (result) {
                var grid = $("#grid").data("kendoGrid");
                if (result && result.data) {
                    grid.dataSource.data(result.data);
                }
            }).catch(errorHandler.errorNotification);
        };


        vm.viewDetails = function () {
            var grid = $("#grid").data("kendoGrid");
            var selectedItem = grid.dataItem(grid.select());
            $state.go('loan-detail', { LoanSkey: selectedItem.LoanSkey });
        };


        // Set States
        dal.refapi.query({
            id: 'States'
        }, function (data) {
            if (typeof data === 'object') {
                vm.states = data;
            }
        });


        // Set Servicers
        dal.refapi.query({
            id: 'LoanServicerActive'
        }, function (data) {
            if (typeof data === 'object') {
                vm.servicers = data;
            }
        });


        // Set Investor
        dal.refapi.query({
            id: 'InvestorActive'
        }, function (data) {
            if (typeof data === 'object') {
                vm.investors = data;
            }
        });


        // Set Investor Pools
        dal.refapi.query({
            id: 'LoanPoolActive'
        }, function (data) {
            if (typeof data === 'object') {
                vm.investorPools = data;
            }
        });



        dal.lsapi.query({
            id: 'refLoanStatus'
        }, function (data) {
            if (typeof data === 'object') {
                vm.loanStatuses = data;
            }
        });


        dal.lssapi.query({
            id: 'refLoanSubStatus'
        }, function (data) {
            if (typeof data === 'object') {
                vm.loanSubStatuses = data;
            }
        });


        dal.rppapi.query({
            id: 'refPaymentPlanType'
        }, function (data) {
            if (typeof data === 'object') {
                vm.paymentPlanTypes = data;
            }
        });


        vm.inclAlerts = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.exclAlerts = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.productTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.rateIndexTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];



    }

}());

