'use strict';
app.controller('charactersController', ['$scope', 'charactersService', function ($scope, charactersService) {

	$scope.characters = [];

	charactersService.getcharacters().then(function (results) {

		$scope.characters = results.data;

	}, function (error) {
		//alert(error.data.message);
	});

}]);