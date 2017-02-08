angular.module('reverseQuestApp.audit.information', [])
    .directive('auditInformation', function(){
      return {
          restrict: 'AE',
          scope: {
              info: '=',
              
          },
          templateUrl: '/app/shared/views/partials/widgets/audit-information.html'
      }
    });