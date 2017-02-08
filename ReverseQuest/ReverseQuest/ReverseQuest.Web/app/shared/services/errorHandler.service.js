(function () {
    'use strict';

    angular.module('reverseQuestApp.shared').factory('errorHandler', errorHandler);
    errorHandler.$inject = ['notifications'];

    function errorHandler(notifications) {
        return {
            errorNotification: function (e) {
                if (e) {
                    notifications.showError({
                        message: 'Error on site, please refresh page and try again',
                        hide: false
                    });
                }
            }
        };
    }

}());

