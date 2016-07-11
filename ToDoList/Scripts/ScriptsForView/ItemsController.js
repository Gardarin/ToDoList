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
                    $scope.Items.push($scope.Item)
                }
            });
            
    };

    $scope.CheckItem = function (id) {
        console.log(id);
        console.log('test');
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'CheckItem',
            method: "POST",
            data: id.Id
        }).success(function (response) {
            if (response) {
                id.IsChecked=true;
               
            }
        });
    };

    $scope.RemoveItem = function (id) {
        console.log(id);
        console.log('test');
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'RemoveItem',
            method: "POST",
            data: id.Id
        }).success(function (response) {
            if (response) {
                var index = Items.indexOf(id)
                Items.splice(index, 1)
                
            }
        });
    };

    $scope.EditItem = function (item) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'EditItem',
            method: "POST",
            data: item
        }).success(function (response) {
            if (response) {
                
            }
        });
    };
}]);