(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('initCredLisaDirective', initCredLisaDirective);

    initCredLisaDirective.$inject = ['dal'];
    function initCredLisaDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/loan/loanBalances/initCredLisa/initCredLisa.html',
            controllerAs: 'vm',
            controller: function ($scope) {
                var vm = this;

                //PARAMS

                //FUNCTIONS


                //INIT
                init();

                function init() {

                }

            }

            , link: function (scope, element, attr, ctrl) {

            }
        }
    }
})();