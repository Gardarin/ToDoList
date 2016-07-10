var SigInApp = angular.module('SigInApp');
SigInApp.controller('SigInController', ['$scope', '$http', function ($scope, $http) {

    $scope.User = {};
    $scope.SigIn = function () {
       
        $scope.emailRequired = '';
        $scope.passwordRequired = '';

        if (!$scope.User.Email) {
            $scope.emailRequired = 'Email Required';
        }

        if (!$scope.User.Password) {
            $scope.passwordRequired = 'Password Required';
        }

        if ($scope.emailRequired == '' && $scope.passwordRequired == '') {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'SigIn',
                method: "POST",
                data: $scope.User
            }).success(function (response) {
                console.log(response);
            });

            console.log($scope.User);
        }
    };
}]);
