/**
 * Heavily adapted from the `type="number"` directive in Angular's
 * /src/ng/directive/input.js
 */

'use strict';

angular.module('platformWebApp')
// TODO: Replace with tested localized version (see below)
.directive('money', ['$timeout', function ($timeout) {
    'use strict';

    var NUMBER_REGEXP = /^\s*([-+])?(\d+|(\d*(\.\d*)))\s*$/;

    function link(scope, el, attrs, ngModelCtrl) {
        var min = parseFloat(attrs.min || 0);
        var precision = parseFloat(attrs.precision || 2);
        var lastValidValue;

        function round(num) {
            var d = Math.pow(10, precision);
            return Math.round(num * d) / d;
        }

        function formatPrecision(value) {
            return parseFloat(value).toFixed(precision);
        }

        function formatViewValue(value) {
            return ngModelCtrl.$isEmpty(value) ? '' : '' + value;
        }


        ngModelCtrl.$parsers.push(function (value) {
            return push();
        });
        ngModelCtrl.$formatters.push(formatViewValue);

        var minValidator = function (value) {
            if (!ngModelCtrl.$isEmpty(value) && value < min) {
                ngModelCtrl.$setValidity('min', false);
                return undefined;
            } else {
                ngModelCtrl.$setValidity('min', true);
                return value;
            }
        };
        ngModelCtrl.$parsers.push(minValidator);
        ngModelCtrl.$formatters.push(minValidator);

        if (attrs.max) {
            maxAttributes();
        }

        // Round off
        if (precision > -1) {
            ngModelCtrl.$parsers.push(function (value) {
                return value ? round(value) : value;
            });
            ngModelCtrl.$formatters.push(function (value) {
                return value ? formatPrecision(value) : value;
            });
        }

        el.bind('blur', function () {
            $timeout(function () {
                var value = ngModelCtrl.$modelValue;
                if (value) {
                    ngModelCtrl.$viewValue = formatPrecision(value);
                    ngModelCtrl.$render();
                }
            });
        });
    }

    function maxAttributes() {
        var max = parseFloat(attrs.max);
        var maxValidator = function (value) {
            if (!ngModelCtrl.$isEmpty(value) && value > max) {
                ngModelCtrl.$setValidity('max', false);
                return undefined;
            } else {
                ngModelCtrl.$setValidity('max', true);
                return value;
            }
        };

        ngModelCtrl.$parsers.push(maxValidator);
        ngModelCtrl.$formatters.push(maxValidator);
    }

    function push() {
        if (angular.isUndefined(value)) {
            value = '';
        }

        // Handle leading decimal point, like ".5"
        if (value.indexOf('.') === 0) {
            value = '0' + value;
        }

        // Allow "-" inputs only when min < 0
        if (value.indexOf('-') === 0) {
            if (min >= 0) {
                value = null;
                ngModelCtrl.$setViewValue('');
                ngModelCtrl.$render();
            } else if (value === '-') {
                value = '';
            }
        }

        var empty = ngModelCtrl.$isEmpty(value);
        if (empty || NUMBER_REGEXP.test(value)) {
            if (value === '') {
                lastValidValue = null;
            } else {
                lastValidValue = empty ? value : parseFloat(value)
            }
        } else {
            // Render the last valid input in the field
            ngModelCtrl.$setViewValue(formatViewValue(lastValidValue));
            ngModelCtrl.$render();
        }

        ngModelCtrl.$setValidity('number', true);
        return lastValidValue;
    }

    return {
        restrict: 'A',
        require: 'ngModel',
        link: link
    };
}]);

