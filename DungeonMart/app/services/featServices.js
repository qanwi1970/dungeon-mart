'use strict';

var featServices = angular.module('featServices', ['ngResource']);

featServices.factory('featService', [
    '$resource',
    function ($resource) {
        return $resource('/api/v2/feat', {}, {
            getFeats: {
                method: 'GET',
                isArray: true,
            }
        });
    }
]);