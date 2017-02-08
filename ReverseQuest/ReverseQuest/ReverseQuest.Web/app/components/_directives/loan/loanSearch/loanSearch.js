(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('loanSearchDirective', loanSearchDirective);

    loanSearchDirective.$inject = ['dal', 'notifications', 'session', '$window'];
    function loanSearchDirective(dal, notifications, session, $window) {
        return {
            restrict: 'A',
            scope: {
                model: '=',
                gotoloandetail: '&'
            },
            templateUrl: '/app/components/directives/loan/loanSearch/loanSearch.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS
                vm.model = $scope.model;
                vm.model.searchResults = new kendo.data.DataSource();
                //FUNCTIONS

                //Search Functions
                angular.element($window).on('keydown', function (e) {
                    if ((e.keyCode === 13 || e.which === 13) && vm.model.sKey) {
                        session.sKey = vm.model.sKey;
                        session.saveSessionToStorage();
                        $scope.$emit('updateData', { searchCriteria: vm.model.sKey });
                    }
                });

                // BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010436","LoanSubStatusCode":"10160","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,
                //     "ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"10","Filler":" "},{"LoanSkey":43593,"OriginalLoanNumber":"0043593000","FhaCaseNumber":"042-9008411","PriorServicerLoanNumber":"","InvestorLoanNumber":"","LoanStatus":"ACTIVE","LoanSubStatus":"Active","BorrowerFirstName":"RAYMOND","BorrowerLastName":"FUNLastName 10 43593 119106","CoborrowerFirstName":"GERALDINE","CoborrowerLastName":"FUNLastName 20 43593 119107","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43593","PropertyAddress2":"","PropertyCity":"GILROY","PropertyCounty":"Santa Clara","PropertyState":"CA","PropertyZipcode":"95020","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"S1L-GNMA 742613","ProductTypeDescription":"HECM Standard - Refinance","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287176102327)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010477","LoanSubStatusCode":"10160","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,"ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"10","Filler":" "},{"LoanSkey":43594,"OriginalLoanNumber":"0043594000","FhaCaseNumber":"197-5121613","PriorServicerLoanNumber":"","InvestorLoanNumber":"","LoanStatus":"INACTIVE","LoanSubStatus":"Death","BorrowerFirstName":"VIRGINIA","BorrowerLastName":"FORLastName 10 43594 119110","CoborrowerFirstName":"GENE","CoborrowerLastName":"FORLastName 20 43594 119109","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43594","PropertyAddress2":"","PropertyCity":"ALHAMBRA","PropertyCounty":"Los Angeles","PropertyState":"CA","PropertyZipcode":"91801","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"S1L-GNMA 742613","ProductTypeDescription":"HECM Standard - Refinance","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287176102710)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010386","LoanSubStatusCode":"90180","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,"ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"90","Filler":" "},{"LoanSkey":43596,"OriginalLoanNumber":"0043596000","FhaCaseNumber":"048-6223138","PriorServicerLoanNumber":"","InvestorLoanNumber":"","LoanStatus":"ACTIVE","LoanSubStatus":"Active","BorrowerFirstName":"ROBERT","BorrowerLastName":"ZADLastName 10 43596 119116","CoborrowerFirstName":null,"CoborrowerLastName":null,"BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43596","PropertyAddress2":"","PropertyCity":"HUNTINGTON BEACH","PropertyCounty":"Orange","PropertyState":"CA","PropertyZipcode":"92646","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"S1L-GNMA 742613","ProductTypeDescription":"HECM Standard - Refinance","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287176916227)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010428","LoanSubStatusCode":"10160","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,"ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"10","Filler":" "},{"LoanSkey":43602,"OriginalLoanNumber":"0043602000","FhaCaseNumber":"137-5975544","PriorServicerLoanNumber":"","InvestorLoanNumber":"","LoanStatus":"ACTIVE","LoanSubStatus":"Active","BorrowerFirstName":"John","BorrowerLastName":"RatLastName 10 43602 119187","CoborrowerFirstName":"Evelyn","CoborrowerLastName":"RatLastName 20 43602 119188","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43602","PropertyAddress2":"","PropertyCity":"NORTH BARRINGTON","PropertyCounty":"Lake","PropertyState":"IL","PropertyZipcode":"60010","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"S1L-GNMA 742613","ProductTypeDescription":"HECM Standard - Refinance","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287436444910)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010568","LoanSubStatusCode":"10160","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,"ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"10","Filler":" "},{"LoanSkey":43628,"OriginalLoanNumber":"0043628000","FhaCaseNumber":"052-5948019","PriorServicerLoanNumber":"","InvestorLoanNumber":"174440","LoanStatus":"INACTIVE","LoanSubStatus":"CT 23 Short Sale (Pre FCL) - PIF","BorrowerFirstName":"James","BorrowerLastName":"BarLastName 10 43628 119248","CoborrowerFirstName":"Norma","CoborrowerLastName":"BarLastName 20 43628 119249","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43628","PropertyAddress2":"","PropertyCity":"DURANGO","PropertyCounty":"La Plata","PropertyState":"CO","PropertyZipcode":"81303-6672","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"RMS 200 -GNMA Buyout","ProductTypeDescription":"HECM Standard - Refinance","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287437014547)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100795400050035640","LoanSubStatusCode":"90120","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100111,"ProductTypeSkey":12,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"90","Filler":" "},{"LoanSkey":43681,"OriginalLoanNumber":"0043681000","FhaCaseNumber":"052-6032710","PriorServicerLoanNumber":"","InvestorLoanNumber":"","LoanStatus":"INACTIVE","LoanSubStatus":"Refinanced","BorrowerFirstName":"Hans","BorrowerLastName":"SchLastName 10 43681 119404","CoborrowerFirstName":"Ingrid","CoborrowerLastName":"SchLastName 20 43681 119405","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43681","PropertyAddress2":"","PropertyCity":"THORNTON","PropertyCounty":"Adams","PropertyState":"CO","PropertyZipcode":"80602","ServicerName":"Reverse Mortgage Solutions, Inc.","InvestorName":"Reverse Mortgage Solutions, Inc.","LoanPoolDescription":"S1L-GNMA 742613","ProductTypeDescription":"HECM Standard for Purchase","PaymentPlanTypeDescription":"Line of Credit","ArmTypeDescription":"Fixed","RateIndexTypeDescription":"No Index","Spoc":"","BoardedBy":"System.Load","BoardedDate":"/Date(1287522232280)/","BoardingTypeDescription":"Flow Loan","CreditTypeDescription":"Closed-Ended","MersMinNumber":"100659800255010501","LoanSubStatusCode":"90190","LoanServicerSkey":10,"InvestorSkey":100,"LoanPoolSkey":100058,"ProductTypeSkey":11,"PaymentPlanType":10,"ArmType":"F","RateIndexTypeSkey":250,"SpocSkey":null,"BoardingType":"F","CreditType":"C","RecordCount":79740,"LoanStatusCode":"90","Filler":" "},{"LoanSkey":43690,"OriginalLoanNumber":"0043690000","FhaCaseNumber":"512-0101248","PriorServicerLoanNumber":"","InvestorLoanNumber":"234087","LoanStatus":"ACTIVE","LoanSubStatus":"Active","BorrowerFirstName":"Mary","BorrowerLastName":"SauLastName 10 43690 119468","CoborrowerFirstName":"Ignacio","CoborrowerLastName":"SauLastName 20 43690 119467","BorrowerPhoneNumber":null,"EnbsFirstName":null,"EnbsLastName":null,"PropertyAddress1":"Property Address Line1 43690","Proper…"


                $scope.loanSearchGridOptions = {
                    dataSource: {
                        transport: {
                            read:
                                {
                                    url: RQ_APIURL + '/LoanSearch/GetLoanSearchResults',
                                    type: 'POST',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: 'json'
                                },
                                parameterMap: function (options, operation) {
                                    return JSON.stringify(vm.model.searchParameters);
                                }
                        }
                    },
                    resizable: true,
                    sortable: true,
                    selectable: true,
                    columns: [
                        { field: "LoanSkey", title: "Loan SKey", width: 120 },
                        { field: "OriginalLoanNumber", title: "Original Loan #", width: 120 },
                        { field: "FhaCaseNumber", title: "FHA Case #", width: 140 },
                        { field: "PriorServicerLoanNumber", title: "Prior Servicer Loan #", width: 120 },
                        { field: "InvestorLoanNumber", title: "Investor Loan #", width: 120 },
                        { field: "LoanStatus", title: "Status", width: 120 },
                        { field: "LoanSubStatus", title: "Sub Status", width: 120 },
                        { field: "BorrowerFirstName", title: "Bor. First Name", width: 120 },
                        { field: "BorrowerLastName", title: "Bor. Last Name", width: 150 },
                        { field: "CoborrowerFirstName", title: "CoBorrower First Name", width: 120 },
                        { field: "CoborrowerLastName", title: "CoBorrower Last Name", width: 150 },
                        { field: "BorrowerPhoneNumber", title: "Borrower Phone #", width: 150 },
                        { field: "EnbsFirstName", title: "eNBS First Name", width: 150 },
                        { field: "EnbsLastName", width: 150 },
                        { field: "PropertyAddress1", title: "Property Street Address", width: 150 },
                        { field: "PropertyCity", title: "City", width: 150 },
                        { field: "PropertyCounty", title: "County", width: 150 },
                        { field: "PropertyState", title: "State", width: 150 },
                        { field: "PropertyZipcode", title: "Zip", width: 150 },
                        { field: "ServicerName", title: "Servicer Name", width: 150 },
                        { field: "InvestorName", title: "Investor Name", width: 150 },
                        { field: "LoanPoolDescription", title: "Loan Pool", width: 150 },
                        { field: "ProductTypeDescription", title: "Product Type", width: 150 },
                        { field: "PaymentPlanTypeDescription", title: "Payment Plan", width: 150 },
                        { field: "ArmTypeDescription", title: "ARM Type", width: 150 },
                        { field: "RateIndexTypeDescription", title: "Rate Index Type", width: 150 },
                        { field: "Spoc", width: 150 },
                        { field: "BoardedBy", title: "Boarded By", width: 150 },
                        { field: "BoardedDate", template: "#= kendo.toString(BoardedDate, \"MM/dd/yyyy\") #", title: "Boarded Date", width: 150 },
                        { field: "BoardingType", title: "Boarding Type", width: 150 },
                        { field: "CreditType", title: "Credit Type", width: 150 },
                        { field: "MersMinNumber", title: "MERS Min #", width: 150 }
                    ],
                    pageable: {
                        pageSize: 30,
                        pageSizes: [10, 25, 50, 100, 'All'],
                        buttonCount: 5,
                        message: {
                            empty: 'No Data',
                            allPages: 'All'
                        }
                    },
                    change: function onChange(arg) {
                        var grid = arg.sender;
                        var currentDataItem = grid.dataItem(this.select());
                        session.sKey = currentDataItem.LoanSkey;
                        $scope.gotoloandetail();
                    }
                }

                $scope.search = function () {
                    console.log(vm.model.searchParameters);
                    $scope.loanSearchGrid.dataSource.read({ searchParameters: vm.model.searchParameters });
                }

                $scope.resetForm = function () {
                    vm.model.searchParameters = {};
                    $scope.searchForm.$setPristine();
                    $scope.loanSearchGrid.dataSource.read();
                }


                //INIT
                init();

                function init() {
                    vm.model.sKey = session.sKey;
                }
            }

            , link: function (scope, element, attr, ctrl) {
                console.log('elem', element);
            }
        }
    }
})();