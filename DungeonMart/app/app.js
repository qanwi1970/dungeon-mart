'use strict';

var app = angular.module('app', [
    'homeControllers',
    'featControllers', 'featServices',
    'monsterControllers', 'monsterServices',
    'ngResource', 'ui.bootstrap', 'ui.router']);

app.config(function($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home', {
            url: '/',
            templateUrl: '/app/templates/home.html',
            controller: 'homeController'
        })
        .state('featList', {
            url: '/feats',
            templateUrl: '/app/templates/featList.html',
            controller: 'featListController'
        })
        .state('monsterList', {
            url: '/monsters',
            templateUrl: '/app/templates/monsterList.html',
            controller: 'monsterListController'
        });
});