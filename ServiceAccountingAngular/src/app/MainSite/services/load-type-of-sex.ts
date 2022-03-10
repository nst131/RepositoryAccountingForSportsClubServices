import { Injectable} from "@angular/core";
import { TypeOfSex } from "../models/type-of-sex.enum";
import { TypeOfSexModel } from "../models/type-of-sex.model";

@Injectable()
export class LoadTypeOfSexService{
    private arrayTypeOfSex: Array<TypeOfSexModel> = [
        new TypeOfSexModel(TypeOfSex[1], TypeOfSex.Man),
        new TypeOfSexModel(TypeOfSex[2], TypeOfSex.Woman),
        new TypeOfSexModel(TypeOfSex[3], TypeOfSex.NoGender)
    ]

    public GetViewsTypeOfSex(): Array<TypeOfSexModel>{
        return this.arrayTypeOfSex;
    }
}