(function () {
    'use strict';

    angular
        .module('app')
        .controller('MainController', MainController);

    MainController.$inject = ['$http', '$http'];

    function MainController($scope, $http) {
        var vm = this;
    }
})();