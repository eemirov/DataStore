(function() {
	'use strict';

	angular
		.module('app')
		.controller('HomeController', HomeController);
	HomeController.$inject = ['$rootScope', '$scope', 'FlashService'];

	function HomeController($rootScope, $scope, FlashService) {

	}
})();