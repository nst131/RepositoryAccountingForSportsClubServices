import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable} from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { DealInf } from "../models/deal-inf.model";
import { MainInformationUser } from "../models/main-information-user.model";
import { SubscriptionInf } from "../models/subscription-inf.model";
import { TrainingInf } from "../models/training-inf.model";
import { VisitInf } from "../models/visit-inf.model";

@Injectable()
export class AccountUserService {
      private url = "https://localhost:5001/v1/AccountUser";

      constructor(
            private http: HttpClient) {
      }      

      public getMainInformationUser(clientId: number): Observable<MainInformationUser> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify({ id: clientId });
            return this.http.post<any>(this.url + '/' + 'GetMainInformation', body, { headers: myHeaders });
      }

      public getUserTrainingsInf(clientId: number): Observable<Array<TrainingInf>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify({ id: clientId });
            return this.http.post<any>(this.url + '/' + 'GetTrainingsUserInf', body, { headers: myHeaders });
      }

      public getUserVisitsInf(clientId: number): Observable<Array<VisitInf>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify({ id: clientId });
            return this.http.post<any>(this.url + '/' + 'GetVisitsUserInf', body, { headers: myHeaders });
      }

      public getUserSubscriprionsInf(clientId: number): Observable<Array<SubscriptionInf>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify({ id: clientId });
            return this.http.post<any>(this.url + '/' + 'GetSubscriptionsUserInf', body, { headers: myHeaders });
      }

      public getUserDealsInf(clientId: number): Observable<Array<DealInf>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify({ id: clientId });
            return this.http.post<any>(this.url + '/' + 'GetDealsUserInf', body, { headers: myHeaders });
      }
}