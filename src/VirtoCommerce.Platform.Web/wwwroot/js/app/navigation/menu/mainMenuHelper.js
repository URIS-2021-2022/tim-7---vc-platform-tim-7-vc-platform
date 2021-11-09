function handleKeyUpEvent(scope, event) {
    if (scope.showSubMenu && event.keyCode === 27) {
        scope.$apply(function () {
            scope.showSubMenu = false;
        });
    }
}

function handleClickEvent(scope) {
    var dropdownElement = $document.find('.nav-bar .dropdown');
    var hadDropdownElement = $document.find('.__has-dropdown');
    if (scope.showSubMenu && !(dropdownElement.is(event.target) || dropdownElement.has(event.target).length > 0 ||
        hadDropdownElement.is(event.target) || hadDropdownElement.has(event.target).length > 0)) {
        scope.$apply(function () {
            scope.showSubMenu = false;
        });
    }
}
