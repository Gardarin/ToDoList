var SigInApp = angular.module('SigInApp', []);
SigInApp.controller('SigInController', ['$scope', '$http', function ($scope, $http) {

    $scope.User = {};
    $scope.SigIn = function () {
       
       

        if ($scope.sigInForm.$valid) {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'SigIn',
                method: "POST",
                data: $scope.User
            }).success(function (response) {
                //window.location. = response;
                //window.location.href = '/index.html';;
                return response;
            });

        }
    };
}]);
