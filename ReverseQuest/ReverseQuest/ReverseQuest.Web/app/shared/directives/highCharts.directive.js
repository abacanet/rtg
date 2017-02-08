(function () {
    'use strict';

    //Regular Chart
    angular.module('reverseQuestApp.shared').directive('hcChart', hcChart);
    function hcChart() {
        return {
            restrict: 'E',
            scope: {
                options: '='
            },
            template: '<div></div>'

            , link: function (scope, element, attr, ctrl) {
                Highcharts.chart(element[0], scope.options);
            }
        }
    }

    //Pie Chart
    angular.module('reverseQuestApp.shared').directive('hcPieChart', hcPieChart);
    function hcPieChart() {
        return {
            restrict: 'E',
            scope: {
                title: '@',
                data: '='
            },
            template: '<div></div>'

            , link: function (scope, element) {
                Highcharts.chart(element[0], {
                    chart: {
                        type: 'pie'
                    },
                    title: {
                        text: scope.title
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                format: '<b>{point.name}</b>: {point.percentage:.1f} %'
                            }
                        }
                    },
                    series: [{
                        data: scope.data
                    }]
                });
            }

            }
        }
})();