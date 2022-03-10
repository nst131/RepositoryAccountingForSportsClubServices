export class CreateServe{
      constructor(
            public name: string,
            public price: number,
            public durationInMinutes: number,
            public placeId: number) { }
}