angular.module('platformWebApp')
    .factory('platformWebApp.loginOfBehalfUrlResolver', [() => {
        var _resolver;

        return {
            // register the method to resolve the URL
            register: (resolver) => {
                _resolver = resolver;
            },
            resolve: (user) => {
                if (angular.isFunction(_resolver)) {
                    return _resolver(user);
                }
            }
        };
       
    }]);
