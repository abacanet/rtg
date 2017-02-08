(function () {
    'use strict';

    //DECLARING PRINCIPAL MODULE 
    angular.module('reverseQuestApp.shared', ['kendo.directives', 'ngResource']).constant('appSetting', {
        serverPath: 'http://rtg-web-1.southcentralus.cloudapp.azure.com:91/'
    });

})();