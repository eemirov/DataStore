(function () {
	'use strict';

	angular
		.module('app', ['ngRoute'])
		.config(config);

	config.$inject = ['$routeProvider'];
	function config($routeProvider) {
		$routeProvider
			.when('/', {
				controller: 'HomeController',
				templateUrl: 'Views/home.view.html',
				controllerAs: 'vm'
			})

			//.when('/listing', {
			//	controller: 'ListingController',
			//	templateUrl: 'Views/listing.view.html',
			//	controllerAs: 'vm'
			//})

			.otherwise({ redirectTo: '/' });
	}

})();