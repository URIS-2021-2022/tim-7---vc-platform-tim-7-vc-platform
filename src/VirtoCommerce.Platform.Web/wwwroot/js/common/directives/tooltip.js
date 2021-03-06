angular.module('platformWebApp')
.directive('vaTooltip', [function ()
{
    return {
        restrict: 'A',
        priority: 10000,
        compile: function (tElem, tAttrs)
        {
            var attributes = ["tooltip-placement", "tooltip-animation", "tooltip-popup-delay", "tooltip-trigger", "tooltip-enable", "tooltip-append-to-body", "tooltip-class"];
            for (let value of attributes) {
                var value = attributes[i];
                if (!tElem.attr[value]) {
                    tElem.attr(value, '{{' + tAttrs.$normalize(value) + '}}');
                }
            
        }
    };
}]);
