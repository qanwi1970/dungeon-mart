'use strict';

var monsterControllers = angular.module('monsterControllers', ['monsterServices', 'ui.bootstrap']);

monsterControllers.controller('monsterListController', [
    '$scope', '$http', function ($scope, $http) {
        $scope.loading = true;
        getData();

        function getData() {
            console.log("Getting data");
            $http.get('/api/v2/monster').success(function(data) {
                $scope.monsters = data;
            });
            $scope.loading = false;
        };
    }
]);