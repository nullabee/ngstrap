(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$http', '$http'];

    function StudentController($scope, $http) {
        var vm = this;
        vm.students = [];


        vm.createStudentInput = {};
        vm.createStudent = function () {
            console.log("hello");
            console.log(JSON.stringify(vm.createStudentInput));

            $http.post("http://localhost:18081/api/students", JSON.stringify(vm.createStudentInput))
                .then(function (response) {

                    // Re-load data
                    vm.students.push(response.data);

                    // Close dialog
                    $('#formCreateStudent').modal('toggle');
                });
        }

        $http.get("http://localhost:18081/api/students")
            .then(function (response) {
                vm.students = response.data;
            });
    }
})();