(function () {
    'use strict';

    //MODULE COMPONENTS
    angular
        .module('reverseQuestApp.shared')
        .factory('accountService', accountService);

    accountService.$inject = ['$http', 'dal', 'notifications', '$q', '$rootScope', '$uibModal', '$sce', 'session', '$stateParams'];
    function accountService($http, dal, notifications, $q, $rootScope, $uibModal, $sce, session, $stateParams) {
        var service = {
            //PARAMS
            isAuthenticated: false,
            modalOpened: false,
            loginModel: { UserName: '', Password: '', RememberMe: true },
            forgotModel: { email: '', oldPassword: '', newPassword: '' },
            registerModel: {
                FirstName: '',
                //MiddleName: '',
                LastName: '',
                UserName: '',
                Email: '',
                Phone: '',
                ContactTypeID: '',
                Affiliation: {},
                SelectedNatDist: [],
                SelectedPublisher: []
            },

            //FUNCTIONS
            init: init,
            openLoginForm: openLoginForm
        };

        init();

        function init() {
        }

        function openLoginForm() {
            var modalInstance = $uibModal.open({
                //animation: false,
                templateUrl: '/app/shared/views/account/account.html',
                size: 'md',
                keyboard: false,
                backdrop: 'static',
                //windowClass: 'modal fade in',
                controllerAs: 'vm',
                controller: function ($scope, dal, $rootScope, session, $window) {
                    var vm = this;
                    vm.formShown = '';

                    //FUNCTIONS
                    vm.cancel = cancel;
                    vm.login = login;
                    vm.register = register;
                    vm.showForm = showForm;
                    vm.test = test;

                    init();

                    function init() {
                        showForm('Login');
                    }
                    function cancel() {
                        vm.busy = false;
                        service.loginModel = { UserName: '', Password: '', RememberMe: true };
                        service.registerModel = {};
                        service.modalOpened = false;
                        modalInstance.dismiss('cancel');
                        //modalInstance.close();
                    }
                    function login(formValid) {
                        if (formValid) {
                            vm.busy = true;
                            vm.action = 'Authenticating User';
                            dal.login(vm.loginModel)
                                .then(function (result) {
                                    if (result.data.status) {
                                        notifications.closeAll();
                                        notifications.showSuccess({
                                            message: 'Credentials Accepted. Refreshing Page',
                                            hide: false
                                        });
                                        cancel();
                                        $window.location.href = '';
                                    }
                                    else {
                                        if (result.data.message === 'Request Access') {
                                            notifications.closeAll();
                                            notifications.showInfo({
                                                message: 'Site Admin: Additional Info Needed To Provide Access.',
                                                hide: false
                                            });
                                            showForm('Request Access');
                                        } else if (result.data.message === 'Invalid') {
                                            notifications.showWarning('Invalid Login Attempt: Incorrect Username and/or Password');
                                        } else {
                                            notifications.showWarning(result.data.message);
                                        }
                                    }

                                    vm.busy = false;
                                    vm.action = null;

                                })
                                .catch(function (e) {
                                    if (e) {
                                        vm.busy = false;
                                        console.log(e);
                                        cancel();
                                        notifications.showError({
                                            message: 'Error on site, please refresh page and try again',
                                            hide: false
                                        });
                                    }
                                });
                        } else {
                            //ITERATE THROUGH ALL THE FORM FIELDS AND SET THEM TO DIRTY
                            angular.forEach($scope.loginForm, function (value, key) {
                                if (typeof value === 'object' && value.hasOwnProperty('$modelValue') && value.$modelValue === null) {
                                    //$('#' + key).addClass('ng-dirty');
                                    //value.$setViewValue(key.$setViewValue);
                                    value.$setDirty();
                                }
                            });
                        }
                    }
                    function register() {
                        vm.busy = true;
                        vm.action = 'Submitting Info to Site Admin';
                        vm.registerModel.UserName = angular.copy(vm.loginModel.UserName);

                        dal.register(vm.registerModel)
                            .then(function (result) {
                                if (result.data.success) {
                                    vm.busy = false;
                                    //cancel();
                                    notifications.closeAll();
                                    //notifications.showSuccess({
                                    //    message: 'Email sent to: <strong>' + vm.registerModel.Email +
                                    //             '</strong>, with instructions to confirm account.<br/>' +
                                    //             '<strong>Please remember to close or refresh this page after confirming account.</strong>',
                                    //    hide: false
                                    //});
                                    notifications.showSuccess({
                                        message: 'Info sent to Admin. We will contact you shortly with further instructions',
                                        hide: false
                                    });
                                    cancel();
                                    //showForm('Login');
                                    //login(true);
                                }
                                else {
                                    vm.busy = false;
                                    vm.action = null;
                                    notifications.showWarning(result.data.message);
                                }
                            }).catch(function (e) {
                                if (e) {
                                    vm.busy = false;
                                    console.log(e);
                                    cancel();
                                    notifications.showError({
                                        message: 'Error on site, please refresh page and try again',
                                        hide: false
                                    });
                                }
                            });
                    }
                    function showForm(whichForm) {
                        if (whichForm === 'Login') {
                            vm.loginModel = service.loginModel;
                        }

                        if (whichForm === 'Request Access') {
                            vm.registerModel = service.registerModel;

                            getAffiliations();
                            getContactTypes();
                        }

                        service.modalOpened = true;
                        vm.formShown = whichForm;
                    }
                    function test(form) {
                        console.log('listen', form);
                    }
                }
            });

            modalInstance.result.then(function () {

                if (service.postLoginFunction)
                    service.postLoginFunction();
            });
        }

        return service;
    }
})();