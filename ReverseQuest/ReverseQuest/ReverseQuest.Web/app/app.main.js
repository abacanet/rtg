(function(){
    'use strict';

    angular.module('reverseQuestApp').controller('MainController', MainController);
    MainController.$inject = ['$scope', '$q', 'dal', 'notifications', 'session', '$window'];

    function MainController($scope, $q, dal, notifications, session, $window) {
        var vm = this;
        vm.appName = 'ReverseQuest';
    }

}());

var RQ_APIURL = '';
var RQ_WEBAPIURL = 'http://localhost:13424/api/v1/';
var REF_APIURL = 'http://localhost:50221/'; 