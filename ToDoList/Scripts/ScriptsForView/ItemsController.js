var ToDoListApp = angular.module('ToDoListApp');
ToDoListApp.controller('ItemsController', ['$scope', '$http', function ($scope, $http) {

    $scope.Items = [];
    $scope.Item = {}; 
    $http.get('GetItems').success(function (response) {
        $scope.Items = response;
        console.log($scope.Items);
        console.log(response);
    });

    $scope.GetItem = function () {
        $http.get('GetItems').success(function (response) {
            $scope.Items = response;
            console.log($scope.Items);
            console.log(response);
        });
    };
    
    $scope.AddItem = function () {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'AddItem',
                method: "POST",
                data: $scope.Item
            }).success(function (response) {
                if (response)
                {
                    $scope.Items += $scope.Item;
                }
            });
            console.log($scope.Item);
    };

    $scope.CheckItem = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'CheckItem',
            method: "POST",
            data: id
        }).success(function (response) {
            if (response) {
            }
        });
    };

    $scope.CheckItem = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'RemoveItem',
            method: "POST",
            data: id
        }).success(function (response) {
            if (response) {
            }
        });
    };

    $scope.EditItem = function () {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'EditItem',
            method: "POST",
            data: $scope.Item
        }).success(function (response) {
            if (response) {
                $scope.Items += $scope.Item;
            }
        });
        console.log($scope.Item);
    };
}]);