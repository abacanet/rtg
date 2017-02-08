angular.module('reverseQuestApp.Formatters', []).
 filter('dateFormatter', function () {               // filter is a factory function
     return function (value) {
         if (!angular.isUndefined(value) || value != '') {
             var pattern = /Date\(([^)]+)\)/;
             var results = pattern.exec(value);
             var returnValue;
             if (results != null) {
                 var dt = new Date(parseFloat(results[1]));
                 returnValue = (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
             }
             return returnValue;
         }
     }

 });