export class UpdateTraining{
      constructor(
            public id: number,
            public name: string,
            public startTraining: Date | null,
            public trainerId: number,
            public servicesId: number,
            public clientsId: Array<number> 
      ){}
}