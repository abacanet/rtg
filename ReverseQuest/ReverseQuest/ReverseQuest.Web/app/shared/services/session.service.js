(function () {
    'use strict';

    //SERVICE DECLARATION
    angular
        .module('reverseQuestApp.shared')
        .service('session', sessionFactory);

    //SERVICE DEFINITION & DEPENDENCIES
    sessionFactory.$inject = ['$http', '$rootScope', 'localStorage', '$uibModal', '$window'];
    function sessionFactory($http, $rootScope, localStorage, $uibModal, $window) {

        var session = {

            //CONFIGURE PARAMS
            user: null,
            sKey: null,
            isInitialized: false,
            stateHistory: [],

            //FUNCTIONS
            getSessionFromStorage: getSessionFromStorage,

            initSession: initSession,
            startListening: startListening,
            saveSessionToStorage: saveSessionToStorage,

            clearSessionAfterLogOff: clearSessionAfterLogOff
        };


        initSession();


        return session;

        ////////////////////////
        ////////////////////////
        ////////////////////////

        function clearSessionAfterLogOff() {
            session.user = null;
            localStorage.remove('session');
        }
        function getSessionFromStorage() {
            return localStorage.get('session');
        }
        function initSession() {

            
            //ONLY INITIALIZE SESSION WHEN NECESSARY
            //if (session.isInitialized === false) {

                //Pulls session from storage if it exists
                initSessionFromStorage();

                //Listens for session object changes - will update local storage automatically as session changes
                startListening();

                session.isInitialized = true;
            //}

        }
        function initSessionFromStorage() {
            
            var storedSession = getSessionFromStorage();
            if (storedSession !== null) {
                session.user = storedSession.user || '';
                session.sKey = storedSession.sKey || '';
            }
        }
        function saveSessionToStorage() {
            localStorage.set('session', session);
        }
        function startListening() {
            //SHOULD KEEP STORAGE IN SYNC WITH SESSION CHANGES
            $rootScope.$on('session_save', saveSessionToStorage);
        }

    }
})();
