(function () {
    'use strict';
    angular
        .module('app', [
            'ui.router'
        ]);

    angular.module('app').run(startup);
    startup.$inject = ['$rootScope', '$templateCache'];

    // This automatically clear the cache whenever the ng-view content changes.
    function startup($rootScope, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function () {
            $templateCache.removeAll();
        });
    }
})();