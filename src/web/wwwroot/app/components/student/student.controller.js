(function () {
    'use strict';

    angular
        .module('app')
        .controller('StudentController', StudentController);

    StudentController.$inject = ['$http', '$http'];

    function StudentController($scope, $http) {
        var vm = this;

        vm.students = {
            data: [],
            inputs: {},
            create: function () {
                $http.post(site.api('students'), JSON.stringify(vm.students.inputs))
                    .then(function (response) {
                        // Re-load data
                        vm.students.data.push(response.data);
                        // Close dialog
                        $('#formCreate').modal('toggle');
                    });
            }
        }

        // Load all 
        $http.get(site.api('students'))
            .then(function (response) {
                vm.students.data = response.data;
            });
    }
})();