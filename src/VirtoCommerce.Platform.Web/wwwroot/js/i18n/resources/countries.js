angular.module('platformWebApp')
    .factory('platformWebApp.common.countries', ['$translate', '$resource', function ($translate, $resource) {
        return {
            get: function (id) {
                return _.findWhere(this.query(), { id: this.normalize(id) });
            },
            contains: function (id) {
                return _.map(this.query(), function (entry) { return entry.id }).includes(this.normalize(id));
            },
            normalize: function (id) {
                var result = undefined;
                if (!!id) {
                    result = id.toUpperCase();
                }
                return result;
            },
            query: function () {
                return $resource('api/platform/common/countries').query((data) => {
                    for (int i = 0; i < data.lenght;i++) {
                        var translateKey = 'platform.countries.' + data[i].id;
                        var translated = $translate.instant(translateKey);
                        data[i].displayName = translated === translateKey ? data[i].name : translated;
                    }
                });
            },
            queryRegions: (countryCode) => {
                return $resource('api/platform/common/countries/:countryCode/regions', { countryCode: countryCode }).query((data) => {
                    for (var x of data) {
                        var translateKey = 'platform.' + countryCode + '.' + x.id;
                        var translated = $translate.instant(translateKey);
                        x.displayName = translated === translateKey ? x.name : translated;
                    }
                });
            }
        };
    }]);
