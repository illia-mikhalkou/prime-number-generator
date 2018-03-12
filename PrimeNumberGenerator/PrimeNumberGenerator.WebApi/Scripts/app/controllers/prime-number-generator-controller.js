angular
	.module('PrimeNumberGeneratorApp', [])
	.controller('PrimeNumberGeneratorCtrl', ['$scope', '$http', function ($scope, $http) {
		$scope.inputNumber = 1;
		$scope.results = [];

		$scope.checkNumber = function () {
			console.log('checking...');
		}
	}]);