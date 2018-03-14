class PrimeNumberResult {
	constructor(number) {
		this.number = number;
		this.isChecking = true;
		this.isPrime = false;
	}

	toDisplayString() {
		if (this.isChecking) {
			return `${this.number} - checking...`;
		}

		if (this.isPrime) {
			return `${this.number} - prime.`;
		}

		return `${this.number} - not prime.`;
	}
}