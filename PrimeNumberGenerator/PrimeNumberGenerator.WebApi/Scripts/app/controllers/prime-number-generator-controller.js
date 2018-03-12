angular
	.module('PrimeNumberGeneratorApp', [])
	.controller('PrimeNumberGeneratorCtrl', ['$scope', '$http', function ($scope, $http) {
		$scope.inputNumber = undefined;
		$scope.results = [];

		$scope.checkNumber = function () {
			console.log('checking...');
		}
	}]);