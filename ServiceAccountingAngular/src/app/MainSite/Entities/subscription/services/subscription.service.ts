import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { CreateSubscription } from "src/app/MainSite/Account/account-admin/create-subscription/models/create-subscription.model";
import { HeadersEnum } from "src/app/models/headers.enum";
import { SubscriptionModel } from "../models/subscription.model";
import { UpdateSubscription } from "../models/update-subscription.model";

@Injectable()
export class SubscriptionService {
    private url = "https://localhost:5001/v1/Subscription";

    constructor(private http: HttpClient) { }

    public getSubscriptionModelces(): Observable<Array<SubscriptionModel>> {
        const myHeaders = new HttpHeaders().set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<SubscriptionModel>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getSubscriptionModel(id: number): Observable<SubscriptionModel> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<SubscriptionModel>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateSubscriptionModel(model: UpdateSubscription): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(model);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public createSubscriptionModel(serve: CreateSubscription): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(serve);
        return this.http.post<any>(this.url + '/' + 'Create', body, { headers: myHeaders });
    }

    public deleteSubscriptionModel(id: number): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.delete<any>(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}