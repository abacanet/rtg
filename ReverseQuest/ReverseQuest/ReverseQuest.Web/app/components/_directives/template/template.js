(function () {
    'use strict';

    angular
        .module('reverseQuestApp')
        .directive('templateDirective', templateDirective);

    templateDirective.$inject = ['dal'];
    function templateDirective(dal) {
        return {
            restrict: 'A',
            scope: {
                model: '='
            },
            templateUrl: '/app/components/directives/template/template.html',
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