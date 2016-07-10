var RegisApp = angular.module('RegisApp');
RegisApp.controller('RegistrationController', ['$scope', '$http', function($scope, $http) {

    $scope.User = {};
    $scope.saveData = function () {
        $scope.nameRequired = '';
        $scope.emailRequired = '';
        $scope.passwordRequired = '';

        if (!$scope.User.Name) {
            $scope.nameRequired = 'Name Required';
        }

        if (!$scope.User.Email) {
            $scope.emailRequired = 'Email Required';
        }

        if (!$scope.User.Password) {
            $scope.passwordRequired = 'Password Required';
        }
        if ($scope.User.Password == 123456) {
            $scope.passwordRequired = '123456';
        }

        if ($scope.nameRequired == '' && $scope.emailRequired == '' && $scope.passwordRequired == '') {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'RegisUser',
                method: "POST",
                data: $scope.User
            }).success(function (response) {
               
            });
            
            console.log($scope.User);
        }
    };
}]);

