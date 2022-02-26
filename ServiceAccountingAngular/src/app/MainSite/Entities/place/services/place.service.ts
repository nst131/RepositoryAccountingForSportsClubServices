import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { CreatePlace } from "src/app/MainSite/Account/account-admin/create-place/models/create-place.model";
import { HeadersEnum } from "src/app/models/headers.enum";
import { PlaceUpdate } from "../models/place-update.model";
import { Place } from "../models/place.model";

@Injectable()
export class PlaceService {
    private url = "https://localhost:5001/v1/Place";

    constructor(private http: HttpClient) { }

    public getPlaceces() : Observable<Array<Place>> {
        const myHeaders = new HttpHeaders().set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<Place>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getPlace(id: number): Observable<Place> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Place>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updatePlace(place: PlaceUpdate): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(place);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public createPlace(place: CreatePlace): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(place);
        return this.http.post<any>(this.url + '/' + 'Create', body, { headers: myHeaders });
    }

    public deletePlace(id: number): Observable<any> {
          const myHeaders = new HttpHeaders()
          .set("Content-Type", "application/json")
          .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
      return this.http.delete<any>(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}