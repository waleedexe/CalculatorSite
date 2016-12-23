(function () {
    'user strict';
    angular.module('app')
        .controller('CalcController', CalcController);

    function CalcController($http, $scope) {
        vm = this;
        vm.calcModel = {
            FirstNumber: '',
            SecondNumber: '',
            Result: '',
            Errors: []
        };
        vm.logs = [];

        vm.calculate = function () {
            // clear errors before posting.
            vm.calcModel.Errors = [];

            $http.post('/api/Calculator', vm.calcModel).then(
                function (result) {
                    console.log(result);
                    vm.calcModel = result.data;

                    if (result.data.Errors.length > 0) {
                        return;
                    }
                },
                function (error) {
                    console.log(error);
                });
        }

        vm.getLogs = function () {
            $http.get('/api/Log').then(
                function (result) {
                    console.log(result);
                    vm.logs = result.data;
                },
                function (error) {
                    console.log(error);
                });
        }

    }
})();