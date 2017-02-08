(function () {
    'use strict';

    angular.module('reverseQuestApp.loan').factory('loanSearch', loanSearch);
    loanSearch.$inject = ['dal'];

    function loanSearch(dal) {
        return {
            getInvestors: function (clientId) {
                return dal.getInvestors(clientId);
            },
            getServicers: function (clientId) {
                return dal.getServicers(clientId);
            },
            getInvestorPools: function (clientId) {
                return dal.getInvestorPools(clientId);
            },
            getInvestors: function (clientId) {
                return dal.getInvestors(clientId);
            },
            getSearchResults: function (params) {
                return dal.getSearchResults(params);
            },
            removeBlankProp: function (obj) {
                for (var x in obj) {
                    if (obj.hasOwnProperty(x)) {
                        if (obj[x] === '') {
                            delete obj[x];
                        }
                    }
                }

                return obj;
            }
        };
    }

}());

