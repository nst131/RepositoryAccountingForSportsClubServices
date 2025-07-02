import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { CreateVisit } from "../models/create-visit.model";
import { UpdateVisit } from "../models/update-visit.model";
import { Visit } from "../models/visit.model";

@Injectable()
export class VisitService {
      private url = "https://localhost:5001/v1/Visit";

      constructor(private http: HttpClient) { }

      public getVisits(): Observable<Array<Visit>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Array<Visit>>(this.url + '/' + 'GetAll', { headers: myHeaders });
      }

      public getVisit(id: number): Observable<Visit> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Visit>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
      }

      public createVisit(obj: CreateVisit): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.post<any>(this.url + '/' + 'Create', body, { headers: myHeaders });
      }

      public updateVisit(obj: UpdateVisit): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
      }

      public deleteVisit(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
      }
}