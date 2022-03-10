export class UpdateDeal{
      constructor(
            public id:number,
            public clientId:number,
            public responsibleId:number,
            public purchaseDate:Date | null,
            public subscriptionId:number | null,
            public clubCardId:number | null
      ){}
}