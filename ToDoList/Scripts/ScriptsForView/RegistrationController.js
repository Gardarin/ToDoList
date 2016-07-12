var RegisApp = angular.module('RegisApp', []);
RegisApp.controller('RegistrationController', ['$scope', '$http', function($scope, $http) {

    $scope.User = {};
    $scope.saveData = function () {
        

        if ($scope.registrationForm.$valid) {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'RegisUser',
                method: "POST",
                data: $scope.User
            }).success(function (response) {
                return response;
            });
            
        }
    };
}]);

