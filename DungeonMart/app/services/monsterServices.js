'use strict';

var monsterServices = angular.module('monsterServices', ['ngResource']);

featServices.factory('featService', [
    '$resource',
    function ($resource) {
        return $resource('/api/v2/monster', {}, {
            getMonsters: {
                method: 'GET',
                isArray: true
            }
        });
    }
]);