angular.module('platformWebApp')
    .factory('platformWebApp.authDataStorage', ['localStorageService', function(localStorageService) {
        return {
            storeAuthData: function (dataObject) {
                localStorageService.set('authenticationData', dataObject);
            },
            getStoredData: function () {
                return localStorageService.get('authenticationData');
            },
            clearStoredData: function () {
                localStorageService.remove('authenticationData');
            }
        };
    }]);
