export class CreateSubscription {
      constructor(
            public name: string,
            public amountWorkouts: number,
            public price: number,
            public serviceId: number
      ) { }
}