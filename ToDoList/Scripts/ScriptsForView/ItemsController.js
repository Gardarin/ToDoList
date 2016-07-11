var ToDoListApp = angular.module('ToDoListApp');
ToDoListApp.controller('ItemsController', ['$scope', '$http', function ($scope, $http) {

    $scope.Items = [];
    $scope.Item = {};
    $scope.check = false;
    $scope.loaded = true;
    $scope.nameRequired = '';
    $scope.descriptionRequired = '';
    $scope.checkedDateRequired = '';
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
        if (!$scope.Item.Name) {
            $scope.nameRequired = 'Name Required';
        }
        if (!$scope.Item.Description) {
            $scope.descriptionRequired = 'Description Required';
        }
        if (!$scope.Item.CheckedDate) {
            $scope.checkedDateRequired = 'CheckedDate Required';
        }

        if ($scope.checkedDateRequired == '' && $scope.descriptionRequired == '' && $scope.nameRequired == '') {
            $http({
                headers: { 'Content-Type': 'application/json' },
                url: 'AddItem',
                method: "POST",
                data: $scope.Item
            }).success(function (response) {
                if (response) {
                    $scope.Item = {};
                    $scope.GetItem();
                    $scope.$apply(function () {
                        $scope.GetItem();
                    });
                    //$scope.Items.push($scope.Item);
                    //$scope.Item = new [];
                }
            });
        }
    };

    $scope.CheckItem = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'CheckItem',
            method: "POST",
            data: {id: id.Id}
        }).success(function (response) {
            if (response) {
                id.IsChecked = true;
            }
        });
    };

    $scope.RemoveItem = function (id) {
        $http({
            headers: { 'Content-Type': 'application/json' },
            url: 'RemoveItem',
            method: "POST",
            data: { id: id.Id }
        }).success(function (response) {
            if (response) {
                var index = $scope.Items.indexOf(id);
                $scope.Items.splice(index, 1);

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

    $scope.CheckFilter = function () {
        console.log('test');
        console.log($scope.check);
        $scope.check = !$scope.check;
    };

}]);