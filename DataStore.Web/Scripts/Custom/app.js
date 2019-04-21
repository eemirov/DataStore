(function () {
	'use strict';

	angular
		.module('app', ['ngRoute'])
		.config(config);

	config.$inject = ['$routeProvider'];
	function config($routeProvider) {
		$routeProvider
			.when('/addorder', {
				controller: 'AddOrderController',
				templateUrl: 'Views/addorder.view.html',
				controllerAs: 'vm'
			})

			.when('/', {
				controller: 'OrderListController',
				templateUrl: 'Views/orderlist.view.html',
				controllerAs: 'vm'
			})

			.otherwise({ redirectTo: '/' });
	}

})();