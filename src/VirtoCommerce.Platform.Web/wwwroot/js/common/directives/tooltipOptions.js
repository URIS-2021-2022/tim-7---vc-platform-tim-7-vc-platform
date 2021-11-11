angular.module('platformWebApp')
.directive('vaTooltipOptions', [function () {
    return {
        restrict: 'A',
        scope: false,
        compile: function () {
            return function (scope, element, attrs) {
                var options = ["tooltipPlacement", "tooltipAnimation", "tooltipPopupDelay", "tooltipTrigger", "tooltipEnable", "tooltipAppendToBody", "tooltipClass"];
                var applyOption = function(option) {
                    if (attrs[option]) {
                        scope[option] = attrs[option];
                        attrs.$observe(option, function() {
                            scope[option] = attrs[option];
                        });
                    }
                };
                for (let value of options) {
                    applyOption(options[i]);
                }
            };
        }
    };
}]);
