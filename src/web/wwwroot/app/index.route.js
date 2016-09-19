(() => {
    'use strict';

    angular.module('app').config(routes);
    routes.$inject = ['$stateProvider', '$urlRouterProvider'];

    angular.module('app').run(startup);
    startup.$inject = ['$rootScope', '$templateCache'];

    function routes($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('main', {
                url: '/',
                templateUrl: 'app/main/main.html',
                //controller: 'Main1Controller',
                //controllerAs: 'vm'
            })
            .state('student', {
                url: '/student',
                templateUrl: 'app/components/student/student.html',
                controller: 'StudentController',
                controllerAs: 'vm'
            });
    }
    
    // This automatically clear the cache whenever the ng-view content changes.
    function startup($rootScope, $templateCache) {
        $rootScope.$on('$viewContentLoaded', function () {
            $templateCache.removeAll();
        });
    }

})();