angular
	.module('PrimeNumberGeneratorApp', [])
	.controller('PrimeNumberGeneratorCtrl', ['$scope', '$http', function ($scope, $http) {
		$scope.inputNumber = null;
		$scope.checking = false;
		$scope.results = [];
		$scope.error = '';

		$scope.generatePrimeList = function () {
			clearResults();

			$scope.checking = true;
			checkNumber(0, $scope.inputNumber);
		}

		function clearResults() {
			$scope.results.length = 0;
			$scope.error = '';
		}

		function checkNumber(index, maxNumber) {
			let currentNumber = 2 * index + 1;
			if (currentNumber > maxNumber) {
				$scope.checking = false;
				return;
			}

			$scope.results.push({ number: currentNumber, isPrime: false, isChecking: true });
			$http.get(`/api/primenumber/${currentNumber}`).then(function (response) {
				$scope.results[index].isPrime = response.data;
				$scope.results[index].isChecking = false;

				checkNumber(index + 1, maxNumber);
			},
			function (error) {
				$scope.checking = false;
				$scope.error = error;
			});
		}
	}]);