export class UpdateSubscription {
      constructor(
            public id: number,
            public name: string,
            public amountWorkouts: number,
            public price: number,
            public serviceId: number
      ) { }
}