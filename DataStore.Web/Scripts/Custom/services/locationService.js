(function() {
	'use strict';

	angular
		.module('app')
		.factory('LocationService', LocationService);

	LocationService.$inject = ['$location'];
	function LocationService($location) {
		var service = {};

		service.toAddOrder = toAddOrder;
		service.redirectToHome = redirectToHome;
		service.location = location;
		service.redirectToLocation = redirectToLocation;

		return service;

		function toAddOrder() {
			$location.path("/addorder");
		}

		function redirectToHome() {
			$location.path("/");
		}

		function location() {
			return $location.path();
		}

		function redirectToLocation(url) {
			window.location.href = url;
		}
	}
})();