(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$http', '$http'];

    function StudentController($scope, $http) {
        var vm = this;

        vm.students = [];

        $http.get("http://localhost:18081/api/students")
            .then(function (response) {
                vm.students = response.data;
            });
    }
})();