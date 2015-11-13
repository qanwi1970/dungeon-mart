'use strict';
app.factory('charactersService', ['$http', function ($http) {

	//TODO: make this a config item
	var serviceBase = 'http://localhost:6621/';
	var charactersServiceFactory = {};

	var _getcharacters = function () {

		return $http.get(serviceBase + 'api/characters').then(function (results) {
			return results;
		});
	};

	charactersServiceFactory.getcharacters = _getcharacters;

	return charactersServiceFactory;

}]);