import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { ServeUpdate } from "../model/serve-update.model";
import { Serve } from "../model/serve.model";

@Injectable()
export class ServeService {
    private url = "https://localhost:5001/v1/Service";

    constructor(private http: HttpClient) { }

    public getServeces() : Observable<Array<Serve>> {
        const myHeaders = new HttpHeaders().set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<Serve>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getServe(id: number): Observable<Serve> {
        const myHeaders = new HttpHeaders().set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Serve>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateServe(serve: ServeUpdate): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(serve);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public deleteServe(id: number): Observable<any> {
          const myHeaders = new HttpHeaders()
          .set("Content-Type", "application/json")
          .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
      return this.http.delete<any>(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}