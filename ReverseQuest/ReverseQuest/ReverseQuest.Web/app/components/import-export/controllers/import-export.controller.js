angular.module('reverseQuestApp.import-export').controller('ImportExportCtrl', function ($scope, loanboardingDal, $timeout, dal, utils, $interval) {

    var vm = this;
    vm.clientId = 20;
    vm.boardingTypes = [{ Skey: 1, Name: 'Flow Loan' }, { Skey: 2, Name: 'Transfer Loan' }];
    vm.confirmationDialogVisible = false;
    vm.loanBoarding = {};


    function getSelectLists() {

        dal.refapi.query({ id: 'InvestorActive' }, function (data) {
            if (typeof data === 'object') {
                vm.investors = data.sort(utils.sortByProperty('investor_name'));
            }
        });

        dal.refapi.query({ id: 'LoanServicerActive' }, function (data) {
            if (typeof data === 'object') {
                vm.servicers = data.sort(utils.sortByProperty('servicer_name'));;
            }
        });

        dal.refapi.query({ id: 'LoanPoolActive' }, function (data) {
            if (typeof data === 'object') {
                vm.investorPools = data.sort(utils.sortByProperty('loan_pool_short_description'));;
            }
        });

        dal.refapi.query({ id: 'PropertyTypeCategoryActive' }, function (data) {
            if (typeof data === 'object') {
                vm.propertyType = data.sort(utils.sortByProperty('property_type_category_description'));;
            }
        });
    }


    vm.onSelect = function (e) {
        var message = $.map(e.files, function (file) { return file.name; }).join(", ");
        // kendoConsole.log("event :: select (" + message + ")");
    };

    vm.onBoardingTypeChange = function (e) {
        if (vm.loanBoarding.BoardingType !== 'Transfer Loan') {
            vm.loanBoarding.PriorServicer = null;
        }
    }

    vm.next = function (form) {
        if (form.$valid) {
            var tabs = vm.tabStrip.items();
            tabs[1].disabled = false;
            vm.tabStrip.select(1);
        }
        else {
            var tabs = vm.tabStrip.items();
            tabs[1].disabled = true;
        }
    };

    vm.save = function (e) {
        vm.confirmationDialog.open();
    }

    vm.onCancel = function (e) {

    }

    vm.onOK = function (e) {

    }

    //OPTIONS
    vm.loanBoardingFileUploadOptions = {
        multiple: true,
        async: {
            saveUrl: RQ_APIURL + "/LoanBoarding/Upload",
            autoUpload: false,
            batch: true
        },
        dropZone: ".dropZoneElement",
        validation: {
            allowedExtensions: [".xml", ".txt"]
        },
        upload: function (e) {
            e.data = vm.loanBoarding;
        },
        localization: {
            uploadSelectedFiles: "Save Data"
        },
        success: function (e) {
            vm.uploadResponse = "Response from the server: " + e.response.status;

            //$scope.$watch('vm.boardingResult', function () {
            //    //if (vm.)
            //    alert('hey job done!');
            //});
            //var promise = $interval(GetBatchStatus(), 1000);
            GetBatchStatus();
            //while (status.BatchStatusDescription !== "Complete") {
            //    $timeout(function () {
            //        vm.boardingResult = loanboardingDal.getBoardingStatus(vm.loanBoarding.BatchSkey);
            //    }, 10000);
            //};

            //vm.boardingResult = loanboardingDal.getBoardingStatus(vm.loanBoarding.BatchSkey);
            //$scope.$apply();
        },
        error: function (e) {
            vm.uploadResponse = "Errors detected " + e.reponse;
            $scope.$apply();
        }
    };



    function GetBatchStatus() {
        vm.boardingResult = "Processing....";
        loanboardingDal.getBoardingStatus(vm.loanBoarding.BatchSkey).then(function (response) {
            vm.boardingResult = response.data;
            console.log(vm.boardingResult.BatchStatusDescription);
            if (vm.boardingResult.BatchStatusDescription !== "Complete") {
                $timeout(function () {
                    GetBatchStatus();
                }, 2000);

            } else  {
                loanboardingDal.getBoardingResults(vm.loanBoarding.BatchSkey).then(function (response) {
                    vm.boardingResult = response.data;
                });
            }
        });

    }

    vm.confirmationDialogOptions = {
        actions: [{
            text: "OK",
            action: function (e) {
                vm.uploadResponse = "Waiting....";
                vm.confirmationDialogVisible = false;
                vm.confirmationDialog.close();
                loanboardingDal.getBatchSkey().then(function (response) {
                    if (response.data > 0) {
                        vm.loanBoarding.BatchSkey = response.data;
                        $(".k-upload-selected").click();
                    }
                });
                return false;
            },
            primary: true
        }, {
            text: "Cancel"
        }]
    }

    //INIT
    init();

    function init() {
        getSelectLists();
    }

    $timeout(function () {
        //this is a hack, as tab is undefined
        var tabs = vm.tabStrip.items();
        tabs[1].disabled = true;
    }, 2000);

    $(document).ready(function () {
        //vm.loanBoarding.Servicer = 1;
        //vm.loanBoarding.Investor = 1;
        //vm.loanBoarding.InvestorPool = 1;
        //vm.loanBoarding.BoardingType = 1;
        //$(".k-upload-selected").hide();  //hack
    });


});