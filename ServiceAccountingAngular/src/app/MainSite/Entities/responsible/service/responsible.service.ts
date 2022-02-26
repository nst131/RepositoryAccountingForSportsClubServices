import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { ResponsibleUpdate } from "../models/responsible-update.model";
import { Responsible } from "../models/responsible.model";

@Injectable()
export class ResponsibleService {
    private url = "https://localhost:5001/v1/Responsible";

    constructor(private http: HttpClient) { }

    public getResponsibles(): Observable<Array<Responsible>> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<Responsible>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getResponsibleIdByEmail(email: string): Observable<number> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify({ email: email });
        return this.http.post<number>(this.url + '/' + 'GetIdByEmail', body, { headers: myHeaders });
    }

    public getResponsible(id: number): Observable<Responsible> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Responsible>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateResponsible(obj: ResponsibleUpdate): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(obj);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public deleteResponsible(id: number): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}