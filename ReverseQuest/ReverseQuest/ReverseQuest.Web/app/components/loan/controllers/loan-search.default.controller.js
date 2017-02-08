(function () {
    'use strict';

    angular.module('reverseQuestApp.loan').controller('LoanSearchDefaultCtrl', LoanSearchDefaultCtrl);
    LoanSearchDefaultCtrl.$inject = ['$state', 'utils', 'errorHandler', 'session', 'dal', 'kendoGrid'];

    function LoanSearchDefaultCtrl($state, utils, errorHandler, session, dal, kendoGrid) {
        var clientId = 20;
        var vm = this;
        vm.searchParams = {};

        // Set Grid Configuration Options
        vm.loanSearchGridOptions = kendoGrid.options({
            dataSource: {
                data: []
            },
            noRecords: true,
            messages: {
                noRecords: "No data"
            },
            columns: [{
                field: "LoanSkey",
                title: "Loan SKey",
                width: 100
            },
                {
                    field: "OriginalLoanNumber",
                    title: "Original Loan #",
                    width: 140
                },
                {
                    field: "FhaCaseNumber",
                    title: "FHA Case #",
                    width: 130
                },
                {
                    field: "PriorServicerLoanNumber",
                    title: "Prior Servicer Loan #",
                    width: 160
                },
                {
                    field: "LoanStatus",
                    title: "Status",
                    width: 120
                },
                {
                    field: "LoanSubStatus",
                    title: "Sub Status",
                    width: 120
                },
                {
                    field: "BorrowerFirstName",
                    title: "Borrower First Name",
                    width: 160
                },
                {
                    field: "BorrowerLastName",
                    title: "Borrower Last Name",
                    width: 160
                },
                {
                    field: "CoborrowerFirstName",
                    title: "Co-Borrower First Name",
                    width: 170
                },
                {
                    field: "CoborrowerLastName",
                    title: "Co-Borrower Last Name",
                    width: 170
                },
                {
                    field: "BorrowerPhoneNumber",
                    title: "Borrower Phone #",
                    width: 150
                },
                {
                    field: "PropertyAddress1",
                    title: "Property Address",
                    width: 180
                },
                {
                    field: "PropertyCity",
                    title: "Property City",
                    width: 150
                },
                {
                    field: "PropertyState",
                    title: "Property State",
                    width: 110
                },
                {
                    field: "PropertyZipcode",
                    title: "Property Zip Code",
                    width: 140
                },
                {
                    field: "ServicerName",
                    title: "Servicer Name",
                    width: 160
                },
                {
                    field: "InvestorName",
                    title: "Investor Name",
                    width: 160
                },
                {
                    field: "LoanPoolDescription",
                    title: "Investor Pool",
                    width: 150
                },
                {
                    field: "ProductTypeDescription",
                    title: "Product Type",
                    width: 150
                },
                {
                    field: "PaymentPlanTypeDescription",
                    title: "Payment Plan",
                    width: 150
                },
                {
                    field: "RateIndexTypeDescription",
                    title: "Rate Index Type",
                    width: 150
                },
                {
                    field: "Spoc",
                    field: "SPOC",
                    width: 150
                },
                {
                    field: "EnbsFirstName",
                    title: "eNBS First Name",
                    width: 150
                },
                {
                    field: "EnbsLastName",
                    title: "eNBS Last Name",
                    width: 150
                },
                {
                    field: "BoardedDate",
                    template: "#= kendo.toString(BoardedDate, \"MM/dd/yyyy\") #",
                    title: "Boarded Date",
                    width: 150
                },
                {
                    field: "BoardingType",
                    title: "Boarding Type",
                    width: 150
                },
                {
                    field: "CreditType",
                    title: "Credit Type",
                    width: 150
                }
            ]
        });

        vm.submitHandler = function () {
            dal.getSearchResults(utils.removeEmptyProp(vm.searchParams)).then(function (result) {
                var grid = $("#grid").data("kendoGrid");
                if (result && result.data) {
                    grid.dataSource.data(result.data);
                }
            }).catch(errorHandler.errorNotification);
        };


        // Forward to detail page
        vm.viewDetails = function () {
            var grid = $("#grid").data("kendoGrid");
            var selectedItem = grid.dataItem(grid.select());
            $state.go('loan-detail', {
                LoanSkey: selectedItem.LoanSkey
            });
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


        vm.spocs = [{
            id: 0,
            name: 'Closed-Ended',
        },
            {
                id: 1,
                name: 'Open-Ended'
            }
        ];

        vm.boardingTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.contactTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.inclDocTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


        vm.exclDocTypes = [{
            id: 0,
            name: 'Flow Loan',
        },
            {
                id: 1,
                name: 'Transferred Loan'
            }
        ];


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

        vm.armTypes = [{
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