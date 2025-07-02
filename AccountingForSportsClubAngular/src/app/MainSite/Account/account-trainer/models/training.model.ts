export class Training{
      constructor(
            public id:number,
            public name:string,
            public startTraining: Date,
            public finishTraining: Date,
            public trainerName: string,
            public serviceName: string
      ){}
}