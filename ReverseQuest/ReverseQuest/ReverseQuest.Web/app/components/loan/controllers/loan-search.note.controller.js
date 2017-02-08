(function () {
    'use strict';

    angular.module('reverseQuestApp.loan').controller('LoanSearchNoteCtrl', LoanSearchNoteCtrl);
    LoanSearchNoteCtrl.$inject = ['$state', 'utils', 'errorHandler', 'session', 'dal', 'kendoGrid'];

    function LoanSearchNoteCtrl($state, utils, errorHandler, session, dal, kendoGrid) {
        var clientId = 20;
        var vm = this;
        vm.searchParams = {};

        vm.searchParams.aiPageNumber = 1;
        vm.searchParams.aiNumberOfRecords = 100;

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
                { field: "NoteSkey", title: "Note Skey", width: 150 },
                { field: "LoanSkey", title: "Loan SKey", width: 150 },
                { field: "OriginalLoanNumber", title: "Original Loan #", width: 150 },
                { field: "PriorServicerLoanNumber", title: "Prior Servicer Loan #", width: 150 },
                { field: "LoanStatus", title: "Loan Status", width: 150 },
                { field: "LoanSubStatus", title: "Loan Sub Status", width: 150 },
                { field: "HighImportanceFlag", title: "High Importance Flag", width: 150 },
                { field: "NoteTypeDescription", title: "Note Type Description", width: 150 },
                { field: "NoteTypeCategoryDescription", title: "Note Type Category Description", width: 150 },
                { field: "NoteText", title: "Note Text", width: 150 },
                { field: "ServicerName", title: "Servicer Name", width: 150 },
                { field: "InvestorName", title: "Investor Name", width: 150 },
                { field: "LoanPoolDescription", title: "Loan Pool Description", width: 150 },
                { field: "ProductTypeDescription", title: "Product Type Description", width: 150 },
                { field: "CreatedBy", title: "Created By", width: 150 },
                { field: "CreatedDate", title: "Created Date", width: 150 },
                { field: "MersMinNumber", title: "Mers Min #", width: 150 },
                { field: "LoanSubStatusCode", title: "Loan Sub-Status Code", width: 150 },
                { field: "NoteTypeSkey", title: "Note Type Skey", width: 150 },
                { field: "NoteTypeCategorySkey", title: "Note Type Category Skey", width: 150 },
                { field: "LoanServicerSkey", title: "Loan Servicer SKey", width: 150 },
                { field: "InvestorSkey", title: "Investor SKey", width: 150 },
                { field: "LoanPoolSkey", title: "Loan Pool SKey", width: 150 },
                { field: "ProductTypeSkey", title: "Product Type SKey", width: 150 },
                { field: "RecordCount", title: "Record Count", width: 150 },
                { field: "LoanStatusCode", title: "Loan Status Code", width: 150 }
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
        
        // Retrieve Results on Form Submit
        vm.submitHandler = function () {
            dal.getNoteSearchResults(utils.removeEmptyProp(vm.searchParams)).then(function (result) {
                var grid = $("#grid").data("kendoGrid");
                if (result && result.data) {
                    grid.dataSource.data(result.data);
                }
            }).catch(errorHandler.errorNotification);
        };

        // Display Loan Details View
        vm.viewDetails = function () {
            var grid = $("#grid").data("kendoGrid");
            var selectedItem = grid.dataItem(grid.select());
            $state.go('loan-detail', { LoanSkey: selectedItem.LoanSkey });
        };


        // Set Servicers
        dal.refapi.query({
            id: 'LoanServicerActive'
        }, function (data) {
            if (typeof data === 'object') {
                vm.servicers = data;
            }
        });


        // Set Investors
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


        // Set Loan Status
        dal.lsapi.query({
            id: 'refLoanStatus'
        }, function (data) {
            if (typeof data === 'object') {
                vm.loanStatuses = data;
            }
        });


        // Loan Sub Status
        dal.lssapi.query({
            id: 'refLoanSubStatus'
        }, function (data) {
            if (typeof data === 'object') {
                vm.loanSubStatuses = data;
            }
        });




    }



}());

