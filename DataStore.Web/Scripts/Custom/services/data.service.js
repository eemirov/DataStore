(function() {
	'use strict';

	angular
		.module('app')
		.factory('DataService', DataService);

	DataService.$inject = ['$http'];
	function DataService($http) {
		var service = {};

		service.GetInitData = GetInitData;
		service.AddOrder = AddOrder;

		return service;

		function GetInitData(callback, errorCallback) {
			$http.post("api/order/GetOrderData").then(
				function success(response) {
					callback(response.data);
				},
				function error(response) {
					errorCallback(response.data);
				});
		}

		function AddOrder(order, callback, errorCallback) {
			$http.post("api/order/GetOrderData").then(
				function success(response) {
					callback(response.data);
				},
				function error(response) {
					errorCallback(response.data);
				});
		}
	}

})();