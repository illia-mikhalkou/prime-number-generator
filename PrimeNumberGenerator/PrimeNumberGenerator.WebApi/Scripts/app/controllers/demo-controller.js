angularApp
	.controller('DemoCtrl', ['$scope', '$http', function ($scope, $http) {
		$scope.number = null;
		$scope.message = null;

		$scope.getNumber = null;

		$scope.saveMessage = function () {
			const objectToSend = {
				number: $scope.number,
				message: $scope.message
			};

			$http.post('/api/demo', objectToSend).then(function (response) {
				console.log(response);
			}, function (error) {
				console.log(error);
			});
		}

		$scope.getMessage = function () {
			$http.get(`/api/demo/${$scope.getNumber}`).then(function (response) {
				const textToShow = response && response.data ? `Message #${$scope.getNumber} is '${response.data}'` : 'Message not found.';
				window.alert(textToShow);
			});
		}
	}]);