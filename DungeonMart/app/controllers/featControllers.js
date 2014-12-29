'use strict';

var featControllers = angular.module('featControllers', ['featServices', 'ui.bootstrap']);

featControllers.controller('featListController', [
    '$scope', 'featService', function ($scope, featService) {
        $scope.loading = true;
        getData();

        function getData() {
            console.log("Getting data");
            featService.getFeats({},
                function (value) {
                    $scope.feats = value;
                    $scope.loading = false;
                }, function (response) {
                    console.log(response);
                });
        };
    }
]);