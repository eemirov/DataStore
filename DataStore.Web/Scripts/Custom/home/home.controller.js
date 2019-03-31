(function() {
	'use strict';

	angular
		.module('app')
		.controller('HomeController', HomeController);

	HomeController.$inject = ['$scope', 'DataService'];
	function HomeController($scope, DataService) {
		var vm = this;

		vm.addOrder = addOrder;

		DataService.GetInitData(initData, error);

		function initData(data) {
			$("#orderdate").datepicker();
			vm.data = data;
		}

		function error() {

		}

		function addOrder() {
			
		}
	}
})();