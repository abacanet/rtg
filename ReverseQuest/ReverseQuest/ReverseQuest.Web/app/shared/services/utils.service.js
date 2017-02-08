(function () {
    'use strict';

    angular.module('reverseQuestApp.shared').factory('utils', utils);
    utils.$inject = [];

    function utils() {
        return {
            errorNotification: function (e) {
                if (e) {
                    notifications.showError({
                        message: 'Error on site, please refresh page and try again',
                        hide: false
                    });
                }
            },

            removeEmptyProp: function (obj) {
                for (var x in obj) {
                    if (obj.hasOwnProperty(x)) {
                        if (obj[x] === '') {
                            delete obj[x];
                        }
                    }
                }

                return obj;
            },

            businessDaysOnly: function (date) {
                var day = date.getDay();
                return day > 0 && day < 6;
            },

            weekendsOnly: function (date) {
                var day = date.getDay();
                return day === 0 || day === 6;
            },

            maxDate: function (date, restriction) {
                return new Date(
                    date.getFullYear(),
                    date.getMonth() + restriction,
                    date.getDate());
            },

            minDate: function (date, restriction) {
                return new Date(
                    date.getFullYear(),
                    date.getMonth() - restriction,
                    date.getDate());
            },

            cleanDate: function (date) {
                if (!date || isNaN(Date.parse(date))) {
                    date = new Date();
                } else {
                    date = new Date(date);
                }
                return date;
            },

            sortByProperty: function (property) {
                'use strict';
                return function (a, b) {
                    var sortStatus = 0;
                    if (a[property] < b[property]) {
                        sortStatus = -1;
                    } else if (a[property] > b[property]) {
                        sortStatus = 1;
                    }

                    return sortStatus;
                };
            }
        };
    }

}());

