(function() {
	'use strict';

	angular
		.module('app')
		.factory('OrderDataService', OrderDataService);

	OrderDataService.$inject = ['$http', 'FlashService'];
	function OrderDataService($http, flashService) {
		var service = {};

		service.getInitData = getInitData;
		service.addOrder = addOrder;
		service.orderList = orderList;

		return service;

		function getInitData(callback, errorCallback) {
			$http.post("api/order/getOrderPageData").then(
				function (response) {
					successResponse(response.data, callback);
				},
				function error(response) {
					flashService.Error("Internal Error");
					if (errorCallback)
						errorCallback(response.data);
				});
		}

		function addOrder(order, callback, errorCallback) {
			$http.post("api/order/addorupdateOrder", order).then(
				function (response) {
					successResponse(response.data, callback);
				},
				function error(response) {
					flashService.Error("Internal Error");
					if(errorCallback)
						errorCallback(response.data);
				});
		}

		function orderList(filter, callback, errorCallback) {
			$http.post("api/order/getOrderList?filter=" + filter).then(
				function(response) {
					successResponse(response.data, callback);
				},
				function error(response) {
					flashService.Error("Internal Error");
					if (errorCallback)
						errorCallback(response.data);
				});
		}

		function successResponse(result, callback) {
			if (!result.IsSuccess) {
				showErrors(result.Errors);
			}
			else
				callback(result.Data);
		}

		function showErrors(errors) {
			for (var i = 0; i < errors.length; i++) {
				var error = errors[i];

				flashService.Error(error.Message);
			}
		}
	}

})();