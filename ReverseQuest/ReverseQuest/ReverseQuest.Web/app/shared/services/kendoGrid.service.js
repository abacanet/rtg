(function () {
    'use strict';

    angular.module('reverseQuestApp.shared').factory('kendoGrid', kendoGrid);
    kendoGrid.$inject = ['$window', '$filter', 'utils', 'errorHandler', 'dal'];

    function kendoGrid($window, $filter, utils, errorHandler, dal) {

        return {

            options: function (options) {
                var defaults = {
                    sortable: true,
                    selectable: true,
                    pageable: {
                        pageSize: 20,
                        pageSizes: [10, 25, 50, 100, 'All'],
                        buttonCount: 5,
                        message: {
                            empty: 'No Data',
                            allPages: 'All'
                        }
                    }
                };

                return angular.merge({}, defaults, options);
            },

            onChange: function (searchParams) {
                angular.element($window).on('change', function (e) {
                    dal.getSearchResults(utils.removeEmptyProp(searchParams)).then(function (result) {
                        var grid = $("#grid").data("kendoGrid");
                        if (result && result.data) {
                            grid.dataSource.read(result.data);
                        }
                    }).catch(errorHandler.errorNotification);
                });
            }


        };
    }

}());

