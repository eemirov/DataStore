(function () {
	'use strict';

	angular
		.module('app')
		.controller('OrderListController', OrderListController);

	OrderListController.$inject = ['OrderDataService', 'LocationService'];
	function OrderListController(orderDataService, locationService) {
		var vm = this;

		vm.addOrder = addOrder;
		vm.filterList = filterList;

		init();

		function init() {
			$("#filterInput").val('');
			getList('');
		}

		function getList(filter) {
			orderDataService.orderList(filter, callBack);
		}

		function callBack(data) {
			vm.OrderList = data;
		}

		function addOrder() {
			locationService.toAddOrder();
		}

		function filterList() {
			getList($("#filterInput").val());
		}
	}
})();