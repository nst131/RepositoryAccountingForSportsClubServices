import { ClientCardInf } from "./client-card-Inf.model";
import { ClientInf } from "./client-Inf.model";

export class MainInformationUser{
      constructor (
            public clientInf: ClientInf,
            public clientCardInf: ClientCardInf
      ){ }
}