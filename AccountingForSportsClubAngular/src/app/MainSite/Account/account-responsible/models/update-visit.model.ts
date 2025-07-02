export class UpdateVisit{
      constructor(
            public id:number,
            public arrival: Date,
            public clientId: number,
            public serviceId: number
      ){}
}