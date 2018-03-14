angular
	.module('PrimeNumberGeneratorApp', ['ngMessages'])
	.controller('PrimeNumberGeneratorCtrl', ['$scope', '$http', function ($scope, $http) {
		$scope.errorMessage = 'Error occurred during generation of prime list.';
		$scope.requiredErrorMessage = 'Please enter a number.';
		$scope.rangeErrorMessage = 'Please enter integer number more than 0 and less than 2147483648.';

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

			$scope.results.push(new PrimeNumberResult(currentNumber));
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