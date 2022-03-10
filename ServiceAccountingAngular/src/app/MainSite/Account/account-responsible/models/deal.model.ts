export class Deal{
      constructor(
            public id:number,
            public purchaseDate:Date,
            public subscriptionName?:string,
            public subscriptionAmountWorkouts?:number,
            public clubCardName?:string,
            public clientName?:string,
            public responsibleName?:string
      ){}
}