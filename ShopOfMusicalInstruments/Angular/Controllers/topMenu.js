(function() {
    "use strict";

    // sideMenu directive
    var topmenuDirective = function() {
        return {
            scope: false,
            restrict: "EA",
            replace: false,
            templateUrl: function() {
                return "Angular/Views/topMenu.html";
            },
            controller: [function() {
               
            }]
        };
    };

    // register your directive into a dependent module.
    angular
        .module("Web.Directives")
        .directive("topMenu", [topmenuDirective]);
})();