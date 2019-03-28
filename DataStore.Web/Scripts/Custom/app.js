(function () {
	'use strict';

	angular
		.module('app', ['ngRoute'])
		.config(config)
		.run(run);

	config.$inject = ['$routeProvider'];
	function config($routeProvider) {
		$routeProvider
			.when('/', {
				controller: 'HomeController',
				templateUrl: 'home/home.view.html',
				controllerAs: 'vm'
			})

			.when('/listing', {
				controller: 'ListingController',
				templateUrl: 'login/listing.view.html',
				controllerAs: 'vm'
			})

			.otherwise({ redirectTo: '/' });
	}

})();