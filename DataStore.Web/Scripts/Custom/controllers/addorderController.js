(function() {
	'use strict';

	angular
		.module('app')
		.controller('AddOrderController', AddOrderController);

	AddOrderController.$inject = ['OrderDataService', 'LocationService'];
	function AddOrderController(OrderDataService, LocationService) {
		var vm = this;

		vm.addOrder = addOrder;
		vm.cancelOrder = cancelOrder;

		OrderDataService.getInitData(initData);

		function initData(data) {
			$("#orderdate").datepicker();
			vm.data = data;
		}

		function addOrder() {
			OrderDataService.addOrder(vm, function() {
				LocationService.redirectToHome();
			}, function() {

			});
		}

		function cancelOrder() {
			LocationService.redirectToHome();
		}
	}
})();