(function () {
    'use strict';

    //PASSWORD VALIDATION
    angular.module('reverseQuestApp.shared').directive('passwordValidation', passwordValidation);
    function passwordValidation() {
        return {
            require: "ngModel",
            link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.passwordValid = function (modelValue) {

                    var validatePassword = new RegExp('^(?=.*?[A-Z])(?=.*[a-z])(?=.*?[0-9])(?=.*[#?!@$%^&*()_.,+=-]).{7,20}$');

                    //REGEX GOES HERE
                    return validatePassword.test(modelValue);
                };
            }
        };
    }

    //EMAIL VALIDATION
    angular.module('reverseQuestApp.shared').directive('emailValidation', emailValidation);
    function emailValidation() {
        return {
            require: "ngModel",
            link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.emailValid = function (modelValue) {

                    var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    var validEmail = re.test(modelValue);

                    //REGEX GOES HERE
                    return validEmail;
                };
            }
        };
    }

})();
