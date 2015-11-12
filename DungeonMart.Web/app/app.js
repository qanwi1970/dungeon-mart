var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

	$routeProvider.when("/home", {
		controller: "homeController",
		templateUrl: "/app/views/home.html"
	});

	$routeProvider.when("/login", {
		controller: "loginController",
		templateUrl: "/app/views/login.html"
	});

	$routeProvider.when("/signup", {
		controller: "signupController",
		templateUrl: "/app/views/signup.html"
	});

	$routeProvider.when("/characters", {
		controller: "charactersController",
		templateUrl: "/app/views/characters.html"
	});

	$routeProvider.otherwise({ redirectTo: "/home" });
});

app.run(['authService', function (authService) {
	authService.fillAuthData();
}]);

app.config(function ($httpProvider) {
	$httpProvider.interceptors.push('authInterceptorService');
});