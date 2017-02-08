
angular.module('reverseQuestApp.loan').controller('LoanContactsCtrl', function ($scope, $uibModal, $log, $document, loanContactsDal, dal) {
    var vm = this;
    vm.actionMessage = "";
    vm.loanContact = {};
    //vm.loanContact.clientId = 20;
    vm.loanContact.LoanSkey = 569701;
    vm.saveType = "";

    vm.contactsGridGridOptions = {
        dataSource: {
            transport: {
                read:
                    {
                        url: RQ_APIURL + '/LoanContact/GetLoanContacts?sKey=' + vm.loanContact.LoanSkey,
                        type: 'GET',
                        contentType: "application/json; charset=utf-8",
                        dataType: 'json'
                    },
                //parameterMap: function (options, operation) {
                //    return JSON.stringify(vm.model.searchParameters);
                //}
            }
        },
        change: function (e) {
            var selectedItem = vm.contactsGrid.dataItem(vm.contactsGrid.select());
            console.log(selectedItem);
            vm.loanContact = selectedItem;
            vm.saveType = "update";
            vm.actionMessage = "- Editing " + vm.loanContact.FormatedName;
            vm.buttonsVisible = true;
            $scope.$apply();
        },
        //toolbar: ["create"],
        selectable: true,
        sortable: true,
        pageable: false,
        columns: [{
            field: "ContactTypeDescription",
            title: "Type",
            width: "50px"
        }
        , {
            field: "FormatedName",
            title: "Contact Name",
            width: "120px"
        }
        ]
    };

    vm.addNewContact = function () {
        vm.actionMessage = "- Adding New Contact";
        vm.loanContact = vm.newContact;
        vm.buttonsVisible = true;
        vm.saveType = "create";
    }

    vm.saveContact = function () {
        var dataPromise;
        var message = "";
        if (vm.saveType === "update") {
            dataPromise = loanContactsDal.update(vm.loanContact);
        }
        else if (vm.saveType === "create") {
            dataPromise = loanContactsDal.create(JSON.stringify(vm.loanContact));
        }

        if (!angular.isUndefined(dataPromise)) {
            dataPromise.then(function (result) {
                if (result.statusText === 'OK') {
                    message = "Record Saved..."
                }
                else {
                    message = "Error: Record Not Saved..."
                    console.log(result);
                }

                vm.contactsGrid.dataSource.read();

                vm.notificiationToast.show({
                    kValue: message
                }, "ngTemplate");

                return result;
            });
        }
    }

    vm.copyContactAddresss = function () {
        vm.loanContact.MailAddress1 = vm.loanContact.Address1;
        vm.loanContact.MailAddress2 = vm.loanContact.Address2;
        vm.loanContact.MailCity = vm.loanContact.City;
        vm.loanContact.MailStateCode = vm.loanContact.StateCode;
        vm.loanContact.MailZipCode = vm.loanContact.ZipCode;
        vm.loanContact.MailingFirstName = vm.loanContact.FirstName;
        vm.loanContact.MailingLastName = vm.loanContact.LastName;
        vm.loanContact.MailingMiddleName = vm.loanContact.MiddleName;
    }

    vm.signatureUpload = {
        localization: {
            select: "Signature Image"
        }
    }

    vm.onSelect = function (e) {
        var message = $.map(e.files, function (file) { return file.name; }).join(", ");
        console.log("event :: select (" + message + ")");
    }

    vm.notificiationToastOptions = {
        templates: [{
            type: "ngTemplate",
            template: $("#notificationTemplate").html()
        }]
    };

    function getReferenceLists() {
        dal.refapi.query({ id: 'States' }, function (data) {
            if (typeof data === 'object') {
                vm.states = data;
            }
        });

        dal.refapi.query({ id: 'MaritalStatusActive' }, function (data) {
            if (typeof data === 'object') {
                vm.maritalStatus = data;
            }
        });

        dal.refapi.query({ id: 'ResidencyStatusActive' }, function (data) {
            if (typeof data === 'object') {
                vm.residencyStatus = data;
            }
        });
        
    }
    //INIT
    init();

    function init() {
        getReferenceLists();
    }


    vm.newContact = {
        Address1: "",
        Address2: "",
        AuthorizedContactFlag: false,
        BirthDate: null,
        Borrower: "",
        CellPhoneNo: null,
        City: "",
        CompanyName: "",
        ContactSignatureImage: null,
        ContactSkey: 0,
        ContactTypeDescription: "",
        ContactTypeSkey: 0,
        CreatedBy: "",
        CreatedDate: "",
        DeathDate: null,
        DivorcedFlag: false,
        Email: null,
        EmailPreferredFlag: false,
        EmergencyContactFlag: false,
        EnbsIndicator: false,
        FaxPhoneNo: null,
        FirstName: "",
        FormatedCityStateZip: "",
        FormatedMailCityStateZip: "",
        FormatedMailName: "",
        FormatedMailZipCode: "",
        FormatedName: "",
        FormatedZipCode: "",
        FormattedSsn: null,
        Gender: null,
        GenderDescription: "",
        HomePhoneNo: null,
        LanguagePreferenceDescription: "",
        LanguagePreferenceSkey: 10,
        LastName: "",
        LegalOwnerFlag: false,
        LoanSkey: vm.loanContact.LoanSkey,
        MailAddress1: "",
        MailAddress2: "",
        MailCity: "",
        MailCompanyName: null,
        MailStateCode: "",
        MailZipCode: null,
        MailingFirstName: "",
        MailingLastName: "",
        MailingMiddleName: "",
        MaritalStatusDescription: "",
        MaritalStatusSkey: 0,
        MiddleName: "",
        ModifiedBy: null,
        ModifiedDate: null,
        MortgageeOptionalElection: null,
        OtherContactTypeDescription: null,
        ParentContactSkey: null,
        ResidencyStatusDescription: "",
        ResidencyStatusSkey: 0,
        RightToOccupyFlag: false,
        SSN: null,
        SignatureImageTypeSkey: 0,
        StateCode: "",
        StatusSkey: 0,
        UseCompanyFieldFlag: true,
        UserSkey: null,
        WorkPhoneNo: null,
        ZipCode: "",

    }
});