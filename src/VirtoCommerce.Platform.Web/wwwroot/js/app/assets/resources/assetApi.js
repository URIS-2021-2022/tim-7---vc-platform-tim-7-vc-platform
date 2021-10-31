angular.module('platformWebApp')
.factory('platformWebApp.assets.api', ['$resource', function ($resource) {
    return $resource('api/platform/assets', {}, {
        search: { method: 'GET', url: 'api/platform/assets', isArray: false },
        createFolder: { method: 'POST', url: 'api/platform/assets/folder' },
        move: { method: 'POST', url: 'api/platform/assets/move' },
        uploadFromUrl: { method: 'POST', params: { url: '@url', folderUrl: '@folderUrl', name: '@name' }, isArray: true }
    });
}]);

