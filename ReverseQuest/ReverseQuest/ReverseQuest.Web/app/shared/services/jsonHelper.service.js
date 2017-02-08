(function () {
    'use strict';

    //MODULE COMPONENTS
    angular
        .module('reverseQuestApp.shared')
        .factory('jsonHelper', ['$http', '$q', jsonHelper]);

    //COMPONENT DEFINITION
    function jsonHelper($http, $q) {

        //////////////////// Helpers /////////////////////////////
        function getJsonData(url, cache, resType, requestCanceller) {

            if (typeof cache == 'undefined'){
                cache = true;
            }
                
            if (typeof resType == 'undefined'){
                resType = '';
            }

            if (typeof requestCanceller == 'undefined'){
                requestCanceller = $q.defer();
            }
                

            return $http({
                method: 'GET',
                cache: cache,
                url: url,
                timeout: requestCanceller.promise,
                responseType: resType,
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                }
            })
            .catch(function (e) {
                //throw e;
            })
            .then(function (data) {
                return data;
            });
        }

        function postJsonData(url, data, requestCanceller) {
            var antiForgeryToken = $("input:hidden#forgeryToken").val();

            if (typeof requestCanceller == 'undefined'){
                requestCanceller = $q.defer();
            }

            return $http({
                method: 'POST',
                url: url,
                data: data,
                timeout: requestCanceller.promise,
                headers: {
                    'X-Requested-With': 'XMLHttpRequest',
                    "VerificationToken": antiForgeryToken,
                    "Content-Type": "application/json;charset=utf-8"
                }
            })
            .catch(function (e) {
                console.log('ERROR', e);
                console.log('ERROR requestUrl:', url);
                console.log('ERROR requestData:', data);
                throw e;
            })
            .then(function (data) {
                return data;
            });
        }


        return {
            getJsonData: getJsonData,
            postJsonData: postJsonData
        };

    }
})();