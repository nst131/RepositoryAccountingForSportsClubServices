export class UpdateClubCard {
      constructor(
            public id: number,
            public name: string,
            public price: number,
            public durationInDays: number,
            public serviceId: number) { }
}