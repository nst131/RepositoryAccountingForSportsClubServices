export class CreateClubCard {
      constructor(
            public name: string,
            public price: number,
            public durationInDays: number,
            public serviceId: number) { }
}