import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { CreateClubCard } from "src/app/MainSite/Account/account-admin/create-club-card/models/create-club-card.model";
import { HeadersEnum } from "src/app/models/headers.enum";
import { ClubCard } from "../models/club-card.model";
import { UpdateClubCard } from "../models/update-club-card.model";

@Injectable()
export class ClubCardService {
    private url = "https://localhost:5001/v1/ClubCard";

    constructor(private http: HttpClient) { }

    public getClubCardces(): Observable<Array<ClubCard>> {
        const myHeaders = new HttpHeaders().set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<ClubCard>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getClubCard(id: number): Observable<ClubCard> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<ClubCard>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateClubCard(model: UpdateClubCard): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(model);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public createClubCard(model: CreateClubCard): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(model);
        return this.http.post<any>(this.url + '/' + 'Create', body, { headers: myHeaders });
    }

    public deleteClubCard(id: number): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.delete<any>(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}