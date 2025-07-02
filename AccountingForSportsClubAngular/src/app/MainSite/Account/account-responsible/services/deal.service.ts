import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { CreateDeal } from "../models/create-deal.model";
import { Deal } from "../models/deal.model";
import { UpdateDeal } from "../models/update-deal.model";

@Injectable()
export class DealService {
      private url = "https://localhost:5001/v1/Deal";

      constructor(private http: HttpClient) { }

      public getDeals(): Observable<Array<Deal>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Array<Deal>>(this.url + '/' + 'GetAll', { headers: myHeaders });
      }

      public getDeal(id: number): Observable<Deal> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Deal>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
      }

      public createDeal(obj: CreateDeal): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.post<any>(this.url + '/' + 'Create', body, { headers: myHeaders });
      }

      public updateDeal(obj: UpdateDeal): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
      }

      public deleteDeal(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
      }

      public getResponsibleIdByDealId(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get(this.url + '/' + 'GetResponsibleIdByDealId' + '/' + id, { headers: myHeaders });
      }
}