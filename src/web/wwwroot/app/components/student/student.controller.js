(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$http', '$http'];

    function StudentController($scope, $http) {
        var vm = this;
        vm.students = [];

        // Creating 
        vm.createStudentInput = {};
        vm.createStudent = function () {
            $http.post(site.api('students'), JSON.stringify(vm.createStudentInput))
                .then(function (response) {
                    // Re-load data
                    vm.students.push(response.data);
                    // Close dialog
                    $('#formCreateStudent').modal('toggle');
                });
        }
        
        // Load all 
        $http.get(site.api('students'))
            .then(function (response) {
                vm.students = response.data;
            });
    }
})();