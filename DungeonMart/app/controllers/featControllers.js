'use strict';

var featControllers = angular.module('featControllers', ['featServices', 'ui.bootstrap']);

featControllers.controller('featListController', [
    '$scope', 'featService', '$http', function ($scope, featService, $http) {
        $scope.loading = true;
        getData();

        function getData() {
            console.log("Getting data");
            $http.get('/api/v2/feat').success(function(data) {
                $scope.feats = data;
            });
            //TODO: figure out why this code fails so I can use it instead of $http
            //featService.getFeats({},
            //    function (value) {
            //        $scope.feats = value;
            //    }, function (response) {
            //        console.log(response);
            //    });
            $scope.loading = false;
        };
    }
]);