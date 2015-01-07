'use strict';

var app = angular.module('app');

app.controller('featListController', [
    '$scope', '$http', '$q', function ($scope, $http, $q) {
        $scope.loading = true;
        getData();

        function getData() {
            console.log("Getting data");
            getFeats().then(function(feats) {
                $scope.feats = feats;
                $scope.loading = false;
            });
        };

        // Move this to a service when I can figure out why my stuff isn't getting injected
        function getFeats() {
            var deferred = $q.defer();
            $http.get('/api/v2/feat')
                .success(function(data) {
                    deferred.resolve(data);
                })
                .error(function(data, status, header, config) {
                    deferred.reject(status);
                });
            return deferred.promise;
        }
    }
]);

/* from featService
(function() {
    'use strict';

    var app = angular.module('app');

    app.factory('featService',
    [
        '$http', '$q',
        function($http, $q) {
            var getFeats = function() {
                var deferred = $q.defer();
                $http.get('/api/v2/feat')
                    .success(function(data) {
                        deferred.resolve(data);
                    })
                    .error(function(data, status, header, config) {
                        deferred.reject(status);
                    });
                return deferred.promise;
            };

            return {
                getFeats: getFeats,
            };

        }
    ]);
})();*/