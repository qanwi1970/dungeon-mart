'use strict';

var app = angular.module('app');

app.controller('monsterListController', [
    '$scope', '$http', '$q', function ($scope, $http, $q) {
        $scope.loading = true;
        getData();

        function getData() {
            console.log("Getting data");
            getMonsters().then(function(monsters) {
                $scope.monsters = monsters;
                $scope.loading = false;
            });
        };

        // Move this to a service when I can figure out why my stuff isn't getting injected
        function getMonsters() {
            var deferred = $q.defer();
            $http.get('/api/v2/monster')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data, status, header, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        }
    }
]);