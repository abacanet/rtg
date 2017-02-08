
angular.module('reverseQuestApp.loan').controller('LoanBalanceCtrl', function ($scope, $uibModal, $log, $document, dal) {
    var vm = this;
    vm.actionMessage = "";
    vm.loanBalance = {};
    //vm.loanBalance.clientId = 20;
    vm.loanBalance.LoanSkey = 569701;
    vm.saveType = "";

    vm.transactions = [{
        transaction_date: "10/10/2017",
        effective_date: "10/10/2017",
        trans_code: 234,
        short_trans_desc: "tran",
        transaction_description: "tran des",
        principal_amt: 1000,
        int_amt: 1000,
        mip_amt: 1000,
        serv_fee_amt: 1000,
        loan_bal_trans_amt: 1000,
        corp_adv_borrower_amt: 1000,
        corp_adv_investor_amt: 1000,
        percent_recoverable: 10,
        recoverable_amt: 1000,
        overage_amt: 1000,
        debenture_interest_dp: 3,
        debenture_interest_other: 3,
        total_trans_amt: 1000,
        int_rate: 4,
        create_by: "user",
        create_date: "10/10/2017",
        changed_by: "user",
        change_date: "10/10/2017",
        trans_id: 333,
        reference_trans_id: 33,
        eboutique_sent_date: "10/10/2017",
        hud_sent_date: "10/10/2017",
        trans_adjustment_reason: "because",
        disbursement_skey: 2
    },
    {
        transaction_date: "10/10/2017",
        effective_date: "10/10/2017",
        trans_code: 234,
        short_trans_desc: "tran",
        transaction_description: "tran des",
        principal_amt: 1000,
        int_amt: 1000,
        mip_amt: 1000,
        serv_fee_amt: 1000,
        loan_bal_trans_amt: 1000,
        corp_adv_borrower_amt: 1000,
        corp_adv_investor_amt: 1000,
        percent_recoverable: 10,
        recoverable_amt: 1000,
        overage_amt: 1000,
        debenture_interest_dp: 3,
        debenture_interest_other: 3,
        total_trans_amt: 1000,
        int_rate: 4,
        create_by: "user",
        create_date: "10/10/2017",
        changed_by: "user",
        change_date: "10/10/2017",
        trans_id: 333,
        reference_trans_id: 33,
        eboutique_sent_date: "10/10/2017",
        hud_sent_date: "10/10/2017",
        trans_adjustment_reason: "because",
        disbursement_skey: 2
    }];

    vm.balanceGridOptions = {
        dataSource: { data: vm.transactions }, //{
        //transport: {
        //    read:
        //        {
        //            url: RQ_APIURL + '/loanBalance/GetloanBalances?sKey=' + vm.loanBalance.LoanSkey,
        //            type: 'GET',
        //            contentType: "application/json; charset=utf-8",
        //            dataType: 'json'
        //        },
        //    //parameterMap: function (options, operation) {
        //    //    return JSON.stringify(vm.model.searchParameters);
        //    //}
        //}
        //},
        change: function (e) {
            //var selectedItem = vm.contactsGrid.dataItem(vm.contactsGrid.select());
            //console.log(selectedItem);
            //vm.loanBalance = selectedItem;
            //vm.saveType = "update";
            //vm.actionMessage = "- Editing " + vm.loanBalance.FormatedName;
            //vm.buttonsVisible = true;
            //$scope.$apply();
        },
        //toolbar: ["create"],
        selectable: true,
        sortable: true,
        pageable: false,
        filterable: true,
        columns: [
        {
            field: "transaction_date",
            title: "Trans Date", width: "120px",
            format: "{0:MMM dd, yyyy}",
            parseFormats: "{0:MM/dd/yyyy}",
            headerAttributes: { style: "text-align: center;" },
            attributes: { style: "text-align:center !important;padding-right: 25px;" },
            filterable: {
                ui: function (element) {
                    element.kendoDatePicker({
                        format: "MMM dd, yyyy"
                    });
                }
            }
        },
        {
            field: "effective_date",
            title: "Effective Date", width: "120px",
            format: "{0:MMM dd, yyyy}",
            parseFormats: "{0:MM/dd/yyyy}",
            headerAttributes: { style: "text-align: center;" },
            attributes: { style: "text-align:center !important;padding-right: 25px;" },
            filterable: {
                ui: function (element) {
                    element.kendoDatePicker({
                        format: "MMM dd, yyyy"
                    });
                }
            }
        },
        {
            field: "trans_code",
            title: "Code", width: "120px",
            filterable: { multi: true, search: true }
        },
        {
            field: "short_trans_desc",
            title: "Description", width: "120px"
        },
        //{
        //    field: "transaction_description",
        //    title: "transaction_description", width: "120px"
        //},
        {
            field: "principal_amt",
            title: "Principal", width: "120px"
        },
        {
            field: "int_amt",
            title: "Initial", width: "120px"
        },
        {
            field: "mip_amt",
            title: "MIP", width: "120px"
        },
        {
            field: "serv_fee_amt",
            title: "Serv. Fee", width: "120px"
        },
        {
            field: "loan_bal_trans_amt",
            title: "Trans. Amount", width: "120px"
        },
        {
            field: "corp_adv_borrower_amt",
            title: "Borrower Advance", width: "120px"
        },
        {
            field: "corp_adv_investor_amt",
            title: "Investor Advance", width: "120px"
        },
        {
            field: "percent_recoverable",
            title: "% Recoverable", width: "120px"
        },
        {
            field: "recoverable_amt",
            title: "Recoverable", width: "120px"
        },
        {
            field: "overage_amt",
            title: "Overage", width: "120px"
        },
        {
            field: "debenture_interest_dp",
            title: "Interest DP", width: "120px"
        },
        {
            field: "debenture_interest_other",
            title: "Interest Other", width: "120px"
        },
        {
            field: "total_trans_amt",
            title: "Total", width: "120px"
        },
        {
            field: "int_rate",
            title: "Rate", width: "120px"
        },
        {
            field: "create_by",
            title: "Created By", width: "120px"
        },
        {
            field: "create_date",
            title: "Created", width: "120px"
        },
        {
            field: "changed_by",
            title: "Changed By", width: "120px"
        },
        {
            field: "change_date",
            title: "Changed", width: "120px"
        },
        {
            field: "trans_id",
            title: "Id", width: "120px"
        },
        {
            field: "reference_trans_id",
            title: "Ref Id", width: "120px"
        },
        {
            field: "eboutique_sent_date",
            title: "Eboutique Sent", width: "120px"
        },
        {
            field: "hud_sent_date",
            title: "Hud Sent", width: "120px"
        },
        {
            field: "trans_adjustment_reason",
            title: "Reason", width: "120px"
        },
        {
            field: "disbursement_skey",
            title: "skey", width: "120px"
        },

        ]
    };
    

    vm.winNewTransactionOptions = {
        position: {
            top: 200
        }
    }

    vm.winTransferFundsOptions = {
        position: {
            top: 200
        }
    }
    
    vm.winReclassDisbursementOptions = {
        position: {
            top: 200
        }
    }
    //vm.addNewContact = function () {
    //    vm.actionMessage = "- Adding New Contact";
    //    vm.loanBalance = vm.newContact;
    //    vm.buttonsVisible = true;
    //    vm.saveType = "create";
    //}

    //vm.saveContact = function () {
    //    var dataPromise;
    //    var message = "";
    //    if (vm.saveType === "update") {
    //        dataPromise = loanBalancesDal.update(vm.loanBalance);
    //    }
    //    else if (vm.saveType === "create") {
    //        dataPromise = loanBalancesDal.create(JSON.stringify(vm.loanBalance));
    //    }

    //    if (!angular.isUndefined(dataPromise)) {
    //        dataPromise.then(function (result) {
    //            if (result.statusText === 'OK') {
    //                message = "Record Saved..."
    //            }
    //            else {
    //                message = "Error: Record Not Saved..."
    //                console.log(result);
    //            }

    //            vm.contactsGrid.dataSource.read();

    //            vm.notificiationToast.show({
    //                kValue: message
    //            }, "ngTemplate");

    //            return result;
    //        });
    //    }
    //}

    //vm.copyContactAddresss = function () {
    //    vm.loanBalance.MailAddress1 = vm.loanBalance.Address1;
    //    vm.loanBalance.MailAddress2 = vm.loanBalance.Address2;
    //    vm.loanBalance.MailCity = vm.loanBalance.City;
    //    vm.loanBalance.MailStateCode = vm.loanBalance.StateCode;
    //    vm.loanBalance.MailZipCode = vm.loanBalance.ZipCode;
    //    vm.loanBalance.MailingFirstName = vm.loanBalance.FirstName;
    //    vm.loanBalance.MailingLastName = vm.loanBalance.LastName;
    //    vm.loanBalance.MailingMiddleName = vm.loanBalance.MiddleName;
    //}

    //vm.signatureUpload = {
    //    localization: {
    //        select: "Signature Image"
    //    }
    //}

    //vm.onSelect = function (e) {
    //    var message = $.map(e.files, function (file) { return file.name; }).join(", ");
    //    console.log("event :: select (" + message + ")");
    //}

    //vm.notificiationToastOptions = {
    //    templates: [{
    //        type: "ngTemplate",
    //        template: $("#notificationTemplate").html()
    //    }]
    //};

    //function getReferenceLists() {
    //    dal.refapi.query({ id: 'States' }, function (data) {
    //        if (typeof data === 'object') {
    //            vm.states = data;
    //        }
    //    });

    //    dal.refapi.query({ id: 'MaritalStatusActive' }, function (data) {
    //        if (typeof data === 'object') {
    //            vm.maritalStatus = data;
    //        }
    //    });

    //    dal.refapi.query({ id: 'ResidencyStatusActive' }, function (data) {
    //        if (typeof data === 'object') {
    //            vm.residencyStatus = data;
    //        }
    //    });

    //}

    //var gridElement = $("#grid");

    //function resizeGrid() {
    //    vm.balanceGrid.data("kendoGrid").resize();
    //}

    //$(window).resize(function () {
    //    resizeGrid();
    //});


    ////INIT
    init();

    function init() {
        //getReferenceLists();
    }




    //vm.newContact = {
    //    Address1: "",
    //    Address2: "",
    //    AuthorizedContactFlag: false,
    //    BirthDate: null,
    //    Borrower: "",
    //    CellPhoneNo: null,
    //    City: "",
    //    CompanyName: "",
    //    ContactSignatureImage: null,
    //    ContactSkey: 0,
    //    ContactTypeDescription: "",
    //    ContactTypeSkey: 0,
    //    CreatedBy: "",
    //    CreatedDate: "",
    //    DeathDate: null,
    //    DivorcedFlag: false,
    //    Email: null,
    //    EmailPreferredFlag: false,
    //    EmergencyContactFlag: false,
    //    EnbsIndicator: false,
    //    FaxPhoneNo: null,
    //    FirstName: "",
    //    FormatedCityStateZip: "",
    //    FormatedMailCityStateZip: "",
    //    FormatedMailName: "",
    //    FormatedMailZipCode: "",
    //    FormatedName: "",
    //    FormatedZipCode: "",
    //    FormattedSsn: null,
    //    Gender: null,
    //    GenderDescription: "",
    //    HomePhoneNo: null,
    //    LanguagePreferenceDescription: "",
    //    LanguagePreferenceSkey: 10,
    //    LastName: "",
    //    LegalOwnerFlag: false,
    //    LoanSkey: vm.loanBalance.LoanSkey,
    //    MailAddress1: "",
    //    MailAddress2: "",
    //    MailCity: "",
    //    MailCompanyName: null,
    //    MailStateCode: "",
    //    MailZipCode: null,
    //    MailingFirstName: "",
    //    MailingLastName: "",
    //    MailingMiddleName: "",
    //    MaritalStatusDescription: "",
    //    MaritalStatusSkey: 0,
    //    MiddleName: "",
    //    ModifiedBy: null,
    //    ModifiedDate: null,
    //    MortgageeOptionalElection: null,
    //    OtherContactTypeDescription: null,
    //    ParentContactSkey: null,
    //    ResidencyStatusDescription: "",
    //    ResidencyStatusSkey: 0,
    //    RightToOccupyFlag: false,
    //    SSN: null,
    //    SignatureImageTypeSkey: 0,
    //    StateCode: "",
    //    StatusSkey: 0,
    //    UseCompanyFieldFlag: true,
    //    UserSkey: null,
    //    WorkPhoneNo: null,
    //    ZipCode: "",

    //}
});