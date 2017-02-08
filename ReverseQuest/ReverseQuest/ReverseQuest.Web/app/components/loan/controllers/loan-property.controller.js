angular.module('reverseQuestApp.loan').controller('LoanPropertyCtrl', function ($scope, dal) {

    var vm = this;
    vm.clientId = 20;
    vm.LoanSkey = 562441;

    var data = new kendo.data.DataSource({
        transport: {
            read: RQ_WEBAPIURL + "LoanDetails/" + vm.LoanSkey + "/Property"
            //RQ_APIURL + "/LoanProperty/Details?sKey=" + vm.LoanSkey
        }, schema: {
            model: {
                fields: {
                    LoanSkey: { type: "number" },
                    PropertyTypeDescription: { type: "string" },
                    PropertyAddress1: { type: "string" },
                    LegalDescription: { type: "string" },
                    PropertyAddress2: { type: "string" },
                    PropertyCity: { type: "string" },
                    PropertyStateCode: { type: "string" },
                    PropertyZipCode: { type: "string" },
                    CountyClerkName: { type: "string" },
                    NumberOfUnits: { type: "number" },
                    FloodZoneDescription: { type: "string" },
                    FloodZoneShortDescription: { type: "string" },
                    RequiresFloodInsuranceFlag: { type: "boolean" },
                    FloodCertificateNumber: { type: "number" },
                    FloodInsuranceCompanyName: { type: "string" },
                    LifeOfLoanPolicyFlag: { type: "boolean" },
                    OwnerOccupiedFlag: { type: "boolean" },
                    OccupancyDate: { type: "date" },
                    VacancyDate: { type: "date" },
                    Address1: { type: "string" },
                    Address2: { type: "string" },
                    City: { type: "string" },
                    StateCode: { type: "string" },
                    ZipCode: { type: "string" },
                    CountyClerkSkey: { type: "number" },
                    FloodZoneSkey: { type: "number" },
                    FloodInsuranceCompanySkey: { type: "number" },
                    PropertyTypeSkey: { type: "number" },
                    CreatedDate: { type: "date" },
                    CreatedBy: { type: "string" },
                    ModifiedDate: { type: "date" },
                    ModifiedBy: { type: "string" }
                }
            }
        },
        change: function () {
            vm.loanProperty = data.data()[0];
        }
    });



    function getReferenceLists() {
        dal.refapi.query({ id: 'PropertyTypeCategoryActive' }, function (data) {
            if (typeof data === 'object') {
                vm.propertyType = data;
            }
        });
    }

    vm.dateOptions = {
        formatYear: 'yy',
        maxDate: new Date(2020, 5, 22),
        minDate: new Date(1920, 5, 22),
        startingDay: 1
    };


    vm.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
    vm.format = vm.formats[0];
    vm.altInputFormats = ['M!/d!/yyyy'];

    vm.openOccupancyDate = function () {
        vm.popupOccupancyDate.opened = true;
    };

    vm.popupOccupancyDate = {
        opened: false
    };

    vm.openVacancyDate = function () {
        vm.popupVacancyDate.opened = true;
    };

    vm.popupVacancyDate = {
        opened: false
    };


    var propertyPicturesds = [{
        skey: 1,
        picture_description: "House",
        status: 'Active',
        created_by: 'fakeuser',
        created_date: "10/22/2016"
    }];


    vm.propertyValueGridGridOptions = {
        dataSource: {
            transport: {
                read:
                    {
                        url: RQ_WEBAPIURL + "LoanDetails/" + vm.LoanSkey + "/Property/Values",
                        //RQ_APIURL + "/LoanProperty/Values?sKey=" + vm.LoanSkey,
                        //type: 'GET',
                        //contentType: "application/json; charset=utf-8",
                        //dataType: 'json'
                    }
            },
            schema: {
                model: {
                    id: "PropertyValueSkey",
                    fields: {
                        PropertyValueDate: { required: true }, //editable: false, nullable: true
                        //ProductName: { validation: { required: true } },
                        //UnitPrice: { type: "number", validation: { required: true, min: 1 } },
                        //Discontinued: { type: "boolean" },
                        //UnitsInStock: { type: "number", validation: { min: 0, required: true } }
                    }
                }
            }
        },
        toolbar: ["create"],
        editable: {
            mode: "popup",
            template: kendo.template($("#valuesPopupTemplate").html())
        },
        sortable: true,
        pageable: false,
        columns: [{
            field: "PropertyValueDate",
            title: "Value Date",
            width: "50px",
            template: "#= kendo.toString(kendo.parseDate(PropertyValueDate, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"
        }, {
            field: "PropertyValueTypeDescription",
            title: "Type",
            width: "120px"
        }, {
            field: "PropertyValueSubTypeDescription",
            title: "Sub Type",
            width: "120px"
        }, {
            field: "EstimatedPropertyValue",
            title: "Est. Value",
            width: "120px",
            format: "{0:c}"
        }, {
            field: "RepairedPropertyValue",
            title: "Rep. Value",
            width: "120px",
            format: "{0:c}"
        },
        {
            field: "StatusDescription",
            title: "Status",
            width: "120px"
        }, {
            field: "ValuatorName",
            title: "Valuator",
            width: "120px"
        }]
    };


    vm.propertyPicturesGridOptions = {
        dataSource: { data: propertyPicturesds },
        toolbar: ["create"],
        sortable: true,
        pageable: false,
        columns: [{
            field: "skey",
            title: "Skey",
            width: "50px"
        }, {
            field: "picture_description",
            title: "Description",
            width: "120px"
        }, {
            field: "status",
            title: "Status",
            width: "120px"
        }, {
            field: "created_by",
            title: "Created By",
            width: "120px"
        }, {
            field: "created_date",
            title: "Created Date",
            width: "120px"
        }],
        editable: {
            mode: "popup",
            template: kendo.template($("#picturesTemplate").html())
        }
    };

    vm.saveProperty = function () {
    }

    //vm.savePropertyValue = function () {
    //}

    vm.winPropertyValueOptions = {
        position: {
            top: 200
        }
    }

    //OPTIONS
    vm.propertyPictureFileUploadOptions = {
        multiple: true,
        async: {
            saveUrl: RQ_WEBAPIURL + "/LoanProperty/Upload",
            autoUpload: false,
            batch: true
        },
        // dropZone: ".dropZoneElement",
        validation: {
            //allowedExtensions: [".xml", ".txt"]
        },
        upload: function (e) {
            //e.data = vm.loanBoarding;
        },
        localization: {
            uploadSelectedFiles: "Save Data"
        },
        success: function (e) {
            //vm.uploadResponse = "Response from the server: " + e.response.status;
            $scope.$apply();
        },
        error: function (e) {
            //vm.uploadResponse = "Errors detected " + e.reponse;
            $scope.$apply();
        }
    };


    //INIT
    init();

    function init() {
        getReferenceLists();
        data.read();
    }


});