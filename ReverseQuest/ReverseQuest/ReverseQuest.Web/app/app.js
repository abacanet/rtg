(function () {
    'use strict';

    var dependencies = [
        'kendo.directives',
        'angularCSS',
        'ngNotificationsBar',
        'ngSanitize',
        'ngMessages',
        'ngNotificationsBar',
        'timer',
        'ui.utils.masks',
        'ui.router',
        'ui.bootstrap',
        'ngResource',

        //App
        'reverseQuestApp.shared',
        'reverseQuestApp.Formatters',
        'reverseQuestApp.accounting',
        'reverseQuestApp.bankruptcy',
        'reverseQuestApp.claims',
        'reverseQuestApp.compliance',
        'reverseQuestApp.dashboard',
        'reverseQuestApp.default',
        'reverseQuestApp.foreclosure',
        'reverseQuestApp.hmbs',
        'reverseQuestApp.import-export',
        'reverseQuestApp.loan',
        'reverseQuestApp.reo',
        'reverseQuestApp.reports',
        'reverseQuestApp.servicing',
        'reverseQuestApp.audit.information'

    ];

    angular.module('reverseQuestApp', dependencies);

}());



